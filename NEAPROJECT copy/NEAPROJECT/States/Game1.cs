using System;
using NEAPROJECT.Backend;
using NEAPROJECT.CustomStacks;
using NEAPROJECT.States;

namespace NEAPROJECT;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Account _account01;
    private Account _account02;

    private State _currentState;
    private State _nextState;
    private StateStack _states;

    private Database _database;

    private RoundState _roundState;
    private TrainingState _trainingState;

    public Account Account01 { get => _account01; set => _account01 = value; }
    public Account Account02 { get => _account02; set => _account02 = value; }


    public StateStack States { get => _states; set => _states = value; }
    public Database Database { get => _database; }

    public RoundState RoundState { get => _roundState; set => _roundState = value; }
    public TrainingState TrainingState { get => _trainingState; set => _trainingState = value; }

    public void ChangeState(State state)
    {
        _nextState = state;
    }

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _states = new StateStack();
        _database = new Database();
    }

    protected override void Initialize()
    {
        IsMouseVisible = true;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _roundState = new RoundState(this.Content, this, _graphics.GraphicsDevice);
        _trainingState = new TrainingState(this.Content, this, _graphics.GraphicsDevice);
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _currentState = new LaunchState(Content, this, _graphics.GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (_nextState != null)
        {
            _currentState = _nextState;
            _nextState = null;
        }

        _currentState.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _currentState.Draw(gameTime, _spriteBatch);

        base.Draw(gameTime);
    }
}

