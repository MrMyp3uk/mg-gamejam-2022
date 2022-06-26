using UnityEngine;

public enum GamePhase
{
    NotStarted,
    Starting,
    Started,
    Paused,
    Finished,
    GameOver
}

public delegate void GamePhaseEventHandler(GamePhase phase);

public static class GameLifecycle
{
    public static IGameMode GameMode { get; set; } = EmptyGameMode.Instance;

    public static event GamePhaseEventHandler OnPhaseChanged;

    public static void NotifyPhaseChanged(GamePhase phase)
    {
#if UNITY_EDITOR
        Debug.Log($"Switch to phase {phase}");
#endif
        OnPhaseChanged?.Invoke(phase);
    }
}
