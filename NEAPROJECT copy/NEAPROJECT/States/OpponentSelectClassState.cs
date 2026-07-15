using System;
using NEAPROJECT.Controllers;
using NEAPROJECT.Enumerations;
using NEAPROJECT.Sprites;
using NEAPROJECT.UI.RoundUI;

namespace NEAPROJECT.States
{
    public class OpponentSelectClassState : SelectClassState
    {
        public OpponentSelectClassState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, string nextState) : base(content, game, graphicsDevice, nextState)
        {

        }

        protected override void Continue()
        {
            _game.RoundState.Player02 = CreatePlayer();

            var selectUpgradeState = new SelectUpgradeState(_content, _game, _graphicsDevice);
            _game.ChangeState(selectUpgradeState);
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

        protected override Player CreatePlayer()
        {
            var animations = GetPlayerAnimations();
            _player = new Player(GetPlayerAnimations());
            _player.Class = _currentlySelectedClass;
            _player.Input = new Input();
            _player.Input.Left = Keys.J;
            _player.Input.Right = Keys.L;
            _player.Input.Jump = Keys.I;
            _player.Input.Attack = Keys.K;
            _player.Input.EquipPrimaryOffense = Keys.D8;
            _player.Input.EquipSecondaryOffense = Keys.D9;
            _player.Input.UseUpgrade = Keys.D0;
            _player.Input.UseSmallHealing = Keys.M;
            _player.Input.UseLargeHealing = Keys.N;
            _player.PrimaryOffense = GetWeapon("primary");
            if (_currentlySelectedClass != Class.Melee)
            {
                _player.SecondaryOffense = GetWeapon("secondary");
            }
            else
            {
                _player.Shield = new Shield(null, _player);
            }
            _player.SmallHealingItem = new HealingItem(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_small"), "small", 3, _player);
            _player.LargeHealingItem = new HealingItem(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_large"), "large", 1, _player);
            _player.Account = _game.Account02;
            _player.StartingPosition = new Vector2(500, 20);
            _player.Animator = new AnimationController(animations.First().Value, _player);
            // UI for player
            _player.HealthBar = new HealthBar(GetBarTexture("health"), _largeFont, _player, new Vector2(600, 10), new Vector2(520, 10));
            _player.PointsBar = new PointsBar(GetBarTexture("points"), _largeFont, _player, new Vector2(600, 45), new Vector2(520, 45));
            _player.PrimaryOffenseSlot = GetHotbarSlot("primary");
            _player.SecondaryOffenseSlot = GetHotbarSlot("secondary");
            _player.SmallHealingSlot = new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_small"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(720, 340), Color.White, "M", _player.SmallHealingItem);
            _player.LargeHealingSlot = new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/healingitem_large"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(660, 340), Color.White, "N", _player.LargeHealingItem);

            AddSpriteComponents(_player);

            return _player;
        }

        protected override Dictionary<string, Texture2D> GetBarTexture(string type)
        {
            var textures = new Dictionary<string, Texture2D>();

            switch (type)
            {
                case "health":
                    {
                        textures.Add("full", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_2/full"));
                        textures.Add("5/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_2/5_6"));
                        textures.Add("4/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_2/4_6"));
                        textures.Add("3/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_2/3_6"));
                        textures.Add("2/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_2/2_6"));
                        textures.Add("1/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_2/1_6"));
                        textures.Add("empty", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_2/empty"));
                    }
                    break;
                case "points":
                    {
                        textures.Add("full", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_2/full"));
                        textures.Add("2/3", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_2/2_3"));
                        textures.Add("1/3", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_2/1_3"));
                        textures.Add("empty", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_2/empty"));
                    }
                    break;
            }

            return textures;
        }

        protected override HotbarSlot GetHotbarSlot(string type)
        {
            switch (_currentlySelectedClass)
            {
                case Class.Melee:
                    {
                        if (type == "primary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/attack"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(720, 410), Color.White, "8", _player.PrimaryOffense);
                        }
                        else if (type == "secondary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/shield"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(660, 410), Color.White, "9", _player.Shield);
                        }
                    }
                    break;
                case Class.Mage:
                    {
                        if (type == "primary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/magicwand"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(720, 410), Color.White, "8", _player.PrimaryOffense);
                        }
                        else if (type == "secondary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/cursedflames"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(660, 410), Color.White, "9", _player.SecondaryOffense);
                        }
                    }
                    break;
                case Class.Ranger:
                    {
                        if (type == "primary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/pancakeshooter"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(720, 410), Color.White, "8", _player.PrimaryOffense);
                        }
                        else if (type == "secondary")
                        {
                            return new HotbarSlot(_content.Load<Texture2D>("HeadsUpDisplay/catlauncher"), _content.Load<Texture2D>("HeadsUpDisplay/keybind"), _smallFont, new Vector2(660, 410), Color.White, "9", _player.SecondaryOffense);
                        }
                    }
                    break;
            }

            return null;
        }
    }
}

