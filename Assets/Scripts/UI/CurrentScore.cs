using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    private Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
        txt.text = "SCORE:" + GameManager.instance.score;
    }
}