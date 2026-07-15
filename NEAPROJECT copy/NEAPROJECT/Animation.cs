using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEAPROJECT
{
    public class Animation
    {
        private Texture2D _texture;
        private int _currentFrame;
        private int _count;
        private double _speed;
        private bool _isLooping;
        private int _height;
        private int _width;

        public Texture2D Texture { get => _texture; set => _texture = value; }
        public int CurrentFrame { get => _currentFrame; set => _currentFrame = value; }
        public int Count { get => _count; set => _count = value; }
        public double Speed { get => _speed; set => _speed = value; }
        public bool IsLooping { get => _isLooping; set => _isLooping = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }

        public Animation(Texture2D texture, int count, double speed)
        {
            _texture = texture;
            _count = count;
            _isLooping = true;
            _speed = speed;

            _height = _texture.Height;
            _width = _texture.Width / _count;
        }
    }
}
