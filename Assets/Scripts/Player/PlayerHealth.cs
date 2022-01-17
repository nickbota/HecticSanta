using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private GameObject[] hearts;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
        ChangeHealth(0);
    }

    public void ChangeHealth(int _change)
    {
        currentHealth += _change;
        for (int i = 0; i < hearts.Length; i++)
            hearts[i].SetActive(i < currentHealth);

        if (currentHealth <= 0)
            GameEvents.instance.GameOver();
    }
}