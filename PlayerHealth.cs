using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; 
    private int currentHealth;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Игрок получил урон! Текущее HP: " + currentHealth);

        UpdateHealthBar(); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; 
        }
    }
    public void Die()
    {
        currentHealth = 0;
        UpdateHealthBar(); 

        Debug.Log("ИГРОК УНИЧТОЖЕН! GAME OVER.");
        gameObject.SetActive(false); 
    }
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Игрок вылечился на " + amount + " HP. Текущее здоровье: " + currentHealth);
        UpdateHealthBar();
    }
}
