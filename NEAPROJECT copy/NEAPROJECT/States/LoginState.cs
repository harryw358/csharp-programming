using System;
using System.Text;
using System.Security.Cryptography;
using System.Data.SQLite;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Backend;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.UI;

namespace NEAPROJECT.States
{
    public class LoginState : Menu
    {
        protected string _username;
        protected string _password;
        protected Textbox _txtPassword;
        protected Textbox _txtUsername;
        protected bool _loginSuccess;
        protected bool _loginFailure;

        public LoginState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            LoadContent(content);
            _game.States.Push(this);
        }

        protected override void LoadContent(ContentManager content)
        {
            var btnClear = new Button(content.Load<Texture2D>("Controls/Button_Small"), content.Load<SpriteFont>("Fonts/Font"));
            btnClear.Position = new Vector2(420, 270);
            btnClear.Text = "Clear";
            btnClear.Click += BtnClear_Click;
            btnClear.Name = "btnClear";

            var btnLogin = new Button(content.Load<Texture2D>("Controls/Button_Small"), content.Load<SpriteFont>("Fonts/Font"));
            btnLogin.Position = new Vector2(230, 270);
            btnLogin.Text = "Login";
            btnLogin.Click += BtnLogin_Click;
            btnLogin.Name = "btnlogin";

            _txtPassword = new Textbox(content.Load<Texture2D>("Controls/textbox"), content.Load<SpriteFont>("Fonts/Font"), 20);
            _txtPassword.Position = new Vector2(250, 220);
            _txtPassword.Click += TxtPassword_Click;
            _txtPassword.IsPassword = true;
            _txtPassword.Name = "txtpassword";

            _txtUsername = new Textbox(content.Load<Texture2D>("Controls/textbox"), content.Load<SpriteFont>("Fonts/Font"), 5);
            _txtUsername.Position = new Vector2(250, 170);
            _txtUsername.Click += TxtUsername_Click;
            _txtUsername.Name = "txtusername";

            _components = new CustomLinkedList();
            _components.AddNodeToFront(btnClear);
            _components.AddNodeToFront(btnLogin);
            _components.AddNodeToFront(_txtPassword);
            _components.AddNodeToFront(_txtUsername);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= _components.Count; i++)
            {
                var currentComponent = _components.SearchList(i);
                if (currentComponent is Textbox)
                {
                    Textbox textBox = (Textbox)currentComponent;
                    textBox.StringBuilder.Clear();
                    textBox.AsteriskStringBuilder.Clear();
                }
            }
        }

        protected virtual void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_txtPassword.Text.Length == 0 || _txtUsername.Text.Length == 0)
            {
                _currentErrorMessage = "Please enter a username and password.";
                return;
            }

            _loginSuccess = false;
            var txtUsername = (Textbox)_components.SearchListByName("txtusername");
            var txtPassword = (Textbox)_components.SearchListByName("txtpassword");

            // create new connection to database
            var connection = new SQLiteConnection($"Data Source=data.db;Version=3;New=True");
            connection.Open();

            // query to execute
            var command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Accounts";
            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                // username check
                var databaseUsername = dataReader.GetString(5);
                if (txtUsername.Text != databaseUsername)
                {
                    continue;
                }

                // password check
                var databasePassword = dataReader.GetString(6);
                if (CompareHashes(Hash(txtPassword.Text), databasePassword))
                {
                    _loginSuccess = true;
                }
            }

            if (_loginSuccess)
            {
                var account = _game.Database.FetchAccount(txtUsername.Text);
                _game.Account01 = account;

                var mainMenuState = new MainMenuState(_content, _game, _graphicsDevice, account);
                _game.ChangeState(mainMenuState);
            }
            else
            {
                _loginFailure = true;
                _currentErrorMessage = "Incorrect username or password.";
            }

            connection.Close();
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= _components.Count; i++)
            {
                var currentComponent = _components.SearchList(i);
                if (currentComponent.Name == "txtpassword")
                {
                    Textbox textBox = (Textbox)currentComponent;
                    textBox.IsClicked = true;
                }
            }
        }

        private void TxtUsername_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= _components.Count; i++)
            {
                var currentComponent = _components.SearchList(i);
                if (currentComponent.Name == "txtusername")
                {
                    Textbox textBox = (Textbox)currentComponent;
                    textBox.IsClicked = true;
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            for (int i = 1; i <= _components.Count; i++)
            {
                Component currentComponent = _components.SearchList(i);
                currentComponent.Draw(spriteBatch);
            }
            _btnBack.Draw(spriteBatch);

            // title
            spriteBatch.DrawString(_largeFont, "Login", new Vector2(350, 10), Color.Black);

            // username and password labels
            spriteBatch.DrawString(_smallFont, "Username", new Vector2(250, 160), Color.Black);
            spriteBatch.DrawString(_smallFont, "Password", new Vector2(250, 210), Color.Black);

            if (_currentErrorMessage != null)
            {
                spriteBatch.DrawString(_smallFont, _currentErrorMessage, new Vector2(220, 320), Color.Red);
                if (!_isShowingError)
                {
                    _errorTime = 0;
                    _errorTimer.Start();
                }
            }

            spriteBatch.End();
        }

        protected string Hash(string source)
        {
            // convert the source string into an array of bytes
            byte[] value = ASCIIEncoding.ASCII.GetBytes(source);
            // compute the hash and return as a hexadecimal string
            return Convert.ToHexString(SHA256.Create().ComputeHash(value));
        }

        protected bool CompareHashes(string testSource, string testHash)
        {
            // hash the test source
            string tempHash = Hash(testSource);
            // loop through each character in the temp hash while the corresponding letters are equal
            int count = 0;
            while (count < tempHash.Length && tempHash[count] == testHash[count])
            {
                count++;
            }
            // if the count (length of temp hash) is equal to the length of the test hash the test hash passed the test and the 2 hashes are equal
            if (count == testHash.Length)
            {
                return true;
            }
            // if the hashes are not the same, return false
            return false;
        }
    }
}

