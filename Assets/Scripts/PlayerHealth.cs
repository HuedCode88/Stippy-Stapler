using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int maxTotalHealth = 3;
    public int currentHealth;
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
    private GameObject explosion;

    public float Health { get { return currentHealth; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        explosion = transform.GetChild(2).gameObject;
    }

    public void TakeDamage(int amount)
    {
        //sound effect taking damage possibly
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            explosion.SetActive(true);
            Destroy(gameObject);
        }
        ClampHealth();
    }
    void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        ClampHealth();
    }
    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            currentHealth = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }
    }
    void ClampHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
}
