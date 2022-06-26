using UnityEngine;
using UnityEngine.SceneManagement;

public enum RaceResult
{
    Unknown,
    Victory,
    Defeat
}

public interface IGameMode
{
    GamePhase Phase { get; }

    RaceResult Result { get; }

    public float RaceTime { get; }

    void StartRace();

    void Finish(bool isPlayer);

    void RestartLevel();

    void GameOver();
}

public class EmptyGameMode : IGameMode
{
    public GamePhase Phase => GamePhase.NotStarted;

    public RaceResult Result => RaceResult.Unknown;

    public float RaceTime => 0;

    private EmptyGameMode()
    {
    }

    public void StartRace()
    {
    }

    public void Finish(bool isPlayer)
    {
    }

    public void RestartLevel()
    {
    }

    public void GameOver()
    {
    }

    public static IGameMode Instance { get; } = new EmptyGameMode();
}

public class GameMode : MonoBehaviour, IGameMode
{
    private GamePhase _phase;

    public GamePhase Phase
    {
        get => _phase;

        private set
        {
            if (_phase != value)
            {
                _phase = value;
                GameLifecycle.NotifyPhaseChanged(value);
            }
        }
    }

    public RaceResult Result { get; private set; }

    public float RaceTime { get; private set; }

    public void StartRace()
    {
        if (Phase == GamePhase.Starting)
        {
            Phase = GamePhase.Started;
        }
    }

    public void Finish(bool isPlayer)
    {
        if (Phase == GamePhase.Started)
        {
            Result = isPlayer ? RaceResult.Victory : RaceResult.Defeat;
            Phase = GamePhase.Finished;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Start()
    {
        GameLifecycle.GameMode = this;
        if (Phase == GamePhase.NotStarted)
        {
            Phase = GamePhase.Starting;
        }
    }

    private void Update()
    {
        if (Phase == GamePhase.Started)
        {
            RaceTime += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        Phase = GamePhase.GameOver;
        GameLifecycle.GameMode = EmptyGameMode.Instance;
    }
}
