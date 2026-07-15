using System;
using System.Data.SQLite;
using System.Reflection.Metadata;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Backend;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.UI;

namespace NEAPROJECT.States
{
    public class MainMenuState : Menu
    {
        private Account _account;

        public MainMenuState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Account account) : base(content, game, graphicsDevice)
        {
            LoadContent(content);
            _game.States.Push(this);
            _account = account;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            for (int i = 1; i <= _components.Count; i++)
            {
                Component currentComponent = _components.SearchList(i);
                currentComponent.Draw(spriteBatch);
            }
            _btnBack.Draw(spriteBatch);
            DrawStats(_content, spriteBatch);
            spriteBatch.End();
        }

        private void DrawStats(ContentManager content, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(content.Load<Texture2D>("Controls/careerprofile"), new Vector2(530, 8), Color.CornflowerBlue);
            spriteBatch.DrawString(content.Load<SpriteFont>("Fonts/Font"), _account.Username, new Vector2(540, 10), Color.Red);
            spriteBatch.DrawString(content.Load<SpriteFont>("Fonts/small_font"), "Level: " + _account.Level.ToString(), new Vector2(540, 35), Color.Black);
            spriteBatch.DrawString(content.Load<SpriteFont>("Fonts/small_font"), "XP: " + _account.XP.ToString(), new Vector2(540, 50), Color.Black);
            spriteBatch.DrawString(content.Load<SpriteFont>("Fonts/small_font"), (1000 - _account.XP).ToString() + "XP to next level", new Vector2(540, 65), Color.Black);
        }

        protected override void LoadContent(ContentManager content)
        { 
            var btnLeaderboard = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"));
            btnLeaderboard.Position = new Vector2(35, 200);
            btnLeaderboard.Text = "Leaderboard";
            btnLeaderboard.Click += BtnLeaderboard_Click;

            var btnShop = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"));
            btnShop.Position = new Vector2(35, 300);
            btnShop.Text = "Upgrades Shop";
            btnShop.Click += BtnShop_Click;

            var btnTraining = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"));
            btnTraining.Position = new Vector2(35, 100);
            btnTraining.Text = "Training";
            btnTraining.Click += BtnTraining_Click;

            var btnVersus = new Button(content.Load<Texture2D>("Controls/Button_Large"), content.Load<SpriteFont>("Fonts/Font"));
            btnVersus.Position = new Vector2(395, 100);
            btnVersus.Text = "Versus";
            btnVersus.Click += BtnVersus_Click; ; 

            _components = new CustomLinkedList();
            _components.AddNodeToFront(btnLeaderboard);
            _components.AddNodeToFront(btnShop);
            _components.AddNodeToFront(btnTraining);
            _components.AddNodeToFront(btnVersus);
        }

        private void BtnLeaderboard_Click(object sender, EventArgs e)
        {
            var database = new Database();
            var leaderboardState = new LeaderboardState(_content, _game, _graphicsDevice, database, _account);
            _game.ChangeState(leaderboardState);
        }

        private void BtnShop_Click(object sender, EventArgs e)
        {
            var upgradesShopState = new UpgradesShopState(_content, _game, _graphicsDevice, _account);
            _game.ChangeState(upgradesShopState);
        }

        private void BtnTraining_Click(object sender, EventArgs e)
        {
            var selectTrainingState = new SelectTrainingState(_content, _game, _graphicsDevice);
            _game.ChangeState(selectTrainingState);
        }

        private void BtnVersus_Click(object sender, EventArgs e)
        {
            var selectClassState = new SelectClassState(_content, _game, _graphicsDevice, "opponentLogin");
            _game.ChangeState(selectClassState);
        }
    }
}

