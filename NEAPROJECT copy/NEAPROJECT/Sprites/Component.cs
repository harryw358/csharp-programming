using NEAPROJECT.CustomLinkedLists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEAPROJECT
{
    public abstract class Component
    {
        protected bool _isVisible;
        protected string _name;
        protected Vector2 _position;

        public bool IsVisible { get => _isVisible; set => _isVisible = value; }

        public string Name { get => _name; set => _name = value; }

        public virtual Vector2 Position { get => _position; set => _position = value; }

        public abstract void Update(GameTime gameTime, CustomLinkedList _components);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}