//using System;
//using Microsoft.Xna.Framework.Audio;
//using NEAPROJECT.CustomLinkedLists;
//using NEAPROJECT.Sprites;
//using NEAPROJECT.Maps;
//using NEAPROJECT.Core;
//using NEAPROJECT.Enumerations;
//using NEAPROJECT.Backend;
//using NEAPROJECT.Training;
//using NEAPROJECT.UI.MatchUI;
//using NEAPROJECT.UI.MenuUI;
//using NEAPROJECT.Controls;

//namespace NEAPROJECT.GameLogic
//{
//    public class Round : Game
//    {
//        private GraphicsDeviceManager _graphics;
//        private SpriteBatch _spriteBatch;
//        private CustomLinkedList _roundComponents;
//        private Player[] _players;
//        private Account _account;
//        private Map _map;
//        private string _mapChoiceName;
//        private static int[] _screenDimensions;
//        // ROUND UI
//        private HealthBar _player01HealthBar;
//        private HealthBar _player02HealthBar;
//        private PointsTray _pointsTray;
//        private ItemSlot _weaponSlot01;
//        private ItemSlot _weaponSlot02;
//        private Button _healingSlot01;
//        private Button _healingSlot02;

//        public Player[] Players { get => _players; set => _players = value; }
//        public PointsTray PointsTray { get => _pointsTray; }

//        public static int[] ScreenDimensions { get => _screenDimensions; set => _screenDimensions = value; }

//        public Round(string mapChoiceName, Account account)
//        {
//            _graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//            IsMouseVisible = true;

//            _mapChoiceName = mapChoiceName;
//            _account = account;
//        }

//        protected override void Initialize()
//        {
//                                          //WIDTH //HEIGHT
//            _screenDimensions = new int[2] { 1400, 800 };

//            _graphics.PreferredBackBufferHeight = _screenDimensions[1];
//            _graphics.PreferredBackBufferWidth = _screenDimensions[0];
//            _graphics.ApplyChanges();

//            base.Initialize();
//        }

//        protected override void LoadContent()
//        {
//            _spriteBatch = new SpriteBatch(GraphicsDevice);
//            _roundComponents = new CustomLinkedList();
//            _players = new Player[2];
//            _players = LoadPlayers();
//            _roundComponents.AddNodeToFront(_players[0]);
//            _roundComponents.AddNodeToFront(_players[1]);
//            LoadMap(_mapChoiceName);
//            LoadRoundUI();

//            // testing AI

//            //var AI_animations = new Dictionary<string, Animation>();
//            //AI_animations.Add("Right", new Animation(Content.Load<Texture2D>("Animations/colours"), 3));
//            //AI_animations.Add("Left", new Animation(Content.Load<Texture2D>("Animations/colours"), 3));

//            //var easyAI = new EasyAI(AI_animations, this);
//            //easyAI.RequiresCollisionDetection = true;
//            //easyAI.Speed = 10;
//            //easyAI.Position = new Vector2(800, 0);
//            //easyAI.Input = null;
//            //_roundComponents.AddNodeToFront(easyAI);
//        }

//        private Player[] LoadPlayers()
//        {
//            var player01Animations = new Dictionary<string, Animation>();
//            player01Animations.Add("Right", new Animation(Content.Load<Texture2D>("Animations/colours"), 3));
//            player01Animations.Add("Left", new Animation(Content.Load<Texture2D>("Animations/colours"), 3));

//            var player02Animations = new Dictionary<string, Animation>();
//            player02Animations.Add("Right", new Animation(Content.Load<Texture2D>("Animations/colours"), 3));
//            player02Animations.Add("Left", new Animation(Content.Load<Texture2D>("Animations/colours"), 3));

