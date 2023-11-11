using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Sprite fullHealthSprite;
    public Sprite seventyFivePercentSprite;
    public Sprite fiftyPercentSprite;
    public Sprite twentyFivePercentSprite;
    public Sprite fivePercentSprite;

    public int maxHealth = 100;
    public int currentHealth = 100;
    private SpriteRenderer spriteRenderer;
   
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


       

        if (currentHealth > 75)
        {
            GetComponent<SpriteRenderer>().sprite = fullHealthSprite;
        }
        else if (currentHealth > 50)
        {
            GetComponent<SpriteRenderer>().sprite = seventyFivePercentSprite;
        }
        else if (currentHealth > 25)
        {
            GetComponent<SpriteRenderer>().sprite = fiftyPercentSprite;
        }
        else if(currentHealth > 0)
        {
            GetComponent<SpriteRenderer>().sprite = twentyFivePercentSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = fivePercentSprite;
        }
    }

    void UpdateSprite()
    {
        if (currentHealth > 75)
        {
            spriteRenderer.sprite = fullHealthSprite;
        }
        else if (currentHealth > 50)
        {
            spriteRenderer.sprite = seventyFivePercentSprite;
        }
        else if (currentHealth > 25)
        {
            spriteRenderer.sprite = fiftyPercentSprite;
        }
        else if(currentHealth >0)
        {
            spriteRenderer.sprite = twentyFivePercentSprite;
        }
        else
        {
            spriteRenderer.sprite = fivePercentSprite;
        }
    }
    private void Update()
    {
        
    
    
        if ( Input.GetKeyDown(KeyCode.Q) )
        {
            TakeDamage(2);
            Debug.Log("Danno");
        }
    }
}

