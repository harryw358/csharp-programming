using System;
using System.Data.SQLite;
using System.Reflection.Metadata;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Sprites;
using NEAPROJECT.UI.RoundUI;
using NEAPROJECT.Enumerations;
using NEAPROJECT.Backend;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.UI;
using NEAPROJECT.UI.MenuUI;

namespace NEAPROJECT.States
{
    public class SelectClassState : Menu
    {
        protected Enumerations.Class _currentlySelectedClass;
        protected Player _player;
        private string _nextState;

        public SelectClassState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, string nextState) : base(content, game, graphicsDevice)
        {
            LoadContent(content);
            _game.States.Push(this);
            _currentlySelectedClass = Class.None;
            _nextState = nextState;
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

            spriteBatch.End();
        }

        protected override void LoadContent(ContentManager content)
        {
            var btnMage = new Button(content.Load<Texture2D>("Controls/Class/mage"), content.Load<SpriteFont>("Fonts/Font"));
            btnMage.Position = new Vector2(250, 200);
            btnMage.Click += BtnMage_Click;
            btnMage.Name = "btnmage";

            var btnMelee = new Button(content.Load<Texture2D>("Controls/Class/melee"), content.Load<SpriteFont>("Fonts/Font"));
            btnMelee.Position = new Vector2(250, 80);
            btnMelee.Click += BtnMelee_Click;
            btnMelee.Name = "btnmelee";

            var btnRanger = new Button(content.Load<Texture2D>("Controls/Class/ranger"), content.Load<SpriteFont>("Fonts/Font"));
            btnRanger.Position = new Vector2(250, 320);
            btnRanger.Click += BtnRanger_Click;
            btnRanger.Name = "btnranger";

            _components = new CustomLinkedList();
            _components.AddNodeToFront(btnMage);
            _components.AddNodeToFront(btnMelee);
            _components.AddNodeToFront(btnRanger);   
        }

        private void BtnMage_Click(object sender, EventArgs e)
        {
            _currentlySelectedClass = Class.Mage;
            Continue();
        }

        private void BtnMelee_Click(object sender, EventArgs e)
        {
            _currentlySelectedClass = Class.Melee;
            Continue();
        }

        private void BtnRanger_Click(object sender, EventArgs e)
        {
            _currentlySelectedClass = Class.Ranger;
            Continue();
        }

        protected virtual void Continue()
        {
            if (_nextState == "opponentLogin")
            {
                _game.RoundState.Player01 = CreatePlayer();

                var opponentLoginState = new OpponentLoginState(_content, _game, _graphicsDevice);
                _game.ChangeState(opponentLoginState);
            }
            else if (_nextState == "startTraining")
            {
                _game.TrainingState.Player = CreatePlayer();

                _game.TrainingState.Map = new Maps.Map(Enumerations.Map.Normal, _content.Load<Texture2D>("Backgrounds/normal"), MapEffect.None, _game.TrainingState);
                _game.ChangeState(_game.TrainingState);
                _game.TrainingState.Begin();
            }
        }