//            Player player01 = new Player(player01Animations, null, _account);
//            player01.RequiresCollisionDetection = true;
//            player01.Speed = 10;
//            player01.Position = new Vector2(400, 10);
//            player01.Input = new Input();
//            player01.Input.Left = Keys.A;
//            player01.Input.Right = Keys.D;
//            player01.Input.Jump = Keys.Space;
//            player01.Input.Attack = Keys.LeftShift;
//            // ADDING COMPONENTS TO A PLAYER LIKE WEAPONS
//            //Firearm weapon = new Firearm(Content.Load<Texture2D>("Weapons/weapon"), null, Content.Load<SoundEffect>("Sounds/lasershoot"));
//            //weapon.Ammunition = new Ammunition(Content.Load<Texture2D>("Weapons/ammunition"), null);
//            //weapon.Input = new Input();
//            //weapon.Input.Attack = Keys.RightShift;
//            //weapon.Player = player01;
//            //weapon.Position = player01.Position;
//            //weapon.Damage = 5;
//            //player01.AddFirearm(weapon);

//            Player player02 = new Player(player02Animations, null, new Account(0, 0, "Player 2", "test", 0, 0));
//            player02.RequiresCollisionDetection = true;
//            player02.Speed = 10;
//            player02.Position = new Vector2(800, 0);
//            player02.Input = new Input();
//            player02.Input.Left = Keys.Left;
//            player02.Input.Right = Keys.Right;
//            player02.Input.Jump = Keys.Up;
//            player02.Input.Attack = Keys.L;
//            // ADDING COMPONENTS TO A PLAYER LIKE WEAPONS
//            //Firearm weapon2 = new Firearm(Content.Load<Texture2D>("Weapons/weapon"), null, Content.Load<SoundEffect>("Sounds/lasershoot"));
//            //weapon2.Ammunition = new Ammunition(Content.Load<Texture2D>("Weapons/ammunition"), null);
//            //weapon2.Input = new Input();
//            //weapon2.Input.Attack = Keys.L;
//            //weapon2.Player = player02;
//            //weapon2.Position = player02.Position;
//            //weapon2.Damage = 5;
//            //player02.AddFirearm(weapon2);


//            // DECLARING OPPONENTS 
//            player01.Opponent = player02;
//            player02.Opponent = player01;

//            Player[] players = new Player[2] { player01, player02 };
//            return players;
//        }

//        private void LoadMap(string mapName)
//        {
//            switch (mapName)
//            {
//                case "A Normal Day in the UK":
//                    _map = new Map(mapName, Content.Load<Texture2D>("Backgrounds/anormaldayinuk"), MapEffect.Wind);
//                    break;
//                case "An Australian July":
//                    _map = new Map(mapName, Content.Load<Texture2D>("Backgrounds/anaustralianjulymap"), MapEffect.Ice);
//                    break;
//                case "A Very Scary Basement":
//                    _map = new Map(mapName, Content.Load<Texture2D>("Backgrounds/averyscarybasementmap"), MapEffect.Dark);
//                    break;
//            }
//        }

//        private void LoadRoundUI()
//        {
//            // HEALTH BARS FOR BOTH PLAYERS
//            _player01HealthBar = new HealthBar(Content.Load<Texture2D>("GameUI/healthbar"), _players[0], Content.Load<SpriteFont>("Fonts/Font"));
//            _player01HealthBar.Position = new Vector2(20, 20);
//            _player02HealthBar = new HealthBar(Content.Load<Texture2D>("GameUI/healthbar"), _players[1], Content.Load<SpriteFont>("Fonts/Font"));
//            _player02HealthBar.Position = new Vector2(880, 20);

//            // POINTS TRAY
//            _pointsTray = new PointsTray(Content.Load<Texture2D>("GameUI/pointstray"), Content.Load<SpriteFont>("Fonts/Font"));
//            _pointsTray.Position = new Vector2(400, 760);

//            // WEAPON ITEM SLOTS
//            _weaponSlot01 = new ItemSlot(Content.Load<Texture2D>("Icons/item_slot_blank"), Content.Load<SpriteFont>("Fonts/small_font"), true);
//            _weaponSlot01.Position = new Vector2(20, 200);
//            _weaponSlot01.TextPlaceholder = "W1";
//            _weaponSlot01.Label = "WEAPON1";
//            _weaponSlot02 = new ItemSlot(Content.Load<Texture2D>("Icons/item_slot_blank"), Content.Load<SpriteFont>("Fonts/small_font"), true);
//            _weaponSlot02.Position = new Vector2(20, 320);
//            _weaponSlot02.TextPlaceholder = "W2";
//            _weaponSlot02.Label = "WEAPON2";

