using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead;
    public float maxHealth;
    float currentHealth;

    public Slider playerHealthSlider;
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            makeDead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(4);
        }

    }

    public void makeDead()
    {
        isDead = true;
        playerHealthSlider.value = 0;
        UIManager.Instance.txtGameOver.SetActive(true);
        gameObject.SetActive(false);
    }
}
