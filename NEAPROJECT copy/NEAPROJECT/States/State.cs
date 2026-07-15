using System;
namespace NEAPROJECT.States
{
    public abstract class State
    {
        protected ContentManager _content;
        protected Game1 _game;
        protected GraphicsDevice _graphicsDevice;

        public State(ContentManager content, Game1 game, GraphicsDevice graphicsDevice)
        {
            _content = content;
            _game = game;
            _graphicsDevice = graphicsDevice;
        }

        // drawing components onto screen
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        // updating components
        public abstract void Update(GameTime gameTime);
    }
}

