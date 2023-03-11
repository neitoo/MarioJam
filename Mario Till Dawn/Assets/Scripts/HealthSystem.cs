using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 3;
    public int currentHealth;

    public List<GameObject> hearts = new List<GameObject>();
    public GameObject heartPrefab;

    void Start()
    {
        currentHealth = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
            heart.transform.parent = transform;
            hearts.Add(heart);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //game over
        }
        else
        {
            GameObject heart = hearts[currentHealth];
            hearts.Remove(heart);
            Destroy(heart);
        }
    }
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
            heart.transform.parent = transform;
            hearts.Add(heart);
        }
    }
}
