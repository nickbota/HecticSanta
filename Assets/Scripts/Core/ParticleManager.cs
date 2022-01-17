using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance { get; private set; }
    [SerializeField] private GameObject positiveParticles;
    [SerializeField] private GameObject negativeParticles;

    private void Awake()
    {
        instance = this;
        DeactivateParticles();
    }

    public void ActivateParticles(bool positive, Vector3 position)
    {
        DeactivateParticles();

        positiveParticles.transform.position = position;
        negativeParticles.transform.position = position;

        positiveParticles.SetActive(positive);
        negativeParticles.SetActive(!positive);
    }

    private void DeactivateParticles()
    {
        positiveParticles.SetActive(false);
        negativeParticles.SetActive(false);
    }
}