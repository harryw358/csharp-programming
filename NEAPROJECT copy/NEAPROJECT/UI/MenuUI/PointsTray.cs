using System;
using System.Timers;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.UI.MenuUI
{
    public class PointsTray : Component
    {
        private Texture2D _texture;
        private SpriteFont _font;
        private Rectangle _destinationRectangle;
        private Queue<string> _messageQueue;
        private string _currentMessage;
        private bool _currentMessageIsVisible = false;
        private int _timeLeft;
        private System.Timers.Timer _timer;

        public Queue<String> MessageQueue { get => _messageQueue; set => _messageQueue = value; }

        public PointsTray(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            _messageQueue = new Queue<string>();
            _currentMessage = "";

            _timeLeft = 3;

            _timer = new System.Timers.Timer(3000);
            _timer.Interval = 1000;
            _timer.Elapsed += Timer_Elapsed;
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            if (_messageQueue.Count != 0)
            {
                _currentMessage = _messageQueue.Dequeue();
                _currentMessageIsVisible = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _destinationRectangle, Color.White);
            if (_currentMessage != "" && _currentMessageIsVisible == true)
            {
                spriteBatch.DrawString(_font, _currentMessage, new Vector2(_position.X + 10, _position.Y + 10), Color.Black);
                _timer.Start();
            }
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            if (_timeLeft == 0)
            {
                _currentMessageIsVisible = false;
                _timer.Stop();
            }
            else
            {
                _timeLeft--;
            }
        }
    }
}

