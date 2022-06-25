using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGuiController : MonoBehaviour
{
    [SerializeField]
    private GameObject _currentScreen;

    public void SwitchToScreen(GameObject screen)
    {
        if (_currentScreen != null)
        {
            _currentScreen.SetActive(false);
        }

        screen.SetActive(true);
        _currentScreen = screen;
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("polygon");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
