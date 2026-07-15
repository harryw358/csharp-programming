using NEAPROJECT.CustomLinkedLists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NEAPROJECT.UI.MenuUI
{
    public class ItemSlot : Component
    {
        private Texture2D _icon;
        private string _label;
        private SpriteFont _font;
        private string _textPlaceholder;

        private bool _isHovering;
        private bool _isClicked;
        private MouseState _currentMouse;
        private MouseState _previousMouse;

        public Texture2D Icon { get => _icon; set => _icon = value; }
        public string Label { get => _label; set => _label = value; }
        public SpriteFont Font { get => _font; set => _font = value; }
        public string TextPlaceholder { get => _textPlaceholder; set => _textPlaceholder = value; }
        public bool IsHovering { get => _isHovering; set => _isHovering = value; }
        public bool IsClicked { get => _isClicked; set => _isClicked = value; }
        public event EventHandler Click;

        // RETURNS A BRAND NEW RECTANGLE WITH UPDATED POSITION EVERY TIME IT IS CALLED
        private Rectangle _rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _icon.Width, _icon.Height);
            }
        }

        public ItemSlot(Texture2D icon, SpriteFont font, bool isVisible)
        {
            _icon = icon;
            _font = font;

            _isVisible = isVisible;
        }

        public override void Update(GameTime gameTime, CustomLinkedList _components)
        {
            if (_isVisible)
            {
                _previousMouse = _currentMouse;
                _currentMouse = Mouse.GetState();

                Rectangle mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

                _isHovering = false;

                if (mouseRectangle.Intersects(_rectangle))
                {
                    _isHovering = true;

                    if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                    {
                        Click?.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_isVisible)
            {
                Color colour = Color.White;
                if (_isHovering)
                {
                    colour = Color.Gray;
                }
                // DRAWS THE ICON
                spriteBatch.Draw(_icon, _position, _rectangle, colour);
                // DRAWS THE NAME LABEL OF ICON
                spriteBatch.DrawString(_font, _label, new Vector2(_position.X, _position.Y + _icon.Height + 20), Color.Black);
                // PLACEHOLDERS FOR ICONS
                if (!string.IsNullOrEmpty(_textPlaceholder))
                {
                    var x = _rectangle.X + (_rectangle.Width / 2) - (_font.MeasureString(_textPlaceholder).X / 2);
                    var y = _rectangle.Y + (_rectangle.Height / 2) - (_font.MeasureString(_textPlaceholder).Y / 2);

                    spriteBatch.DrawString(_font, _textPlaceholder, new Vector2(x, y), Color.Black);
                }
            }
        }
    }
}
