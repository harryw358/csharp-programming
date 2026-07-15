using System;
using NEAPROJECT.Controllers;
using NEAPROJECT.Controls;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Enumerations;
using NEAPROJECT.Sprites;
using NEAPROJECT.Training;
using NEAPROJECT.UI.RoundUI;

namespace NEAPROJECT.States
{
    public class SelectTrainingState : Menu
    {
        private Difficulty _currentlySelectedDifficulty;

        public SelectTrainingState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice) : base(content, game, graphicsDevice)
        {
            _game.States.Push(this);
            LoadContent(content);
        }

        protected override void LoadContent(ContentManager content)
        {
            var btnEasy = new Button(_content.Load<Texture2D>("Controls/button"), _content.Load<SpriteFont>("Fonts/Font"));
            btnEasy.Text = "Easy";
            btnEasy.Position = new Vector2(230, 100);
            btnEasy.Click += BtnEasy_Click;

            var btnMedium = new Button(_content.Load<Texture2D>("Controls/button"), _content.Load<SpriteFont>("Fonts/Font")); ;
            btnMedium.Text = "Medium";
            btnMedium.Position = new Vector2(230, 200);
            btnMedium.Click += BtnMedium_Click;

            var btnHard = new Button(_content.Load<Texture2D>("Controls/button"), _content.Load<SpriteFont>("Fonts/Font"));
            btnHard.Text = "Hard";
            btnHard.Position = new Vector2(230, 300);
            btnHard.Click += BtnHard_Click;

            _components = new CustomLinkedList();
            _components.AddNodeToFront(btnEasy);
            _components.AddNodeToFront(btnMedium);
            _components.AddNodeToFront(btnHard);
        }

        private void BtnEasy_Click(object sender, EventArgs e)
        {
            _currentlySelectedDifficulty = Difficulty.Easy;
            _game.TrainingState.AI = (EasyAI)CreateAI();

            var selectClassState = new SelectClassState(_content, _game, _graphicsDevice, "startTraining");
            _game.ChangeState(selectClassState);
        }

        private void BtnMedium_Click(object sender, EventArgs e)
        {
            _currentlySelectedDifficulty = Difficulty.Medium;
            _game.TrainingState.AI = (MediumAI)CreateAI();

            var selectClassState = new SelectClassState(_content, _game, _graphicsDevice, "startTraining");
            _game.ChangeState(selectClassState);
        }

        private void BtnHard_Click(object sender, EventArgs e)
        {
            _currentlySelectedDifficulty = Difficulty.Hard;
            _game.TrainingState.AI = (HardAI)CreateAI();

            var selectClassState = new SelectClassState(_content, _game, _graphicsDevice, "startTraining");
            _game.ChangeState(selectClassState);
        }

        private AITemplate CreateAI()
        {
            AITemplate templateAI = null;
            Dictionary<string, Animation> animations = GetAIAnimations();

            if (_currentlySelectedDifficulty == Difficulty.Easy)
            {
                templateAI = new EasyAI(animations);

                templateAI.PrimaryOffense = GetWeapon("primary");
                templateAI.Shield = new Shield(null, templateAI);
            }
            else if (_currentlySelectedDifficulty == Difficulty.Medium)
            {
                templateAI = new MediumAI(animations);

                templateAI.PrimaryOffense = GetWeapon("primary");
            }
            else if (_currentlySelectedDifficulty == Difficulty.Hard)
            {
                templateAI = new HardAI(animations);
                templateAI.PrimaryOffense = GetWeapon("primary");
                templateAI.SecondaryOffense = GetWeapon("secondary");
            }

            templateAI.PrimaryOffense.Owner = templateAI;
            if (_currentlySelectedDifficulty == Difficulty.Hard)
            {
                templateAI.SecondaryOffense.Owner = templateAI;
            }

            templateAI.HealthBar = new HealthBar(GetBarTexture("health"), _largeFont, templateAI, new Vector2(600, 10), new Vector2(520, 10));
            templateAI.PointsBar = new PointsBar(GetBarTexture("points"), _largeFont, templateAI, new Vector2(600, 45), new Vector2(520, 45));

            return templateAI;
        }

        private Weapon GetWeapon(string type)
        {
            var weapon = new Weapon(null);

            if (_currentlySelectedDifficulty == Difficulty.Easy)
            {
                weapon.DamageAmount = 35;
                weapon.Name = "Attack";
            }
            else if (_currentlySelectedDifficulty == Difficulty.Medium)
            {
                weapon.DamageAmount = 10;
                weapon.Ammunition = new Ammunition(_content.Load<Texture2D>("Offense/Mage/magicstar"));
                weapon.AmmunitionCount = 30;
                weapon.Name = "Magic Wand";
            }
            else if (_currentlySelectedDifficulty == Difficulty.Hard)
            {
                weapon.DamageAmount = 15;
                weapon.Ammunition = new Ammunition(_content.Load<Texture2D>("Offense/Ranger/pancake"));
                weapon.AmmunitionCount = 30;
                weapon.Name = "Pancake Shooter";
            }

            return weapon;
        }

