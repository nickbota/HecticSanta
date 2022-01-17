using UnityEngine;

public class Present : MonoBehaviour
{
    private PlayerHealth health;

    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip failure;

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            SoundManager.instance.PlaySound(success, 0.5f);
            ParticleManager.instance.ActivateParticles(true, transform.position);
            GameManager.instance.IncreaseScore();
        }
        if (other.tag == "Ground")
        {
            gameObject.SetActive(false);
            health.ChangeHealth(-1);
            SoundManager.instance.PlaySound(failure, 0.5f);
            ParticleManager.instance.ActivateParticles(false, new Vector3(transform.position.x,
                transform.position.y + 0.65f, transform.position.z - 0.5f));
        }
    }
}