//            // HEALING ITEM SLOTS
//            _healingSlot01 = new Button(Content.Load<Texture2D>("Consumables/small_healing"), Content.Load<SpriteFont>("Fonts/small_font"));
//            _healingSlot01.Position = new Vector2(20, 440);
//            _healingSlot01.Text = "H1";
//            _healingSlot01.Click += _healingSlot01_Click;
//            _healingSlot02 = new Button(Content.Load<Texture2D>("Consumables/large_healing"), Content.Load<SpriteFont>("Fonts/small_font"));
//            _healingSlot02.Position = new Vector2(20, 560);
//            _healingSlot02.Text = "H2";
//            _healingSlot02.Click += _healingSlot02_Click;

//            _roundComponents = new CustomLinkedList();
//            _roundComponents.AddNodeToFront(_player01HealthBar);
//            _roundComponents.AddNodeToFront(_player02HealthBar);
//            _roundComponents.AddNodeToFront(_pointsTray);
//            _roundComponents.AddNodeToFront(_weaponSlot01);
//            _roundComponents.AddNodeToFront(_weaponSlot02);
//            _roundComponents.AddNodeToFront(_healingSlot01);
//            _roundComponents.AddNodeToFront(_healingSlot02);
//        }

//        private void _healingSlot01_Click(object sender, EventArgs e)
//        {
//            //_players[0].Heal();
//        }

//        private void _healingSlot02_Click(object sender, EventArgs e)
//        {
//            //_players[0].Heal()
//        }

//        protected override void Update(GameTime gameTime)
//        {
//            // REQUIRED CODE FOR MONOGAME TO FUNCTION
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
//                Exit();
//            //

//            _players[0].Update(gameTime, _roundComponents);
//            _players[1].Update(gameTime, _roundComponents);

//            if (_players[0].Score > 3 || _players[1].Score > 3)
//            {
//                EndRound();
//            }

//            for (int i = 1; i <= _roundComponents.Count; i++)
//            {
//                Component currentComponent = _roundComponents.SearchList(i);
//                currentComponent.Update(gameTime, _roundComponents);
//            }
//            //_camera.Follow((Sprite)_gameComponents.SearchList(1));
//            base.Update(gameTime);
//        }

//        protected override void Draw(GameTime gameTime)
//        {
//            // BACKGROUND COLOUR
//            GraphicsDevice.Clear(Color.White);

//            _spriteBatch.Begin();// transformMatrix: _camera.Transform);
//            _map.Draw(_spriteBatch);
//            _players[0].Draw(_spriteBatch);
//            _players[1].Draw(_spriteBatch);
//            for (int i = 1; i <= _roundComponents.Count; i++)
//            {
//                Component currentComponent = _roundComponents.SearchList(i);
//                currentComponent.Draw(_spriteBatch);
//            }
//            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts/Font"), _players[0].Points.ToString(), new Vector2(530, 23), Color.Black);
//            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts/Font"), _players[1].Points.ToString(), new Vector2(850, 23), Color.Black);
//            _spriteBatch.End();

//            //base.Draw(gameTime);
//        }

//        private void StartNewRound()
//        {
//            // INITIALISES PLAYER HEALTH, SCORE, AND POSITION
//            _players[0].Health = 200;
//            _players[1].Health = 200;

//            _players[0].Score = 0;
//            _players[1].Score = 0;

//            _players[0].Position = new Vector2(100, 300);
//            _players[1].Position = new Vector2(500, 300);
//        }

//        private void EndRound()
//        {
//            _players[0].Account.UpdateScores();
//            _players[1].Account.UpdateScores();
//        }
//    }
//}

