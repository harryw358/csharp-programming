using System;
using System.Security.Cryptography;
using System.Data.SQLite;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Backend;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.UI;

namespace NEAPROJECT.States
{
    public class CreateAccountState : Menu
    {
        private bool _usernameContainsPunctuation;
        private bool _usernameExceedsMaxLength;
        protected Textbox _txtPassword;
        protected Textbox _txtUsername;

        public CreateAccountState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            LoadContent(content);
            _game.States.Push(this);
            _usernameContainsPunctuation = false;
        }

        protected override void LoadContent(ContentManager content)
        {
            var btnClear = new Button(content.Load<Texture2D>("Controls/Button_Small"), content.Load<SpriteFont>("Fonts/Font"));
            btnClear.Position = new Vector2(420, 270);
            btnClear.Text = "Clear";
            btnClear.Click += BtnClear_Click;
            btnClear.Name = "btnclear";

            var btnCreate = new Button(content.Load<Texture2D>("Controls/Button_Small"), content.Load<SpriteFont>("Fonts/Font"));
            btnCreate.Position = new Vector2(230, 270);
            btnCreate.Text = "Create";
            btnCreate.Click += BtnCreate_Click;
            btnCreate.Name = "btncreate";

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
            _components.AddNodeToFront(btnCreate);
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
                    if (textBox.IsPassword)
                    {
                        textBox.AsteriskStringBuilder.Clear();
                    }
                }
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (_txtPassword.Text.Length == 0 || _txtUsername.Text.Length == 0)
            {
                _currentErrorMessage = "Please enter a username and password.";
                return;
            }
            if (_txtUsername.Text.Length < 3)
            {
                _currentErrorMessage = "Username must be 3-5 letters.";
                return;
            }

            Textbox txtUsername = (Textbox)_components.SearchListByName("txtusername");
            Textbox txtPassword = (Textbox)_components.SearchListByName("txtpassword");

            if (!CheckForPunctuation(txtUsername.Text))
            {
                _usernameContainsPunctuation = false;
                string hashedPassword = Hash(txtPassword.Text);
                var account = new Account(0, 0, 0, 0, 0, txtUsername.Text, hashedPassword, 0, 0, 0);
                //_game.Database.CreateTable();
                _game.Database.InsertNewAccount(account);
                _game.Account01 = account;

                var mainMenuState = new MainMenuState(_content, _game, _graphicsDevice, account);
                _game.ChangeState(mainMenuState);
            }
            else
            {
                _usernameContainsPunctuation = true;
            }
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

        private bool CheckForPunctuation(string str)
        {
            if (str.Any(char.IsPunctuation))
            {
                return true;
            }
            else
            {
                return false;
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
            spriteBatch.DrawString(_largeFont, "Create an account", new Vector2(250, 10), Color.Black);

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

        private string Hash(string source)
        {
            // convert the source string into an array of bytes
            byte[] value = ASCIIEncoding.ASCII.GetBytes(source);
            // compute the hash and return as a hexadecimal string
            return Convert.ToHexString(SHA256.Create().ComputeHash(value));
        }
    }
}

