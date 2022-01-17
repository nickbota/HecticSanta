using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
        txt.text = "HIGHSCORE:" + PlayerPrefs.GetInt("highScore");
    }
}