        private Dictionary<string, Animation> GetAIAnimations()
        {
            var animations = new Dictionary<string, Animation>();

            if (_currentlySelectedDifficulty == Difficulty.Easy)
            {
                // Left animations
                animations.Add("LeftRun", new Animation(_content.Load<Texture2D>("Players/Melee/Left/run"), 7, 0.2d));
                animations.Add("LeftIdle", new Animation(_content.Load<Texture2D>("Players/Melee/Left/idle"), 4, 0.2d));
                animations.Add("LeftAttack01", new Animation(_content.Load<Texture2D>("Players/Melee/Left/attack_1"), 5, 0.2d));
                animations.Add("LeftAttack02", new Animation(_content.Load<Texture2D>("Players/Melee/Left/attack_2"), 4, 0.2d));
                animations.Add("LeftAttack03", new Animation(_content.Load<Texture2D>("Players/Melee/Left/attack_3"), 4, 0.2d));
                animations.Add("LeftDead", new Animation(_content.Load<Texture2D>("Players/Melee/Left/dead"), 6, 0.2d));
                animations.Add("LeftDefend", new Animation(_content.Load<Texture2D>("Players/Melee/Left/defend"), 5, 0.2d));
                animations.Add("LeftChargeAttack", new Animation(_content.Load<Texture2D>("Players/Melee/Left/chargeattack"), 6, 0.2d));

                // Right animations
                animations.Add("RightRun", new Animation(_content.Load<Texture2D>("Players/Melee/Right/run"), 7, 0.2d));
                animations.Add("RightIdle", new Animation(_content.Load<Texture2D>("Players/Melee/Right/idle"), 4, 0.2d));
                animations.Add("RightAttack01", new Animation(_content.Load<Texture2D>("Players/Melee/Right/attack_1"), 5, 0.2d));
                animations.Add("RightAttack02", new Animation(_content.Load<Texture2D>("Players/Melee/Right/attack_2"), 4, 0.2d));
                animations.Add("RightAttack03", new Animation(_content.Load<Texture2D>("Players/Melee/Right/attack_3"), 4, 0.2d));
                animations.Add("RightDead", new Animation(_content.Load<Texture2D>("Players/Melee/Right/dead"), 6, 0.2d));
                animations.Add("RightDefend", new Animation(_content.Load<Texture2D>("Players/Melee/Right/defend"), 5, 0.2d));
                animations.Add("RightChargeAttack", new Animation(_content.Load<Texture2D>("Players/Melee/Right/chargeattack"), 5, 0.2d));
            }
            else if (_currentlySelectedDifficulty == Difficulty.Medium)
            {
                // Left animations
                animations.Add("LeftRun", new Animation(_content.Load<Texture2D>("Players/Mage/Left/run"), 8, 0.3d));
                animations.Add("LeftIdle", new Animation(_content.Load<Texture2D>("Players/Mage/Left/idle"), 8, 0.2d));
                animations.Add("LeftAttack", new Animation(_content.Load<Texture2D>("Players/Mage/Left/shoot"), 6, 0.2d));
                animations.Add("LeftDead", new Animation(_content.Load<Texture2D>("Players/Mage/Left/dead"), 4, 0.2d));
                animations.Add("LeftStealth", new Animation(_content.Load<Texture2D>("Players/Mage/Left/stealth"), 8, 0.2d));

                // Right animations
                animations.Add("RightRun", new Animation(_content.Load<Texture2D>("Players/Mage/Right/run"), 8, 0.3d));
                animations.Add("RightIdle", new Animation(_content.Load<Texture2D>("Players/Mage/Right/idle"), 8, 0.2d));
                animations.Add("RightAttack", new Animation(_content.Load<Texture2D>("Players/Mage/Right/shoot"), 6, 0.2d));
                animations.Add("RightDead", new Animation(_content.Load<Texture2D>("Players/Mage/Right/dead"), 4, 0.2d));
                animations.Add("RightStealth", new Animation(_content.Load<Texture2D>("Players/Mage/Right/stealth"), 8, 0.2d));
            }
            else
            {
                // Left animations
                animations.Add("LeftRun", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/run"), 8, 0.1d));
                animations.Add("LeftIdle", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/idle"), 7, 0.1d));
                animations.Add("LeftAttack", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/shoot"), 15, 0.1d));
                animations.Add("LeftDead", new Animation(_content.Load<Texture2D>("Players/Ranger/Left/dead"), 5, 0.1d));

                // Right animations
                animations.Add("RightRun", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/run"), 8, 0.1d));
                animations.Add("RightIdle", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/idle"), 7, 0.1d));
                animations.Add("RightAttack", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/shoot"), 15, 0.1d));
                animations.Add("RightDead", new Animation(_content.Load<Texture2D>("Players/Ranger/Right/dead"), 5, 0.1d));
            }

            return animations;
        }

        private Dictionary<string, Texture2D> GetBarTexture(string type)
        {
            var textures = new Dictionary<string, Texture2D>();

            switch (type)
            {
                case "health":
                    {
                        textures.Add("full", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/full"));
                        textures.Add("5/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/5_6"));
                        textures.Add("4/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/4_6"));
                        textures.Add("3/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/3_6"));
                        textures.Add("2/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/2_6"));
                        textures.Add("1/6", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/1_6"));
                        textures.Add("empty", _content.Load<Texture2D>("HeadsUpDisplay/Healthbars/Player_1/empty"));
                    }
                    break;
                case "points":
                    {
                        textures.Add("full", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/full"));
                        textures.Add("2/3", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/2_3"));
                        textures.Add("1/3", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/1_3"));
                        textures.Add("empty", _content.Load<Texture2D>("HeadsUpDisplay/Pointsbars/Player_1/empty"));
                    }
                    break;
            }

            return textures;
        }
    }
}

