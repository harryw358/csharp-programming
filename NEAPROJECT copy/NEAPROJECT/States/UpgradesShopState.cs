using System;
using System.Data.SQLite;
using System.Reflection.Metadata;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Backend;
using NEAPROJECT.Controllers;
using NEAPROJECT.Sprites;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.UI;

namespace NEAPROJECT.States
{
    public class UpgradesShopState : Menu
    {
        private Account _account;
        private bool _purchaseFailed;

        public UpgradesShopState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Account account) : base(content, game, graphicsDevice)
        {
            _game.States.Push(this);
            _account = account;
            LoadContent(content);
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
            spriteBatch.DrawString(_largeFont, "Upgrades", new Vector2(320, 10), Color.Black);
            spriteBatch.DrawString(_largeFont, "Coins: " + _account.Coins.ToString(), new Vector2(580, 10), Color.Gold);

            if (_purchaseFailed)
            {
                spriteBatch.DrawString(_smallFont, "Not enough coins.", new Vector2(280, 460), Color.Red);
            }
            spriteBatch.End();
        }

        protected override void LoadContent(ContentManager content)
        {
            // background
            var background = new Sprite(_content.Load<Texture2D>("Backgrounds/upgradesstate"));

            var buttonTexture = _content.Load<Texture2D>("Controls/buy_button");

            // melee upgrades
            var btnCharge = new Button(buttonTexture, _largeFont);
            btnCharge.Position = new Vector2(80, 230);
            btnCharge.Text = "C100";
            btnCharge.Click += BtnCharge_Click;

            var btnLockdown = new Button(buttonTexture, _largeFont);
            btnLockdown.Position = new Vector2(80, 370);
            btnLockdown.Text = "C200";
            btnLockdown.Click += BtnLockdown_Click;

            // mage upgrades
            var btnEnchantment = new Button(buttonTexture, _largeFont);
            btnEnchantment.Position = new Vector2(360, 230);
            btnEnchantment.Text = "C100";
            btnEnchantment.Click += BtnEnchantment_Click;

            var btnStealth = new Button(buttonTexture, _largeFont);
            btnStealth.Position = new Vector2(360, 370);
            btnStealth.Text = "C200";
            btnStealth.Click += BtnStealth_Click;

            // ranger upgrades
            var btnMultishot = new Button(buttonTexture, _largeFont);
            btnMultishot.Position = new Vector2(620, 230);
            btnMultishot.Text = "C100";
            btnMultishot.Click += BtnMultishot_Click;

            var btnBleed = new Button(buttonTexture, _largeFont);
            btnBleed.Position = new Vector2(620, 370);
            btnBleed.Text = "C200";
            btnBleed.Click += BtnBleed_Click;

            _components = new CustomLinkedList();
            _components.AddNodeToFront(background);
            _components.AddNodeToFront(btnCharge);
            _components.AddNodeToFront(btnLockdown);
            _components.AddNodeToFront(btnEnchantment);
            _components.AddNodeToFront(btnStealth);
            _components.AddNodeToFront(btnMultishot);
            _components.AddNodeToFront(btnBleed);
        }

        private void BtnCharge_Click(object sender, EventArgs e)
        {
            if (HasEnoughCoins(_account, 100))
            {
                _account.Coins -= 100;
                _game.Database.AddUpgrade(_account, "charge");
                var previousState = _game.States.Pop();
                _game.ChangeState(previousState);
            }
            else
            {
                _purchaseFailed = true;
            }
        }

        private void BtnLockdown_Click(object sender, EventArgs e)
        {
            if (HasEnoughCoins(_account, 200))
            {
                _account.Coins -= 200;
                _game.Database.AddUpgrade(_account, "lockdown");
                _game.ChangeState(_game.States.Pop());
            }
            else
            {
                _purchaseFailed = true;
            }
        }

        private void BtnEnchantment_Click(object sender, EventArgs e)
        {
            if (HasEnoughCoins(_account, 100))
            {
                _account.Coins -= 100;
                _game.Database.AddUpgrade(_account, "enchantment");
                _game.ChangeState(_game.States.Pop());
            }
            else
            {
                _purchaseFailed = true;
            }
        }

        private void BtnStealth_Click(object sender, EventArgs e)
        {
            if (HasEnoughCoins(_account, 200))
            {
                _account.Coins -= 200;
                _game.Database.AddUpgrade(_account, "stealth");
                _game.ChangeState(_game.States.Pop());
            }
            else
            {
                _purchaseFailed = true;
            }
        }

        private void BtnMultishot_Click(object sender, EventArgs e)
        {
            if (HasEnoughCoins(_account, 100))
            {
                _account.Coins -= 100;
                _game.Database.AddUpgrade(_account, "multishot");
                _game.ChangeState(_game.States.Pop());
            }
            else
            {
                _purchaseFailed = true;
            }
        }

        private void BtnBleed_Click(object sender, EventArgs e)
        {
            if (HasEnoughCoins(_account, 200))
            {
                _account.Coins -= 200;
                _game.Database.AddUpgrade(_account, "bleed");
                _game.ChangeState(_game.States.Pop());
            }
            else
            {
                _purchaseFailed = true;
            }
        }

        private bool HasEnoughCoins(Account account, int upgradeCost)
        {
            if (account.Coins >= upgradeCost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

