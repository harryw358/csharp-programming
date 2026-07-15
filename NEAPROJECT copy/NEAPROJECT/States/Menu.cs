    using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;

namespace NEAPROJECT.States
{
    public abstract class Menu : State
    {
        protected Button _btnBack;
        protected CustomLinkedList _components;
        protected SpriteFont _smallerFont;
        protected SpriteFont _smallFont;
        protected SpriteFont _largeFont;
        protected System.Timers.Timer _errorTimer;
        protected int _errorTime;
        protected bool _errorOccurred;
        protected string _currentErrorMessage;
        protected bool _isShowingError;

        public Menu(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            LoadBackButton(content);
            _smallerFont = content.Load<SpriteFont>("Fonts/smaller_font");
            _smallFont = content.Load<SpriteFont>("Fonts/small_font");
            _largeFont = content.Load<SpriteFont>("Fonts/large_font");

            _errorTimer = new System.Timers.Timer();
            _errorTimer.Interval = 1000;
            _errorTimer.Elapsed += _errorTimer_Elapsed;
        }

        protected void _errorTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _isShowingError = true;
            _errorTime++;
            if (_errorTime == 3)
            {
                _currentErrorMessage = null;
                _isShowingError = false;
                _errorOccurred = false;
                _errorTimer.Stop();
            }
        }

        private void LoadBackButton(ContentManager content)
        {
            _btnBack = new Button(content.Load<Texture2D>("Controls/back_button"), content.Load<SpriteFont>("Fonts/Font"));
            _btnBack.Position = new Vector2(10, 10);
            _btnBack.Text = "<";
            _btnBack.Click += _btnBack_Click;
        }

        protected abstract void LoadContent(ContentManager content);

        private void _btnBack_Click(object sender, EventArgs e)
        {
            var previousState = _game.States.Pop();
            _game.ChangeState(previousState);
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
            if (this is not LaunchState)
            {
                _btnBack.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 1; i <= _components.Count; i++)
            {
                Component currentComponent = _components.SearchList(i);
                currentComponent.Update(gameTime, _components);
            }
            if (this is not LaunchState)
            {
                _btnBack.Update(gameTime, _components);
            }
        }
    }
}

