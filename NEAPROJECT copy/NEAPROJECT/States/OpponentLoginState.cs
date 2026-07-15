
using System;
using System.Security.Cryptography;
using NEAPROJECT.Backend;
using NEAPROJECT.Controls;
using NEAPROJECT.Sprites;
using System.Data.SQLite;
using System.Reflection.Metadata;
using System.Text;

namespace NEAPROJECT.States
{
    public class OpponentLoginState : LoginState
    {
        public OpponentLoginState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            LoadContent(content);
        }

        protected override void BtnLogin_Click(object sender, EventArgs e)
        {
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
                _game.Account02 = account;

                var opponentSelectClassState = new OpponentSelectClassState(_content, _game, _graphicsDevice, "startRound");
                _game.ChangeState(opponentSelectClassState);
            }
            else
            {
                _loginFailure = true;
            }

            connection.Close();
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
            spriteBatch.DrawString(_largeFont, "Opponent login", new Vector2(250, 10), Color.Black);

            // username and password labels
            spriteBatch.DrawString(_smallFont, "Username", new Vector2(250, 160), Color.Black);
            spriteBatch.DrawString(_smallFont, "Password", new Vector2(250, 210), Color.Black);

            // potential error messages
            if (_loginFailure)
            {
                spriteBatch.DrawString(_smallFont, "Incorrect username or password", new Vector2(220, 320), Color.Red);
            }
            spriteBatch.End();
        }
    }
}

