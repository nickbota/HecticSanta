using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;

    [Header ("Mesh Renderer")]
    [SerializeField] private GameObject happySanta;
    [SerializeField] private GameObject sadSanta;
    [SerializeField] private Animator sadSantaAnimator;

    private Animator anim;
    private CharacterController controller;
    private float horizontalInput;
    private bool controlsLocked;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        LockControls();
        ActivateSanta(true);
    }
    private void Update()
    {
        if (controlsLocked) return;

        horizontalInput = Input.GetAxis("Horizontal");
        anim.SetBool("move", horizontalInput != 0);

        if (horizontalInput > 0.01f)
            transform.GetChild(0).DOLocalRotate(new Vector3(0, -60, 0), 0.25f);
        else if (horizontalInput < -0.01f)
            transform.GetChild(0).DOLocalRotate(new Vector3(0, 60, 0), 0.25f);
        else
            transform.GetChild(0).DOLocalRotate(new Vector3(0, 0, 0), 0.25f);

        controller.Move(new Vector3(horizontalInput * Time.deltaTime * speed, 0, 0));
    }

    //Events
    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void OnDisable()
    {
        GameEvents.instance.OnGameStart -= UnlockControls;
        GameEvents.instance.OnGameOver -= LockControls;
        GameEvents.instance.OnGameOver -= GameOver;
    }
    private IEnumerator Subscribe()
    {
        yield return new WaitUntil(() => GameEvents.instance != null);
        GameEvents.instance.OnGameStart += UnlockControls;
        GameEvents.instance.OnGameOver += LockControls;
        GameEvents.instance.OnGameOver += GameOver;
    }
    private void LockControls()
    {
        controlsLocked = true;
    }
    private void UnlockControls()
    {
        controlsLocked = false;
    }
    private void GameOver()
    {
        sadSantaAnimator.SetTrigger("gameOver");
        ActivateSanta(false);
    }
    private void ActivateSanta(bool happy)
    {
        happySanta.SetActive(happy);
        sadSanta.SetActive(!happy);
    }
}