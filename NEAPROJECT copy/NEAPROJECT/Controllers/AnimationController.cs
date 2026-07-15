using NEAPROJECT.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEAPROJECT.Controllers
{
    public class AnimationController
    {
        private Animation _animation;
        private float _elapsedTime;
        private Vector2 _position;
        private Sprite _sprite;

        public Animation Animation { get => _animation; set => _animation = value; }
        public float ElapsedTime { get => _elapsedTime; set => _elapsedTime = value; }
        public Vector2 Position { get => _position; set => _position = value; }

        public AnimationController(Animation animation, Sprite sprite)
        {
            _animation = animation;
            _sprite = sprite;
        }

        public void PlayAnimator(Animation animation)
        {
            if (_animation == animation)
            {
                return;
            }
            else
            {
                _animation = animation;
                _animation.CurrentFrame = 0;
                _elapsedTime = 0f;
            }
        }

        public void StopAnimator()
        {
            _elapsedTime = 0f;
            _animation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsedTime > _animation.Speed * 1000)
            {
                _elapsedTime = 0f;
                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.Count)
                {
                    _animation.CurrentFrame = 0;
                    _sprite.InAnimationLock = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture, _position, new Rectangle(_animation.CurrentFrame * _animation.Width, 0, _animation.Width, _animation.Height), _sprite.Colour);
        }
    }
}
