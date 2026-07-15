using System;
using MySqlX.XDevAPI.Relational;
using NEAPROJECT.Backend;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;
using NEAPROJECT.Controls;
using System.Reflection.Metadata;

namespace NEAPROJECT.States
{
    public class LeaderboardState : Menu
    {
        private Database _database;
        private Account _currentlyLoggedInAccount;
        private List<Account> _accounts;
        private Cell[,] _grid;
        private int _currentDivisionLowerBoundary;
        private int _currentDivisionUpperBoundary;
        private Button _btnPrevious;
        private Button _btnNext;

        public LeaderboardState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Database database, Account currentlyLoggedInAccount) : base(content, game, graphicsDevice)
        {
            _game.States.Push(this);

            _database = database;
            _currentlyLoggedInAccount = currentlyLoggedInAccount;
            _accounts = _database.FillList();
            _currentDivisionLowerBoundary = 0;
            _currentDivisionUpperBoundary = 9;

            MergeSort(_accounts);
            Reverse(_accounts);

            LoadContent(content);
        }

        protected override void LoadContent(ContentManager content)
        {
            _grid = CreateGrid(content.Load<Texture2D>("Controls/Cell"), _smallFont);

            _btnPrevious = new Button(content.Load<Texture2D>("Controls/button_small"), _smallFont);
            _btnPrevious.Text = "<";
            _btnPrevious.Position = new Vector2(100, 443);
            _btnPrevious.Click += _btnPrevious_Click;

            _btnNext = new Button(content.Load<Texture2D>("Controls/button_small"), _smallFont);
            _btnNext.Text = ">";
            _btnNext.Position = new Vector2(495, 443);
            _btnNext.Click += _btnNext_Click; 

            _components = new CustomLinkedList();
            _components.AddNodeToFront(_btnNext);
            _components.AddNodeToFront(_btnPrevious);
        }

        private void _btnNext_Click(object sender, EventArgs e)
        {
            if (_currentDivisionUpperBoundary == _accounts.Count - 1)
            {
                return;
            }
            else
            {
                _currentDivisionLowerBoundary += 10;
                if (_currentDivisionUpperBoundary + 10 >= _accounts.Count)
                {
                    _currentDivisionUpperBoundary += _accounts.Count - _currentDivisionUpperBoundary - 1;
                }
                else
                {
                    _currentDivisionUpperBoundary = _currentDivisionLowerBoundary + 9;
                }
            }

            _grid = CreateGrid(_content.Load<Texture2D>("Controls/Cell"), _content.Load<SpriteFont>("Fonts/small_font"));
        }

