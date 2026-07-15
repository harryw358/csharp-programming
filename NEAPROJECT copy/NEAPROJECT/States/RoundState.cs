using System;
using System.Reflection.Metadata;
using NEAPROJECT.Backend;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Enumerations;
using NEAPROJECT.Maps;
using NEAPROJECT.Sprites;
using NEAPROJECT.Training;
using NEAPROJECT.UI.RoundUI;

namespace NEAPROJECT.States
{
    public class RoundState : State
    {
        protected SpriteFont _smallFont;
        protected SpriteFont _largeFont;
        protected SpriteFont _largerFont;
        protected CustomLinkedList _components;
        protected Maps.Map _map;
        private Player _player01;
        private Player _player02;
        protected Player _winner;
        protected System.Timers.Timer _timer;
        protected int _time;
        protected bool _isInLoop;
        protected HotbarSlot _primaryOffenseSlot01;
        protected HotbarSlot _secondaryOffenseSlot01;
        protected HotbarSlot _primaryOffenseSlot02;
        protected HotbarSlot _secondaryOffenseSlot02;
        protected bool _deathFound;
        protected Player _eliminatedPlayer;
        protected bool _isRespawning;
        protected bool _winnerFound;

        public Maps.Map Map { get => _map; set => _map = value; }
        public Player Player01 { get => _player01; set => _player01 = value; }
        public Player Player02 { get => _player02; set => _player02 = value; }
        public Player Winner { get => _winner; set => _winner = value; }


        public RoundState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _smallFont = content.Load<SpriteFont>("Fonts/small_font");
            _largeFont = content.Load<SpriteFont>("Fonts/large_font");
            _largerFont = content.Load<SpriteFont>("Fonts/larger_font");

            _isInLoop = false;

            _components = new CustomLinkedList();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            // erases previous contents of screen
            _graphicsDevice.Clear(Color.CornflowerBlue);

            if (!_isInLoop)
            {
                // start timer visual
                if (_time == 5 || _time == 4 || _time == 3)
                {
                    spriteBatch.DrawString(_largerFont, (_time - 2).ToString(), new Vector2(380, 200), Color.Black);
                }
                else if (_time == 2)
                {
                    spriteBatch.DrawString(_largerFont, "Get ready!", new Vector2(160, 200), Color.DarkOrange);
                }
                else
                {
                    spriteBatch.DrawString(_largerFont, "Go!", new Vector2(320, 200), Color.LightGreen);
                }
            }
            else if (_isInLoop)
            {
                _map.Draw(spriteBatch);
                if (_player01.Class == Class.Melee && _player01.Shield.IsEquipped)
                {
                    spriteBatch.DrawString(_smallFont, ": " + _player01.Shield.Health + "HP", new Vector2(125, 430), Color.Black);
                }
                if (_player02.Class == Class.Melee && _player02.Shield.IsEquipped)
                {
                    spriteBatch.DrawString(_smallFont, ": " + _player02.Shield.Health + "HP", new Vector2(125, 430), Color.Black);
                }
                for (int i = 1; i <= _components.Count; i++)
                {
                    Component currentComponent = _components.SearchList(i);
                    currentComponent.Draw(spriteBatch);
                }

                if (_deathFound)
                {
                    spriteBatch.DrawString(_largerFont, "Respawning", new Vector2(160, 130), Color.Black);
                    spriteBatch.DrawString(_largerFont, _time.ToString(), new Vector2(380, 200), Color.Black);
                }

                if (_winnerFound)
                {
                    if (_winner == _player01)
                    {
                        spriteBatch.DrawString(_largeFont, "Winner!", new Vector2(10, 82), Color.Gold);
                    }
                    else if (_winner == _player02)
                    {
                        spriteBatch.DrawString(_largeFont, "Winner!", new Vector2(550, 82), Color.Gold);
                    }
                    spriteBatch.DrawString(_largeFont, "Returning to main menu", new Vector2(200, 130), Color.Black);
                    spriteBatch.DrawString(_largerFont, _time.ToString(), new Vector2(380, 200), Color.Black);
                }
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (_isInLoop)
            {
                _map.Update(gameTime, _components);
                for (int i = 1; i <= _components.Count; i++)
                {
                    Component currentComponent = _components.SearchList(i);
                    currentComponent.Update(gameTime, _components);
                }

                // check for winner
                if (!_winnerFound && !_isRespawning)
                {
                    _winner = CheckForWinner();

                    if (_winner != null)
                    {
                        _winnerFound = true;
                        _winner.IsAlive = false;
                        _winner.Opponent.IsAlive = false;

                        End();
                    }
                }

                // check for deaths of either player
                if (!_deathFound && _eliminatedPlayer == null)
                {
                    _eliminatedPlayer = CheckForDeath();

                    if (_eliminatedPlayer != null)
                    {
                        _deathFound = true;
                        _eliminatedPlayer.IsAlive = false;

                        // update deaths total of eliminated player
                        if (_eliminatedPlayer.Account != null)
                        {
                            // this if statement is for AI players who do not have accounts. In
                            // this case, account is null. If the eliminated player was an actual
                            // person, then their account is used in the statement below.
                            _eliminatedPlayer.Account.Deaths++;
                        }

                        // update points, health, and elimination total of eliminator
                        _eliminatedPlayer.Opponent.GrantSiphon();
                        if (_eliminatedPlayer.Opponent is not AITemplate)
                        {
                            _eliminatedPlayer.Opponent.Account.Eliminations++;
                        }

                        // begin respawn timer
                        _time = 5;
                        _timer = new System.Timers.Timer();
                        _timer.Interval = 1000;
                        _timer.Elapsed += _respawnTimer_Elapsed;
                        _timer.Start();
                        _isRespawning = true;
                    }
                }
            }
        }

