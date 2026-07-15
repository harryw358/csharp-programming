using NEAPROJECT.CustomLinkedLists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace NEAPROJECT.Controls
{
    public class Button : Component
    {
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        private Texture2D _texture;
        private SpriteFont _font;
        private bool _isHovering;
        private bool _isClicked;
        private Color _penColour;
        private string _text;

        public Texture2D Texture { get => _texture; set => _texture = value; }
        public event EventHandler Click;
        public bool IsClicked { get => _isClicked; set => _isClicked = value; }
        public Color PenColour { get => _penColour; set => _penColour = value; }
        public string Text { get => _text; set => _text = value; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            _penColour = Color.Black;
            _isVisible = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color colour = Color.White;
            if (_isHovering)
            {
                colour = Color.Gray;
            }

            spriteBatch.Draw(_texture, Rectangle, colour);

            if (_text != null)
            {
                var x = Rectangle.X + (Rectangle.Width / 2) - (_font.MeasureString(_text).X / 2);
                var y = Rectangle.Y + (Rectangle.Height / 2) - (_font.MeasureString(_text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), _penColour);
            }
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
