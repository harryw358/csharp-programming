using System;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.UI.RoundUI
{
    public class PointsBar : ValueBar
    {
        public PointsBar(Dictionary<string, Texture2D> textures, SpriteFont font, Player player, Vector2 barPosition, Vector2 numValuePosition) : base(textures, font, player, barPosition, numValuePosition)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(_font, _player.Points.ToString(), _numValuePosition, Color.Black);
        }

        public override void Update(GameTime gameTime, CustomLinkedList _components)
        {
            if (_player.Points < 1000 && _player.Points >= 0)
            {
                _currentTexture = _textures["empty"];
            }
            else if (_player.Points < 2000 && _player.Points >= 1000)
            {
                _currentTexture = _textures["1/3"];
            }
            else if (_player.Health < 3000 && _player.Points >= 2000)
            {
                _currentTexture = _textures["2/3"];
            }
            else if (_player.Points >= 3000)
            {
                _currentTexture = _textures["full"];
            }
        }
    }
}

