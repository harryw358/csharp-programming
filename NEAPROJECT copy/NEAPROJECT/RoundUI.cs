//using System;
//using NEAPROJECT.Sprites;
//using NEAPROJECT.UI;
//using NEAPROJECT.UI.MatchUI;
//using NEAPROJECT.UI.MenuUI;
//using NEAPROJECT.CustomLinkedLists;

//namespace NEAPROJECT
//{
//    public class RoundUI : Game
//    {
//        private CustomLinkedList _roundComponents;

//        private HealthBar _player01HealthBar;
//        private HealthBar _player02HealthBar;
//        private ItemSlot _weaponSlot01;
//        private ItemSlot _weaponSlot02;
//        private ItemSlot _healingSlot01;
//        private ItemSlot _healingSlot02;
//        private ItemSlot _healingSlot03;
//        private string _roundCount;

//        public RoundUI()
//        {
//            _player01HealthBar = new HealthBar(Content.Load<Texture2D>("GameUI/healtpoints_bar"), _player, Content.Load<SpriteFont>("Fonts/Font"));
//            _player01HealthBar.Position = new Vector2(20, 20);
//            _player02HealthBar = new HealthBar(Content.Load<Texture2D>("GameUI/healtpoints_bar"), _player2, Content.Load<SpriteFont>("Fonts/Font"));
//            _player02HealthBar.Position = new Vector2(850, 20);

//            _weaponSlot01 = new ItemSlot(Content.Load<Texture2D>("Icons/item_slot_blank"), Content.Load<SpriteFont>("Fonts/small_font"), true);
//            _weaponSlot01.Position = new Vector2(20, 515);
//            _weaponSlot01.TextPlaceholder = "W1";
//            _weaponSlot01.Label = "WEAPON1";
//            _weaponSlot02 = new ItemSlot(Content.Load<Texture2D>("Icons/item_slot_blank"), Content.Load<SpriteFont>("Fonts/small_font"), true);
//            _weaponSlot02.Position = new Vector2(140, 515);
//            _weaponSlot02.TextPlaceholder = "W2";
//            _weaponSlot02.Label = "WEAPON2";

//            _healingSlot01 = new ItemSlot(Content.Load<Texture2D>("Icons/item_slot_blank"), Content.Load<SpriteFont>("Fonts/small_font"), true);
//            _healingSlot01.Position = new Vector2(20, 655);
//            _healingSlot01.TextPlaceholder = "H1";
//            _healingSlot01.Label = "HEALING1";
//            _healingSlot02 = new ItemSlot(Content.Load<Texture2D>("Icons/item_slot_blank"), Content.Load<SpriteFont>("Fonts/small_font"), true);
//            _healingSlot02.Position = new Vector2(140, 655);
//            _healingSlot02.TextPlaceholder = "H2";
//            _healingSlot02.Label = "HEALING2";
//            _healingSlot03 = new ItemSlot(Content.Load<Texture2D>("Icons/item_slot_blank"), Content.Load<SpriteFont>("Fonts/small_font"), true);
//            _healingSlot03.Position = new Vector2(260, 655);
//            _healingSlot03.TextPlaceholder = "H3";
//            _healingSlot03.Label = "HEALING3";

//            _roundComponents = new CustomLinkedList();
//            _roundComponents.AddNodeToFront(_player01HealthBar);
//            _roundComponents.AddNodeToFront(_player02HealthBar);
//            _roundComponents.AddNodeToFront(_weaponSlot01);
//            _roundComponents.AddNodeToFront(_weaponSlot02);
//            _roundComponents.AddNodeToFront(_healingSlot01);
//            _roundComponents.AddNodeToFront(_healingSlot02);
//            _roundComponents.AddNodeToFront(_healingSlot03);
//        }
//    }
//}

