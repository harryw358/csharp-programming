using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Enumerations;
using NEAPROJECT.Maps;

namespace NEAPROJECT.States
{
    public class SelectMapState : Menu
    {
        private Enumerations.Map _currentlySelectedMap;
        private Button[] _mapSelection;
        private Button _btnNext;
        private Button _btnPrevious;
        private int _index;

        public SelectMapState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            LoadContent(content);
            _game.States.Push(this);
        }

        protected override void LoadContent(ContentManager content)
        {
            var btnNormal = new Button(content.Load<Texture2D>("MapIcons/normal"), content.Load<SpriteFont>("Fonts/Font"));
            btnNormal.Text = "Normal";
            btnNormal.Position = new Vector2(120, 100);
            btnNormal.IsVisible = false;
            btnNormal.Click += BtnNormal_Click;

            var btnANormalDayInTheUK = new Button(content.Load<Texture2D>("MapIcons/anormaldayintheuk"), content.Load<SpriteFont>("Fonts/Font"));
            btnANormalDayInTheUK.Text = "A Normal Day in the UK";
            btnANormalDayInTheUK.Position = new Vector2(120, 100);
            btnANormalDayInTheUK.IsVisible = false;
            btnANormalDayInTheUK.Click += BtnANormalDayInTheUK_Click;


            var btnAVeryScaryBasement = new Button(content.Load<Texture2D>("MapIcons/averyscarybasement"), content.Load<SpriteFont>("Fonts/Font"));
            btnAVeryScaryBasement.Text = "A Very Scary Basement";
            btnAVeryScaryBasement.Position = new Vector2(120, 100);
            btnAVeryScaryBasement.IsVisible = false;
            btnAVeryScaryBasement.Click += BtnAVeryScaryBasement_Click;

            _mapSelection = new Button[3]
            {
                btnNormal,
                btnANormalDayInTheUK,
                btnAVeryScaryBasement
            };

            _btnNext = new Button(content.Load<Texture2D>("Controls/button_small"), content.Load<SpriteFont>("Fonts/small_font"));
            _btnNext.Text = ">";
            _btnNext.Position = new Vector2(520, 420);
            _btnNext.Click += _next_Click;

            _btnPrevious = new Button(content.Load<Texture2D>("Controls/button_small"), content.Load<SpriteFont>("Fonts/small_font"));
            _btnPrevious.Text = "<";
            _btnPrevious.Position = new Vector2(120, 420);
            _btnPrevious.Click += _previous_Click;

            _components = new CustomLinkedList();
            _components.AddNodeToFront(btnNormal);
            _components.AddNodeToFront(btnANormalDayInTheUK);
            _components.AddNodeToFront(btnAVeryScaryBasement);
            _components.AddNodeToFront(_btnNext);
            _components.AddNodeToFront(_btnPrevious);

            _index = 0;
            _mapSelection[_index].IsVisible = true;
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            _currentlySelectedMap = Enumerations.Map.Normal;

            _game.RoundState.Map = new Maps.Map(Enumerations.Map.Normal, _content.Load<Texture2D>("Backgrounds/normal"), MapEffect.None, _game.RoundState);
            _game.ChangeState(_game.RoundState);
            _game.RoundState.Begin();
        }

        private void BtnANormalDayInTheUK_Click(object sender, EventArgs e)
        {
            _currentlySelectedMap = Enumerations.Map.ANormalDayInTheUK;

            _game.RoundState.Map = new Maps.Map(Enumerations.Map.Normal, _content.Load<Texture2D>("Backgrounds/anormaldayintheuk"), MapEffect.Wind, _game.RoundState);
            _game.ChangeState(_game.RoundState);
            _game.RoundState.Begin();

        }

        private void BtnAVeryScaryBasement_Click(object sender, EventArgs e)
        {
            _currentlySelectedMap = Enumerations.Map.AVeryScaryBasement;

            _game.RoundState.Map = new Maps.Map(Enumerations.Map.Normal, _content.Load<Texture2D>("Backgrounds/averyscarybasement"), MapEffect.Dark, _game.RoundState);
            _game.ChangeState(_game.RoundState);
            _game.RoundState.Begin();
        }

        private void _next_Click(object sender, EventArgs e)
        {
            if (_index == 2)
            {
                _mapSelection[_index].IsVisible = false;
                _index = 0;

                // this selection statement prevents the index going outside the bounds of the array - for
                // example if the index is 2 and the player presses 'next' then the index will be assigned the
                // value of 0 instead of 3
            }
            else
            {
                _mapSelection[_index].IsVisible = false;
                _index++;
            }
            _mapSelection[_index].IsVisible = true;

            // makes the map with index of _index visible to it is displayed on the screen
        }

        private void _previous_Click(object sender, EventArgs e)
        {
            if (_index == 0)
            {
                _mapSelection[_index].IsVisible = false;
                _index = 2;

                // this selection statement prevents the index going outside the bounds of the array - for
                // example if the index is 0 and the player presses 'previous' then the index will be assigned the
                // value of 2 instead of -1
            }
            else
            {
                _mapSelection[_index].IsVisible = false;
                _index--;
            }
            _mapSelection[_index].IsVisible = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            for (int i = 1; i <= _components.Count; i++)
            {
                Component currentComponent = _components.SearchList(i);
                if (currentComponent.IsVisible)
                {
                    currentComponent.Draw(spriteBatch);
                }
            }
            spriteBatch.DrawString(_largeFont, "Select map", new Vector2(300, 10), Color.Black);
            _btnBack.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 1; i <= _components.Count; i++)
            {
                Component currentComponent = _components.SearchList(i);
                if (currentComponent.IsVisible)
                {
                    currentComponent.Update(gameTime, _components);
                }
            }
            _btnBack.Update(gameTime, _components);

            //base.Update(gameTime);
        }
    }
}