        private void _btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentDivisionLowerBoundary == 0)
            {
                return;
            }
            else
            {
                if (_currentDivisionUpperBoundary == _accounts.Count - 1)
                {
                    _currentDivisionUpperBoundary -= _currentDivisionUpperBoundary - _currentDivisionLowerBoundary + 1;
                }
                else
                {
                    _currentDivisionUpperBoundary -= _currentDivisionUpperBoundary - 9;
                }
                _currentDivisionLowerBoundary -= 10;
            }

            _grid = CreateGrid(_content.Load<Texture2D>("Controls/Cell"), _content.Load<SpriteFont>("Fonts/small_font"));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.DrawString(_largeFont, "Leaderboard", new Vector2(280, 10), Color.Black);

            for (int i = 1; i <= _components.Count; i++)
            {
                Component currentComponent = _components.SearchList(i);
                currentComponent.Draw(spriteBatch);
            }

            foreach (Cell cell in _grid)
            {
                cell.Draw(spriteBatch);
            }

            spriteBatch.DrawString(_smallerFont, "Username", new Vector2(185, 87), Color.Black);
            spriteBatch.DrawString(_smallFont, "Level", new Vector2(276, 85), Color.Black);
            spriteBatch.DrawString(_smallFont, "Wins", new Vector2(366, 85), Color.Black);
            spriteBatch.DrawString(_smallFont, "Rounds", new Vector2(428, 73), Color.Black);
            spriteBatch.DrawString(_smallFont, "Played", new Vector2(434, 85), Color.Black);
            spriteBatch.DrawString(_smallFont, "Kills", new Vector2(526, 85), Color.Black);
            spriteBatch.DrawString(_smallFont, "Deaths", new Vector2(596, 85), Color.Black);

            _btnBack.Draw(spriteBatch);

            spriteBatch.End();
        }

        private void MergeSort(List<Account> mergeList)
        {
            // this merge sort will sort accounts based on the number of eliminations, from lowest to highest

            if (mergeList.Count > 1)
            {
                int middle = mergeList.Count / 2; // index for middle of array
                int pointer = 0;

                List<Account> leftHalf = new List<Account>();
                List<Account> rightHalf = new List<Account>();

                // fills the left array
                do
                {
                    leftHalf.Add(mergeList[pointer]);
                    pointer++;
                }
                while (pointer != middle);

                // fills the right array
                do
                {
                    rightHalf.Add(mergeList[pointer]);
                    pointer++;
                }
                while (pointer != mergeList.Count);

                MergeSort(leftHalf);
                MergeSort(rightHalf);

                int i = 0, j = 0, k = 0;

                while (i < leftHalf.Count && j < rightHalf.Count)
                {
                    if (leftHalf[i].Eliminations < rightHalf[j].Eliminations)
                    {
                        mergeList[k] = leftHalf[i];
                        i++;
                    }
                    else
                    {
                        mergeList[k] = rightHalf[j];
                        j++;
                    }
                    k++;
                }

                // check if the left half has elements not merged
                while (i < leftHalf.Count)
                {
                    mergeList[k] = leftHalf[i];
                    i++;
                    k++;
                }

                // check if left half has elements not merged
                while (j < rightHalf.Count)
                {
                    mergeList[k] = rightHalf[j];
                    j++;
                    k++;
                }
            }
            else
            {
                return;
            }
        }

        private void Reverse(List<Account> reverseList)
        {
            // create a temporary list with accounts in list in reverse order
            List<Account> tempList = new List<Account>();

            for (int i = reverseList.Count - 1; i >= 0; i--)
            {
                tempList.Add(reverseList[i]);
            }

            // reinstantiate reverse list and add each account from temporary list

            for (int j = 0; j < tempList.Count; j++)
            {
                reverseList[j] = (tempList[j]);
            }
        }

        private Cell[,] CreateGrid(Texture2D cellTexture, SpriteFont font)
        {
            // creates a new list of the next 10 accounts to be displayed
            var currentAccountsDivision = new List<Account>();
            for (int i = _currentDivisionLowerBoundary; i <= _currentDivisionUpperBoundary; i++)
            {
                currentAccountsDivision.Add(_accounts[i]);
            }

            // creates a new grid with 7 columns, for each needed account field such as eliminations, and the number
            // of rows the same as the number of next accounts to be displayed;
            Cell[,] grid = new Cell[currentAccountsDivision.Count, 7];

            // fills in the 2D array
            for (int row = 0; row < currentAccountsDivision.Count; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    Color cellColour = Color.White;

                    if (column == 0)
                    {
                        // if the current account being filled into the grid matches the currently logged in users
                        // details, then the pen colour of the position cell in that row is set to yellow
                        string usernameToCompare = GetField(currentAccountsDivision[row], column + 1);

                        if (_currentlyLoggedInAccount.Username == usernameToCompare)
                        {
                            cellColour = Color.Yellow;
                        }

                        // column 0 represents the position column therefore there is no need to retrieve information
                        // from an account
                        grid[row, column] = new Cell(cellTexture, font, cellColour, (_currentDivisionLowerBoundary + row + 1).ToString());
                    }
                    else
                    {
                        grid[row, column] = new Cell(cellTexture, font, cellColour, GetField(currentAccountsDivision[row], column));
                    }

                    grid[row, column].Position = new Vector2((column * cellTexture.Width) + 100, (row * cellTexture.Height) + 100);
                }
            }

            return grid;
        }

        private string GetField(Account account, int column)
        {
            switch (column)
            {
                case 1:
                    return account.Username;
                case 2:
                    return account.Level.ToString();
                case 3:
                    return account.Wins.ToString();
                case 4:
                    return account.RoundsPlayed.ToString();
                case 5:
                    return account.Eliminations.ToString();
                case 6:
                    return account.Deaths.ToString();
            }

            return null;
        }
    }
}

