using System;
using NEAPROJECT.Sprites;
using NEAPROJECT.Training;
using NEAPROJECT.UI.RoundUI;

namespace NEAPROJECT.States
{
    public class TrainingState : RoundState
    {
        private Player _player;
        private AITemplate _ai;

        public Player Player { get => _player; set => _player = value; }
        public AITemplate AI { get => _ai; set => _ai = value; }

        public TrainingState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {

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
                    if (_winner == _player)
                    {
                        spriteBatch.DrawString(_largeFont, "Winner!", new Vector2(10, 82), Color.Gold);
                    }
                    else if (_winner == _ai)
                    {
                        spriteBatch.DrawString(_largeFont, "Winner!", new Vector2(520, 82), Color.Gold);
                    }
                    spriteBatch.DrawString(_largeFont, "Returning to main menu", new Vector2(300, 130), Color.Black);
                    spriteBatch.DrawString(_largerFont, _time.ToString(), new Vector2(380, 200), Color.Black);
                }
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Begin()
        {
            _winner = null;

            _player.Opponent = _ai;
            _player.Position = _player.StartingPosition;

            _ai.Opponent = _player;
            _ai.Position = _ai.StartingPosition;

            _components.AddNodeToFront(_player);
            _components.AddNodeToFront(_ai);

            _time = 5;
            _timer = new System.Timers.Timer();
            _timer.Elapsed += _startTimer_Elapsed;
            _timer.Interval = 1000;
            _timer.Start();
        }

        protected override Player CheckForDeath()
        {
            // returns the eliminated player if one if found
            if (_player.Health <= 0)
            {
                return _player;
            }
            if (_ai.Health <= 0)
            {
                return _ai;
            }

            return null;
        }

        protected override Player CheckForWinner()
        {
            // returns the winner if one if found
            if (_player.Points >= 3000)
            {
                return _player;
            }
            if (_ai.Points >= 3000)
            {
                return _ai;
            }

            return null;
        }

        #region timers

        protected override void _respawnTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _time--;
            if (_time == 0)
            {
                // reset eliminated player
                _eliminatedPlayer.IsAlive = true;
                if (_eliminatedPlayer is EasyAI || _eliminatedPlayer is MediumAI)
                {
                    if (_eliminatedPlayer is EasyAI)
                    {
                        _eliminatedPlayer.Health = 100;
                    }
                    else if ( _eliminatedPlayer is MediumAI)
                    {
                        _eliminatedPlayer.Health = 150;
                    }
                }
                else
                {
                    _eliminatedPlayer.Health = 200;
                }

                _deathFound = false;
                _isRespawning = false;

                // reset positions of both players to starting positions
                _player.Position = _player.StartingPosition;
                _ai.Position = _ai.StartingPosition;

                _eliminatedPlayer = null;

                _timer.Stop();
            }
        }

        #endregion timers
    }
}

