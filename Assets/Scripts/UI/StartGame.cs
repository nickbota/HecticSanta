using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameButton()
    {
        GameEvents.instance.GameStart();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.End))
            StartGameButton();

        if (Input.GetKeyDown(KeyCode.Escape))
            QuitButton();
    }
}