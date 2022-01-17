using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    //Score
    [SerializeField] private Text scoreCounter;
    [SerializeField] private AudioClip hohoho;
    [SerializeField] private AudioClip gameOverSound;
    public int score { get; private set; }
    private bool gameStarted;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameStarted)
            Restart();
    }

    //Events
    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void OnDisable()
    {
        GameEvents.instance.OnGameOver -= GameOver;
        GameEvents.instance.OnGameStart -= StartGame;
    }
    private IEnumerator Subscribe()
    {
        yield return new WaitUntil(() => GameEvents.instance != null);
        GameEvents.instance.OnGameOver += GameOver;
        GameEvents.instance.OnGameStart += StartGame;
    }
    private void GameOver()
    {
        if (score > PlayerPrefs.GetInt("highScore"))
            PlayerPrefs.SetInt("highScore", score);

        SoundManager.instance.ChangeMusic(gameOverSound);
        gameStarted = false;
    }
    private void StartGame()
    {
        gameStarted = true;
    }

    //Public methods
    public void IncreaseScore()
    {
        score++;
        scoreCounter.text = score.ToString();
        scoreCounter.rectTransform.DOPunchScale(Vector3.one, 0.25f);

        if (score == 69)
            SoundManager.instance.PlaySound(hohoho, 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}