using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishDialogueController : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private string _victoryMessage = "Victory!";
    [SerializeField] private string _defeatMessage = "Defeat!";
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _gameOverButton;
    [SerializeField] private Animator _victoryAnim;

    public void Test()
    {
        Debug.Log("Here I am!");
    }

    private void Awake()
    {
        _restartButton.onClick.AddListener(() => GameLifecycle.GameMode.RestartLevel());
        _gameOverButton.onClick.AddListener(() => GameLifecycle.GameMode.GameOver());

        GameLifecycle.OnPhaseChanged += OnGamePhaseChanged;
    }

    private void OnDestroy()
    {
        GameLifecycle.OnPhaseChanged -= OnGamePhaseChanged;
    }

    private void OnGamePhaseChanged(GamePhase phase)
    {
        if (phase == GamePhase.Finished)
        {
            switch (GameLifecycle.GameMode.Result)
            {
                case RaceResult.Victory:
                    _victoryAnim.SetTrigger("Victory");
                    ShowDialogue(_victoryMessage);
                    break;

                case RaceResult.Defeat:
                    ShowDialogue(_defeatMessage);
                    break;
            }
        }
    }

    private void ShowDialogue(string message)
    {
        _dialogueText.text = message;
        _dialogueWindow.SetActive(true);
    }
}
