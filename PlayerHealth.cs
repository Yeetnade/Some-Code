using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject spawnPoint;
    public GameObject mainPlayer;
    private Rigidbody2D rb2;
   
    public healthBarScript health;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<EnemyBullet>();
        if(player)
        {
            TakeDamage(1);
        }

    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        health.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            rb2 = mainPlayer.GetComponent<Rigidbody2D>();
            mainPlayer.transform.localPosition = spawnPoint.transform.localPosition;
            currentHealth = maxHealth;
            health.SetMaxHealth(maxHealth);
            SceneManager.LoadScene("Level 2");
        }
    }
}
