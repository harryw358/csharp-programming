using NEAPROJECT.CustomLinkedLists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NEAPROJECT.Controls
{
    public sealed class Textbox : Component
    {
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        private Texture2D _texture;
        private SpriteFont _font;
        private bool _isHovering;
        private bool _isClicked;
        private Color _penColour;
        private string _text;
        private string _asteriskText;
        private int _maxLength;
        private bool _isPassword;
        private bool _canListen;
        private Keys _previousKey;

        private List<Keys> _alphabet = new List<Keys>()
            {
                Keys.A,
                Keys.B,
                Keys.C,
                Keys.D,
                Keys.E,
                Keys.F,
                Keys.G,
                Keys.H,
                Keys.I,
                Keys.J,
                Keys.K,
                Keys.L,
                Keys.M,
                Keys.N,
                Keys.O,
                Keys.P,
                Keys.Q,
                Keys.R,
                Keys.S,
                Keys.T,
                Keys.U,
                Keys.V,
                Keys.W,
                Keys.X,
                Keys.Y,
                Keys.Z,
            };

        // unique to Textbox
        private StringBuilder _stringBuilder = new StringBuilder();
        private StringBuilder _asteriskStringBuilder = new StringBuilder();

        public event EventHandler Click;
        public bool IsHovering { get => _isHovering; set => _isHovering = value; }
        public bool IsClicked { get => _isClicked; set => _isClicked = value; }
        public Color PenColour { get => _penColour; set => _penColour = value; }
        public string Text { get => _text; set => _text = value; }
        public bool IsPassword { get => _isPassword; set => _isPassword = value; }

        public StringBuilder StringBuilder { get => _stringBuilder; set => _stringBuilder = value; }
        public StringBuilder AsteriskStringBuilder { get => _asteriskStringBuilder; set => _asteriskStringBuilder = value; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public Textbox(Texture2D texture, SpriteFont font, int maxLength)
        {
            _texture = texture;
            _font = font;
            _maxLength = maxLength;
            PenColour = Color.Black;
            _isVisible = true;
            _canListen = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color colour = Color.White;
            if (_isHovering)
            {
                colour = Color.Gray;
            }
            spriteBatch.Draw(_texture, Rectangle, colour);

            var textToDraw = "";

            if (!_isPassword)
            {
                textToDraw = _text;
            }
            else
            {
                textToDraw = _asteriskText;
            }

            if (!string.IsNullOrEmpty(textToDraw))
            {
                var x = Rectangle.X + (Rectangle.Width / 2) - (_font.MeasureString(textToDraw).X / 2);
                var y = Rectangle.Y + (Rectangle.Height / 2) - (_font.MeasureString(textToDraw).Y / 2);

                spriteBatch.DrawString(_font, textToDraw, new Vector2(x, y), PenColour);
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

            if (_isClicked)
            {
                if (_stringBuilder.Length <= _maxLength - 1)
                foreach (Keys key in _alphabet)
                {
                    if (Keyboard.GetState().IsKeyDown(key) && _canListen)
                    {
                        _previousKey = key;
                        _stringBuilder.Append(key.ToString());
                        _asteriskStringBuilder.Append('*');
                        _canListen = false;
                    }
                    if (Keyboard.GetState().IsKeyUp(_previousKey))
                    {
                        _canListen = true;
                    }
                }
            }
            if (!_isHovering && (_previousMouse.LeftButton == ButtonState.Pressed && _currentMouse.LeftButton == ButtonState.Pressed))
            {
                _isClicked = false;
            }

            _text = _stringBuilder.ToString();
            _asteriskText = _asteriskStringBuilder.ToString();
        }
    }
}
