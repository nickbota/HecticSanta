using UnityEngine;
using DG.Tweening;

public class MenuFade : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }
    private void OnEnable()
    {
        canvasGroup.DOFade(1, 1);
    }
}