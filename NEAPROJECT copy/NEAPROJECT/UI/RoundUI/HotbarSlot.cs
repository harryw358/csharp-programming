using System;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;
using NEAPROJECT.Enumerations;

namespace NEAPROJECT.UI.RoundUI
{
    public class HotbarSlot : Component
    {
        private Texture2D _mainTexture;
        private Texture2D _keybindTexture;
        private SpriteFont _font;
        private Color _colour;
        private string _keyBind;
        private Sprite _sprite;

        public Color Colour { get => _colour; set => _colour = value; }

        public HotbarSlot(Texture2D mainTexture, Texture2D keybindTexture, SpriteFont font, Vector2 position, Color colour, string keyBind, Sprite sprite) : base()
        {
            _mainTexture = mainTexture;
            _keybindTexture = keybindTexture;
            _font = font;
            _position = position;
            _colour = colour;
            _keyBind = keyBind;
            _sprite = sprite;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_mainTexture, _position, _colour);
            spriteBatch.Draw(_keybindTexture, new Vector2(_position.X + _mainTexture.Width - 35, _position.Y + _mainTexture.Height - 5), Color.White);
            spriteBatch.DrawString(_font, _keyBind, new Vector2(_position.X + _mainTexture.Width - 32, _position.Y + _mainTexture.Height - 3), Color.Black);
        }

        public override void Update(GameTime gameTime, CustomLinkedList _components)
        {
            if (_sprite is Weapon)
            {
                if (((Weapon)_sprite).IsEquipped)
                {
                    _colour = GetColour(((Weapon)_sprite).Owner.Class);
                }
                else
                {
                    _colour = Color.White;
                }
            }
            else if (_sprite is Shield)
            {
                if (((Shield)_sprite).IsEquipped)
                {
                    _colour = GetColour(((Shield)_sprite).Owner.Class);
                }
                else
                {
                    _colour = Color.White;
                }
            }
            else if (_sprite is HealingItem)
            {
                if (((HealingItem)_sprite).IsOnCooldown)
                {
                    _colour = Color.Red;
                }
                else
                {
                    _colour = Color.White;
                }
            }
        }

        private Color GetColour(Class _class)
        {
            switch (_class)
            {
                case Class.Melee:
                    return Color.Red;
                case Class.Mage:
                    return Color.Purple;
                case Class.Ranger:
                    return Color.Orange;
                default:
                    return Color.White;
            }
        }
    }
}

