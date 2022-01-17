using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 gamePosition;
    [SerializeField] private Vector3 gameOverPosition;
    [SerializeField] private Transform player;

    private void Awake()
    {
        transform.position = gamePosition;
    }
    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void OnDisable()
    {
        GameEvents.instance.OnGameOver -= MoveToGameOverPosition;
    }
    private IEnumerator Subscribe()
    {
        yield return new WaitUntil(() => GameEvents.instance != null);
        GameEvents.instance.OnGameOver += MoveToGameOverPosition;
    }
    private void MoveToGameOverPosition()
    {
        gameOverPosition = new Vector3(player.position.x, gameOverPosition.y, gameOverPosition.z);
        transform.DOMove(gameOverPosition, 1f);
    }
}