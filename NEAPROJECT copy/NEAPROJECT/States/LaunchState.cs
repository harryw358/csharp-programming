using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;

namespace NEAPROJECT.States
{
    public class LaunchState : Menu
    { 
        public LaunchState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            LoadContent(content);
            _game.States.Push(this);
        }

        protected override void LoadContent(ContentManager content)
        {
            var btnCreateAccount = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"));
            btnCreateAccount.Position = new Vector2(230, 200);
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.Click += BtnCreateAccount_Click;

            var btnExit = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"));
            btnExit.Position = new Vector2(230, 300);
            btnExit.Text = "Exit";
            btnExit.Click += BtnExit_Click;

            var btnLogin = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"));
            btnLogin.Position = new Vector2(230, 100);
            btnLogin.Text = "Login";
            btnLogin.Click += BtnLogin_Click;

            _components = new CustomLinkedList();
            _components.AddNodeToFront(btnCreateAccount);
            _components.AddNodeToFront(btnExit);
            _components.AddNodeToFront(btnLogin);
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            var createAccountState = new CreateAccountState(_content, _game, _graphicsDevice);
            _game.ChangeState(createAccountState);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var loginState = new LoginState(_content, _game, _graphicsDevice);
            _game.ChangeState(loginState);
;        }
    }
}

