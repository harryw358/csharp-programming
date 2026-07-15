using System;
using NEAPROJECT.CustomLinkedLists;
using static System.Net.Mime.MediaTypeNames;

namespace NEAPROJECT.Sprites
{
    public class Cell : Component
    {
        private Texture2D _texture;
        private SpriteFont _font;
        private Color _colour;
        private string _value;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public Cell(Texture2D texture, SpriteFont font, Color colour, string value) : base()
        {
            _texture = texture;
            _font = font;
            _colour = colour;
            _value = value;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, _colour);

            if (!string.IsNullOrEmpty(_value))
            {
                var x = Rectangle.X + (Rectangle.Width / 2) - (_font.MeasureString(_value).X / 2);
                var y = Rectangle.Y + (Rectangle.Height / 2) - (_font.MeasureString(_value).Y / 2);

                spriteBatch.DrawString(_font, _value, new Vector2(x, y), Color.Black);
            }
        }

        public override void Update(GameTime gameTime, CustomLinkedList _components)
        {
            return;
        }
    }
}

