using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

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

        if (currentHealth > 81)
        {
            GetComponent<SpriteRenderer>().sprite = fullHealthSprite;
        }
        else if (currentHealth > 61)
        {
            GetComponent<SpriteRenderer>().sprite = seventyFivePercentSprite;
        }
        else if (currentHealth > 41)
        {
            GetComponent<SpriteRenderer>().sprite = fiftyPercentSprite;
        }
        else if (currentHealth > 21)
        {
            GetComponent<SpriteRenderer>().sprite = twentyFivePercentSprite;
            
        }
        else  if (currentHealth>1)
        {
            GetComponent<SpriteRenderer>().sprite = fivePercentSprite;
            
        }
        else if (currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}