        public virtual void Begin()
        {
            _winner = null;

            _player01.Opponent = _player02;
            _player01.Position = _player01.StartingPosition;

            _player02.Opponent = _player01;
            _player02.Position = _player02.StartingPosition;

            _components.AddNodeToFront(_player01);
            _components.AddNodeToFront(_player02);

            _time = 5;
            _timer = new System.Timers.Timer();
            _timer.Elapsed += _startTimer_Elapsed;
            _timer.Interval = 1000;
            _timer.Start();
        }

        private void End()
        {
            _player01.Account.RoundsPlayed++;
            _player02.Account.RoundsPlayed++;
            _winner.Account.Wins++;
            _winner.Account.Coins += 50;
            _winner.Account.XP += 300;

            _game.Database.UpdateAccount(_player01.Account);
            _game.Database.UpdateAccount(_player02.Account);

            _time = 5;
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _endTimer_Elapsed;
            _timer.Start();
        }

        protected virtual Player CheckForWinner()
        {
            // returns the winner if one if found
            if (_player01.Points >= 3000)
            {
                return _player01;
            }
            if (_player02.Points >= 3000)
            {
                return _player02;
            }

            return null;
        }

        protected virtual Player CheckForDeath()
        {
            // returns the eliminated player if one if found
            if (_player01.Health <= 0)
            {
                return _player01;
            }
            if (_player02.Health <= 0)
            {
                return _player02;
            }

            return null;
        }

        #region timers

        protected void _startTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _time--;
            if (_time == 0)
            {
                _isInLoop = true;
                _timer.Stop();
            }
        }

        protected void _endTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _time--;
            if (_time == 0)
            {
                _isInLoop = false;

                var mainMenuState = _game.States.Pop();
                mainMenuState = _game.States.Pop();
                mainMenuState = _game.States.Pop();
                mainMenuState = _game.States.Pop();
                _game.ChangeState(mainMenuState);             

                _timer.Stop();
            }
        }

        protected virtual void _respawnTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _time--;
            if (_time == 0)
            {
                // reset eliminated player
                _eliminatedPlayer.IsAlive = true;
                _eliminatedPlayer.Health = 200;

                _deathFound = false;
                _isRespawning = false;

                // reset positions of both players to starting positions
                _player01.Position = new Vector2(_player01.StartingPosition.X, _player01.StartingPosition.Y + 80);
                _player02.Position = new Vector2(_player02.StartingPosition.X, _player02.StartingPosition.Y + 80);

                _eliminatedPlayer = null;

                _timer.Stop();
            }
        }

        #endregion timers
    }
}

