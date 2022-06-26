using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] private GameObject _hud;

    private void Awake()
    {
        GameLifecycle.OnPhaseChanged += OnGamePhaseChanged;
    }

    private void OnDestroy()
    {
        GameLifecycle.OnPhaseChanged -= OnGamePhaseChanged;
    }

    private void OnGamePhaseChanged(GamePhase phase)
    {
        var active = phase == GamePhase.Started;
        if (_hud.activeSelf != active)
        {
            _hud.SetActive(active);
        }
    }
}
