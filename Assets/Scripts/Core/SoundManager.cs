using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    [SerializeField] private AudioSource musicSource;
    private AudioSource source;


    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound, float volume)
    {
        source.volume = volume;
        source.pitch = Random.Range(0.8f, 1.2f);
        source.PlayOneShot(sound);
    }

    public void ChangeMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicSource.loop = false;
        musicSource.Play();
    }
}