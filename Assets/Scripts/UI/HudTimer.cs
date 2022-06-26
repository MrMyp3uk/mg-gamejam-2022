using TMPro;
using UnityEngine;

public class HudTimer : MonoBehaviour
{
    private TMP_Text _timerText;

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        UpdateTimer();
    }

    private void Update()
    {
        if (GameLifecycle.GameMode.Phase == GamePhase.Started)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        _timerText.text = FormatRaceTime(GameLifecycle.GameMode.RaceTime);
    }

    private static string FormatRaceTime(float raceTime)
    {
        var minutes = Mathf.FloorToInt(raceTime / 60f);
        var seconds = Mathf.FloorToInt(raceTime % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}
