using System;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.UI.RoundUI
{
    public class HealthBar : ValueBar
    {
        public HealthBar(Dictionary<string, Texture2D> textures, SpriteFont font, Player player, Vector2 barPosition, Vector2 numValuePosition) : base(textures, font, player, barPosition, numValuePosition)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (_player.Health > 30)
            {
                spriteBatch.DrawString(_font, _player.Health.ToString(), _numValuePosition, Color.Black);
            }
            else if (_player.Health < 30 && _player.Health > 0)
            {
                spriteBatch.DrawString(_font, _player.Health.ToString(), _numValuePosition, Color.Red);
            }
            else if (_player.Health <= 0)
            {
                spriteBatch.DrawString(_font, "Dead", _numValuePosition, Color.Red);
            }
        }

        public override void Update(GameTime gameTime, CustomLinkedList _components)
        {
            if (_player.Health <= 200 && _player.Health >= 167)
            {
                _currentTexture = _textures["full"];
            }
            else if (_player.Health < 167 && _player.Health >= 133)
            {
                _currentTexture = _textures["5/6"];
            }
            else if (_player.Health < 133 && _player.Health >= 100)
            {
                _currentTexture = _textures["4/6"];
            }
            else if (_player.Health < 100 && _player.Health >= 67)
            {
                _currentTexture = _textures["3/6"];
            }
            else if (_player.Health < 67 && _player.Health >= 33)
            {
                _currentTexture = _textures["2/6"];
            }
            else if (_player.Health < 33 && _player.Health > 0)
            {
                _currentTexture = _textures["1/6"];
            }
            else if (_player.Health <= 0)
            {
                _currentTexture = _textures["empty"];
            }
        }
    }
}

