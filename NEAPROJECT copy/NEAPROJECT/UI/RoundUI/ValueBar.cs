    using System;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.UI.RoundUI
{
    public class ValueBar : Component
    {
        protected Texture2D _currentTexture;
        protected Dictionary<string, Texture2D> _textures;
        protected SpriteFont _font;
        protected Player _player;
        protected Vector2 _barPosition;
        protected Vector2 _numValuePosition;

        public Player Player { get => _player; }

        public ValueBar(Dictionary<string, Texture2D> textures, SpriteFont font, Player player, Vector2 barPosition, Vector2 numValuePosition) : base()
        {
            _textures = textures;
            _font = font;
            _player = player;
            _barPosition = barPosition;
            _numValuePosition = numValuePosition;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_currentTexture, _barPosition, Color.White);
        }

        public override void Update(GameTime gameTime, CustomLinkedList _components)
        {
            throw new NotImplementedException();
        }
    }
}