        protected virtual Player CreatePlayer()
        {
            var animations = GetPlayerAnimations();
            _player = new Player(animations);
            _player.Class = _currentlySelectedClass;
            _player.Input = new Input();
            _player.Input.Left = Keys.A;
            _player.Input.Right = Keys.D;
            _player.Input.Jump = Keys.W;
            _player.Input.Attack = Keys.S;
            _player.Input.EquipPrimaryOffense = Keys.D1;
            _player.Input.EquipSecondaryOffense = Keys.D2;
            _player.Input.UseUpgrade = Keys.D3;
            _player.Input.UseSmallHealing = Keys.Z;
            _player.Input.UseLargeHealing = Keys.X;
            _player.PrimaryOffense = GetWeapon("primary");
            if (_currentlySelectedClass != Class.Melee)
            {
                _player.SecondaryOffense = GetWeapon("secondary");
            }
            else
            {
                _player.Shield = new Shield(null, _player);
            }
            _player.SmallHealingItem = new HealingItem(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_large"), "small", 3, _player);
            _player.LargeHealingItem = new HealingItem(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_small"), "large", 1, _player);
            _player.Account = _game.Account01;
            _player.StartingPosition = new Vector2(100, 20);
            _player.Animator = new AnimationController(animations.First().Value, _player);
            // UI for player
            _player.HealthBar = new HealthBar(GetBarTexture("health"), _largeFont, _player, new Vector2(10, 10), new Vector2(206, 10));
            _player.PointsBar = new PointsBar(GetBarTexture("points"), _largeFont, _player, new Vector2(10, 45), new Vector2(206, 45));
            _player.PrimaryOffenseSlot = GetHotbarSlot("primary");
            _player.SecondaryOffenseSlot = GetHotbarSlot("secondary");
            _player.SmallHealingSlot = new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_small"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(10, 340), Color.White, "Z", _player.SmallHealingItem);
            _player.LargeHealingSlot = new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_large"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(70, 340), Color.White, "X", _player.LargeHealingItem);

            AddSpriteComponents(_player);

            return _player;
        }

        protected void AddSpriteComponents(Player player)
        {
            player.SpriteComponents.AddNodeToFront(player.HealthBar);
            player.SpriteComponents.AddNodeToFront(player.PointsBar);
            player.SpriteComponents.AddNodeToFront(player.PrimaryOffenseSlot);
            player.SpriteComponents.AddNodeToFront(player.SecondaryOffenseSlot);
            player.SpriteComponents.AddNodeToFront(player.SmallHealingSlot);
            player.SpriteComponents.AddNodeToFront(player.LargeHealingSlot);

            if (_currentlySelectedClass == Class.Melee)
            {
                player.SpriteComponents.AddNodeToFront(player.Shield);
            }
        }

        protected virtual HotbarSlot GetHotbarSlot(string type)
        {
            switch (_currentlySelectedClass)
            {
                case Class.Melee:
                    {
                        if (type == "primary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/attack"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(10, 410), Color.White, "1", _player.PrimaryOffense);
                        }
                        else if (type == "secondary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/shield"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(70, 410), Color.White, "2", _player.Shield);
                        }
                    }
                    break;
                case Class.Mage:
                    {
                        if (type == "primary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/magicwand"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(10, 410), Color.White, "1", _player.PrimaryOffense);
                        }
                        else if (type == "secondary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/cursedflames"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(70, 410), Color.White, "2", _player.SecondaryOffense);
                        }
                    }
                    break;
                case Class.Ranger:
                    {
                        if (type == "primary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/pancakeshooter"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(10, 410), Color.White, "1", _player.PrimaryOffense);
                        }
                        else if (type == "secondary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/catlauncher"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(70, 410), Color.White, "2", _player.SecondaryOffense);
                        }
                    }
                    break;
            }

            return null;    
        }

        protected Weapon GetWeapon(string type)
        {
            Weapon weapon = null;

            switch (type)
            {
                case "primary":
                    {
                        if (_currentlySelectedClass == Class.Melee)
                        {
                            weapon = new Weapon(null);
                            weapon.DamageAmount = 35;
                            weapon.Name = "Attack";
                        }
                        else if (_currentlySelectedClass == Class.Mage)
                        {
                            weapon = new Weapon(null);
                            weapon.DamageAmount = 10;
                            weapon.Ammunition = new Ammunition(_content.Load<Texture2D>("Offense/Mage/magicstar"));
                            weapon.AmmunitionCount = 30;
                            weapon.Name = "Magic Wand";
                        }
                        else if (_currentlySelectedClass == Class.Ranger)
                        {
                            weapon = new Weapon(null);
                            weapon.DamageAmount = 10;
                            weapon.Ammunition = new Ammunition(_content.Load<Texture2D>("Offense/Ranger/pancake"));
                            weapon.Name = "Pancake Shooter";
                        }
                    }
                    break;
                case "secondary":
                    {
                        if (_currentlySelectedClass == Class.Mage)
                        {
                            weapon = new Weapon(null);
                            weapon.DamageAmount = 25;
                            weapon.Ammunition = new Ammunition(_content.Load<Texture2D>("Offense/Mage/cursedflames"));
                            var snareAnimations = new Dictionary<string, Animation>();
                            snareAnimations.Add("Fire", new Animation(_content.Load<Texture2D>("Offense/Mage/fire"), 8, 0.2d));
                            weapon.SnareAmmunition = new SnareAmmunition(snareAnimations);
                            weapon.Name = "Cursed Flames";
                        }
                        else if (_currentlySelectedClass == Class.Ranger)
                        {
                            weapon = new Weapon(null);
                            weapon.DamageAmount = 20;
                            weapon.Ammunition = new Ammunition(_content.Load<Texture2D>("Offense/Ranger/cat"));
                            weapon.Name = "Cat Launcher";
                        }
                    }
                    break;
            }

            weapon.Owner = _player;
            return weapon;
        }

        protected virtual Dictionary<string, Texture2D> GetBarTexture(string type)
        {
            var textures = new Dictionary<string, Texture2D>();

            switch (type)
            {
                case "health":
                    {
                        textures.Add("full", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/full"));
                        textures.Add("5/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/5_6"));
                        textures.Add("4/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/4_6"));
                        textures.Add("3/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/3_6"));
                        textures.Add("2/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/2_6"));
                        textures.Add("1/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/1_6"));
                        textures.Add("empty", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/empty"));
                    }
                    break;
                case "points":
                    {
                        textures.Add("full", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/full"));
                        textures.Add("2/3", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/2_3"));
                        textures.Add("1/3", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/1_3"));
                        textures.Add("empty", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/empty"));
                    }
                    break;
            }

            return textures;
        }

        protected Dictionary<string, Animation> GetPlayerAnimations()
        {
            var animations = new Dictionary<string, Animation>();

            if (_currentlySelectedClass == Class.Melee)
            {
                // Left animations
                animations.Add("LeftRun", new Animation(_content.Load<Texture2D>("Players/Melee/Left/run"), 7, 0.1d));
                animations.Add("LeftIdle", new Animation(_content.Load<Texture2D>("Players/Melee/Left/idle"), 4, 0.1d));
                animations.Add("LeftAttack01", new Animation(_content.Load<Texture2D>("Players/Melee/Left/attack_1"), 5, 0.1d));
                animations.Add("LeftAttack02", new Animation(_content.Load<Texture2D>("Players/Melee/Left/attack_2"), 4, 0.1d));
                animations.Add("LeftAttack03", new Animation(_content.Load<Texture2D>("Players/Melee/Left/attack_3"), 4, 0.1d));
                animations.Add("LeftDead", new Animation(_content.Load<Texture2D>("Players/Melee/Left/dead"), 6, 0.1d));
                animations.Add("LeftHurt", new Animation(_content.Load<Texture2D>("Players/Melee/Left/hurt"), 2, 0.1d));
                animations.Add("LeftDefend", new Animation(_content.Load<Texture2D>("Players/Melee/Left/defend"), 5, 0.1d));
                animations.Add("LeftChargeAttack", new Animation(_content.Load<Texture2D>("Players/Melee/Left/chargeattack"), 6, 0.1d));

                // Right animations
                animations.Add("RightRun", new Animation(_content.Load<Texture2D>("Players/Melee/Right/run"), 7, 0.1d));
                animations.Add("RightIdle", new Animation(_content.Load<Texture2D>("Players/Melee/Right/idle"), 4, 0.1d));
                animations.Add("RightAttack01", new Animation(_content.Load<Texture2D>("Players/Melee/Right/attack_1"), 5, 0.1d));
                animations.Add("RightAttack02", new Animation(_content.Load<Texture2D>("Players/Melee/Right/attack_2"), 4, 0.1d));
                animations.Add("RightAttack03", new Animation(_content.Load<Texture2D>("Players/Melee/Right/attack_3"), 4, 0.1d));
                animations.Add("RightDead", new Animation(_content.Load<Texture2D>("Players/Melee/Right/dead"), 6, 0.1d));
                animations.Add("RightHurt", new Animation(_content.Load<Texture2D>("Players/Melee/Right/hurt"), 2, 0.1d));
                animations.Add("RightDefend", new Animation(_content.Load<Texture2D>("Players/Melee/Right/defend"), 5, 0.1d));
                animations.Add("RightChargeAttack", new Animation(_content.Load<Texture2D>("Players/Melee/Right/chargeattack"), 5, 0.1d));
            }
            else if (_currentlySelectedClass == Class.Mage)
            {
                // Left animations
                animations.Add("LeftRun", new Animation(_content.Load<Texture2D>("Players/Mage/Left/run"), 8, 0.1d));
                animations.Add("LeftIdle", new Animation(_content.Load<Texture2D>("Players/Mage/Left/idle"), 8, 0.1d));
                animations.Add("LeftAttack", new Animation(_content.Load<Texture2D>("Players/Mage/Left/shoot"), 6, 0.1d));
                animations.Add("LeftDead", new Animation(_content.Load<Texture2D>("Players/Mage/Left/dead"), 4, 0.1d));
                animations.Add("LeftHurt", new Animation(_content.Load<Texture2D>("Players/Mage/Left/hurt"), 4, 0.1d));
                animations.Add("LeftStealth", new Animation(_content.Load<Texture2D>("Players/Mage/Left/stealth"), 8, 0.1d));

                // Right animations
                animations.Add("RightRun", new Animation(_content.Load<Texture2D>("Players/Mage/Right/run"), 8, 0.1d));
                animations.Add("RightIdle", new Animation(_content.Load<Texture2D>("Players/Mage/Right/idle"), 8, 0.1d));
                animations.Add("RightAttack", new Animation(_content.Load<Texture2D>("Players/Mage/Right/shoot"), 6, 0.1d));
                animations.Add("RightDead", new Animation(_content.Load<Texture2D>("Players/Mage/Right/dead"), 4, 0.1d));
                animations.Add("RightHurt", new Animation(_content.Load<Texture2D>("Players/Mage/Right/hurt"), 4, 0.1d));
                animations.Add("RightStealth", new Animation(_content.Load<Texture2D>("Players/Mage/Right/stealth"), 8, 0.1d));
            }
            else if (_currentlySelectedClass == Class.Ranger)
            {
                // Left animations
                animations.Add("LeftRun", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/run"), 8, 0.1d));
                animations.Add("LeftIdle", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/idle"), 7, 0.1d));
                animations.Add("LeftAttack", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/shoot"), 15, 0.1d));
                animations.Add("LeftDead", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/dead"), 5, 0.1d));
                animations.Add("LeftHurt", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/hurt"), 2, 0.1d));

                // Right animations
                animations.Add("RightRun", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/run"), 8, 0.1d));
                animations.Add("RightIdle", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/idle"), 7, 0.1d));
                animations.Add("RightAttack", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/shoot"), 15, 0.1d));
                animations.Add("RightDead", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/dead"), 5, 0.1d));
                animations.Add("RightHurt", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/hurt"), 2, 0.1d));
            }

            return animations;
        }
    }
}

