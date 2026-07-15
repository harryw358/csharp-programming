using System;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Enumerations;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.States
{
    public class SelectUpgradeState : Menu
    {
        private Player _player01;
        private Player _player02;
        private Button _btnSelectPlayer01;
        private Button _btnSelectPlayer02;
        private Player _currentlySelectedPlayer;

        private Vector2 _errorPosition;

        public SelectUpgradeState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            _game.States.Push(this);
            LoadContent(content);

            _player01 = _game.RoundState.Player01;
            _player02 = _game.RoundState.Player02;
        }

        protected override void LoadContent(ContentManager content)
        {
            // background
            var background = new Sprite(_content.Load<Texture2D>("Backgrounds/upgradesstate"));

            var buttonTexture = _content.Load<Texture2D>("Controls/buy_button");

            // melee upgrades
            var btnAddCharge = new Button(buttonTexture, _largeFont);
            btnAddCharge.Position = new Vector2(40, 230);
            btnAddCharge.Text = "Add";
            btnAddCharge.Click += BtnAddCharge_Click; 

            var btnAddLockdown = new Button(buttonTexture, _largeFont);
            btnAddLockdown.Position = new Vector2(40, 370);
            btnAddLockdown.Text = "Add";
            btnAddLockdown.Click += BtnAddLockdown_Click; 

            // mage upgrades
            var btnAddEnchantment = new Button(buttonTexture, _largeFont);
            btnAddEnchantment.Position = new Vector2(320, 230);
            btnAddEnchantment.Text = "Add";
            btnAddEnchantment.Click += BtnAddEnchantment_Click; 

            var btnAddStealth = new Button(buttonTexture, _largeFont);
            btnAddStealth.Position = new Vector2(320, 370);
            btnAddStealth.Text = "Add";
            btnAddStealth.Click += BtnAddStealth_Click;

            // ranger upgrades
            var btnAddMultishot = new Button(buttonTexture, _largeFont);
            btnAddMultishot.Position = new Vector2(580, 230);
            btnAddMultishot.Text = "Add";
            btnAddMultishot.Click += BtnAddMultishot_Click;

            var btnAddBleed = new Button(buttonTexture, _largeFont);
            btnAddBleed.Position = new Vector2(580, 370);
            btnAddBleed.Text = "Add";
            btnAddBleed.Click += BtnAddBleed_Click;

            var btnContinue = new Button(_content.Load<Texture2D>("Controls/button_small"), _smallFont);
            btnContinue.Position = new Vector2(580, 430);
            btnContinue.Text = "Continue";
            btnContinue.Click += BtnContinue_Click1;

            _btnSelectPlayer01 = new Button(_content.Load<Texture2D>("Controls/button_small"), _smallFont);
            _btnSelectPlayer01.Position = new Vector2(600, 5);
            _btnSelectPlayer01.Text = "Select player 1";
            _btnSelectPlayer01.Click += BtnSelectPlayer01_Click;

            _btnSelectPlayer02 = new Button(_content.Load<Texture2D>("Controls/button_small"), _smallFont);
            _btnSelectPlayer02.Position = new Vector2(600, 45);
            _btnSelectPlayer02.Text = "Select player 2";
            _btnSelectPlayer02.Click += BtnSelectPlayer02_Click;

            _components = new CustomLinkedList();
            _components.AddNodeToFront(background);
            _components.AddNodeToFront(btnAddCharge);
            _components.AddNodeToFront(btnAddLockdown);
            _components.AddNodeToFront(btnAddEnchantment);
            _components.AddNodeToFront(btnAddStealth);
            _components.AddNodeToFront(btnAddMultishot);
            _components.AddNodeToFront(btnAddBleed);
            _components.AddNodeToFront(btnContinue);
            _components.AddNodeToFront(_btnSelectPlayer01);
            _components.AddNodeToFront(_btnSelectPlayer02);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            spriteBatch.Begin();
            spriteBatch.DrawString(_largeFont, "Select Upgrades", new Vector2(200, 10), Color.Black);
            if (_errorOccurred)
            {
                spriteBatch.DrawString(_largeFont, "X", _errorPosition, Color.Red);
                if (!_isShowingError)
                {
                    _errorTime = 0;
                    _errorTimer.Start();
                }
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_errorOccurred)
            {
                if (_currentlySelectedPlayer == _player01)
                {
                    _errorPosition = new Vector2(580, 10);
                }
                else if (_currentlySelectedPlayer == _player02)
                {
                    _errorPosition = new Vector2(580, 40);
                }
            }
        }

        private void BtnAddCharge_Click(object sender, EventArgs e)
        {
            if (_game.Database.AccountOwnsUpgrade(_currentlySelectedPlayer.Account, "charge"))
            {
                _currentlySelectedPlayer.Upgrade = new Upgrade(null, _currentlySelectedPlayer, "charge", GetUpgradeDuration(Class.Melee, "primary"));
            }
            else
            {
                _errorOccurred = true;
            }
        }

        private void BtnAddLockdown_Click(object sender, EventArgs e)
        {
            if (_game.Database.AccountOwnsUpgrade(_currentlySelectedPlayer.Account, "lockdown"))
            {
                _currentlySelectedPlayer.Upgrade = new Upgrade(null, _currentlySelectedPlayer, "lockdown", GetUpgradeDuration(Class.Melee, "secondary"));
            }
            else
            {
                _errorOccurred = true;
            }
        }

        private void BtnAddEnchantment_Click(object sender, EventArgs e)
        {
            if (_game.Database.AccountOwnsUpgrade(_currentlySelectedPlayer.Account, "enchantment"))
            {
                _currentlySelectedPlayer.Upgrade = new Upgrade(null, _currentlySelectedPlayer, "enchantment", GetUpgradeDuration(Class.Mage, "primary"));
            }
            else
            {
                _errorOccurred = true;
            }
        }

        private void BtnAddStealth_Click(object sender, EventArgs e)
        {
            if (_game.Database.AccountOwnsUpgrade(_currentlySelectedPlayer.Account, "stealth"))
            {
                _currentlySelectedPlayer.Upgrade = new Upgrade(null, _currentlySelectedPlayer, "stealth", GetUpgradeDuration(Class.Mage, "secondary"));
            }
            else
            {
                _errorOccurred = true;
            }
        }

        private void BtnAddMultishot_Click(object sender, EventArgs e)
        {
            if (_game.Database.AccountOwnsUpgrade(_currentlySelectedPlayer.Account, "multishot"))
            {
                _currentlySelectedPlayer.Upgrade = new Upgrade(null, _currentlySelectedPlayer, "multishot", GetUpgradeDuration(Class.Ranger, "primary"));
            }
            else
            {
                _errorOccurred = true;
            }
        }

        private void BtnAddBleed_Click(object sender, EventArgs e)
        {
            if (_game.Database.AccountOwnsUpgrade(_currentlySelectedPlayer.Account, "bleed"))
            {
                _currentlySelectedPlayer.Upgrade = new Upgrade(null, _currentlySelectedPlayer, "bleed", GetUpgradeDuration(Class.Ranger, "secondary"));
            }
            else
            {
                _errorOccurred = true;
            }
        }

        private void BtnContinue_Click1(object sender, EventArgs e)
        {
            var selectMapState = new SelectMapState(_content, _game, _graphicsDevice);
            _game.ChangeState(selectMapState);
        }

        private void BtnSelectPlayer01_Click(object sender, EventArgs e)
        {
            _currentlySelectedPlayer = _player01;
        }

        private void BtnSelectPlayer02_Click(object sender, EventArgs e)
        {
            _currentlySelectedPlayer = _player02;
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            var selectMapState = new SelectMapState(_content, _game, _graphicsDevice);
            _game.ChangeState(selectMapState);
        }

        private string GetUpgradeName(Enumerations.Class _class, string type)
        {
            if (type == "primary")
            {
                switch (_class)
                {
                    case Class.Melee:
                        return "punch";
                    case Class.Mage:
                        return "enchantment";
                    case Class.Ranger:
                        return "multishot";
                }
            }
            else if (type == "secondary")
            {
                switch (_class)
                {
                    case Class.Melee:
                        return "lockdown";
                    case Class.Mage:
                        return "stealth";
                    case Class.Ranger:
                        return "bleed";
                }
            }

            return null;
        }

        private int GetUpgradeDuration(Enumerations.Class _class, string type)
        {
            if (type == "primary")
            {
                switch (_class)
                {
                    case Class.Melee:
                        return 0;
                    case Class.Mage:
                        return 4;
                    case Class.Ranger:
                        return 3;
                }
            }
            else if (type == "secondary")
            {
                switch (_class)
                {
                    case Class.Melee:
                        return 5;
                    case Class.Mage:
                        return 5;
                    case Class.Ranger:
                        return 5;
                }
            }

            return 0;
        }

        private void BtnPlayer01PrimaryUpgrade_Click(object sender, EventArgs e)
        {
            string upgradeName = GetUpgradeName(_player01.Class, "primary");
            int upgradeDuration = GetUpgradeDuration(_player01.Class, "primary");

            if (_game.Database.AccountOwnsUpgrade(_player01.Account, upgradeName))
            {
                _player01.Upgrade = new Upgrade(null, _player01, upgradeName, upgradeDuration);
            }
        }

        private void BtnPlayer01SecondaryUpgrade_Click(object sender, EventArgs e)
        {
            string upgradeName = GetUpgradeName(_player01.Class, "secondary");
            int upgradeDuration = GetUpgradeDuration(_player01.Class, "secondary");

            if (_game.Database.AccountOwnsUpgrade(_player01.Account, upgradeName))
            {
                _player01.Upgrade = new Upgrade(null, _player01, upgradeName, upgradeDuration);
            }
        }

        private void BtnPlayer02PrimaryUpgrade_Click(object sender, EventArgs e)
        {
            string upgradeName = GetUpgradeName(_player02.Class, "primary");
            int upgradeDuration = GetUpgradeDuration(_player02.Class, "primary");

            if (_game.Database.AccountOwnsUpgrade(_game.RoundState.Player01.Account, upgradeName))
            {
                _player02.Upgrade = new Upgrade(null, _player02, upgradeName, upgradeDuration);
            }
        }

        private void BtnPlayer02SecondaryUpgrade_Click(object sender, EventArgs e)
        {
            string upgradeName = GetUpgradeName(_player02.Class, "secondary");
            int upgradeDuration = GetUpgradeDuration(_player02.Class, "secondary");

            if (_game.Database.AccountOwnsUpgrade(_player02.Account, upgradeName))
            {
                _player02.Upgrade = new Upgrade(null, _player02, upgradeName, upgradeDuration);
            }
        }
    }
}

