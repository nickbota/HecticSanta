using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Texture2D cursor;

    private void Awake()
    {
        ActivateMenu(startUI);
        Cursor.visible = true;
    }

    //Events
    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void OnDisable()
    {
        GameEvents.instance.OnGameOver -= GameOverUI;
        GameEvents.instance.OnGameStart -= StartGameUI;
    }
    private IEnumerator Subscribe()
    {
        yield return new WaitUntil(() => GameEvents.instance != null);
        GameEvents.instance.OnGameOver += GameOverUI;
        GameEvents.instance.OnGameStart += StartGameUI;
    }

    private void ActivateMenu(GameObject _menu)
    {
        startUI.SetActive(false);
        gameUI.SetActive(false);
        gameOverUI.SetActive(false);

        _menu.SetActive(true);
    }

    private void StartGameUI()
    {
        ActivateMenu(gameUI);
        //Cursor.visible = false;
    }
    private void GameOverUI()
    {
        ActivateMenu(gameOverUI);
        Cursor.visible = true;
    }
}