using System;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Enumerations;
using NEAPROJECT.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NEAPROJECT.Maps
{
    public class Map
    {
        private RoundState _roundState;
        private Enumerations.Map _name;
        private Texture2D _background;
        private MapEffect _uniqueEffect;
        private Vector2 _leftBarrier;
        private Vector2 _rightBarrier;
        private bool _canDrawMap;
        private CustomLinkedList _mapComponents;

        public Enumerations.Map Name { get => _name; set => _name = value; }
        public Texture2D Background { get => _background; set => _background = value; }
        public MapEffect UniqueEffect { get => _uniqueEffect; set => _uniqueEffect = value; }
        public Vector2 LeftBarrier { get => _leftBarrier; set => _leftBarrier = value; }
        public Vector2 RightBarrier { get => _rightBarrier; set => _rightBarrier = value; }

        private Rectangle _destinationRectangle
        {
            get
            {
                return new Rectangle(0, 0, _background.Width, _background.Height);
            }
        }

        public Map(Enumerations.Map name, Texture2D background, MapEffect uniqueEffect, RoundState roundState)
        {
            _name = name;
            _background = background;
            _uniqueEffect = uniqueEffect;
            _roundState = roundState;
            _canDrawMap = true;
            _mapComponents = new CustomLinkedList();
        }

        public void Update(GameTime gameTime, CustomLinkedList components)
        {
            switch (_uniqueEffect)
            {
                case MapEffect.None:
                    {
                        return;
                    }
                case MapEffect.Wind:
                    {
                        _roundState.Player01.Speed = 5;
                        _roundState.Player02.Speed = 5;
                    }
                    break;
                case MapEffect.Dark:
                    {
                        var random = new Random();
                        var rndNum = random.Next(100);

                        if (_canDrawMap)
                        {
                            if (rndNum % 10 == 0)
                            {
                                _canDrawMap = false;
                            }
                        }
                        rndNum = random.Next(100);
                        if (!_canDrawMap)
                        {
                            if (rndNum % 10 == 0)
                            {
                                _canDrawMap = true;
                            }
                        }
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);

            if (_canDrawMap)
            {
                spriteBatch.Draw(_background, _destinationRectangle, Color.White);
            }
        }
    }
}

