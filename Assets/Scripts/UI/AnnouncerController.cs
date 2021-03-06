using System.Collections;
using TMPro;
using UnityEngine;

public class AnnouncerController : MonoBehaviour
{
    [SerializeField] private TMP_Text _announce;
    [SerializeField] private float _countdownDelay = 2;

    private Coroutine _pendingCoroutine;

    private void Awake()
    {
        GameLifecycle.OnPhaseChanged += OnGamePhaseChanged;
    }

    private void OnDestroy()
    {
        if (_pendingCoroutine != null)
        {
            StopCoroutine(_pendingCoroutine);
        }

        GameLifecycle.OnPhaseChanged -= OnGamePhaseChanged;
    }

    private void OnGamePhaseChanged(GamePhase phase)
    {
        if (phase == GamePhase.Starting)
        {
            if (_pendingCoroutine != null)
            {
                StopCoroutine(_pendingCoroutine);
            }

            _pendingCoroutine = StartCoroutine(BeginRaceAnnounce());
        }
    }

    private IEnumerator BeginRaceAnnounce()
    {
        _announce.gameObject.SetActive(true);
        _announce.text = "Get ready!";
        yield return new WaitForSeconds(_countdownDelay);

        for (var i = 3; i > 0; i--)
        {
            _announce.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        _announce.text = "Go!";
        GameLifecycle.GameMode.StartRace();
        yield return new WaitForSeconds(1f);

        _announce.gameObject.SetActive(false);
    }
}
