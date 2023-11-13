using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

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
    //public Transform spawnPoint;
    //public VisualEffect vfxRespawn;
    //public GameObject playerPrefab;

    private void Start()
    {

    }
    private void Update()
    {
        Debug.Log(currentHealth);
        //UpdateSprite();

    }
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth > 76)
        {
            GetComponent<SpriteRenderer>().sprite = fullHealthSprite;
        }
        else if (currentHealth > 51)
        {
            GetComponent<SpriteRenderer>().sprite = seventyFivePercentSprite;
        }
        else if (currentHealth > 26)
        {
            GetComponent<SpriteRenderer>().sprite = fiftyPercentSprite;
        }
        else if (currentHealth > 1)
        {
            GetComponent<SpriteRenderer>().sprite = twentyFivePercentSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = fivePercentSprite;
        }
    }

    //private void Update()
    //{
    //    UpdateSprite();
    //}

    //public void UpdateSprite()
    //{
    //    if (currentHealth > 75)
    //    {
    //        spriteRenderer.sprite = fullHealthSprite;
    //    }
    //    else if (currentHealth > 50)
    //    {
    //        spriteRenderer.sprite = seventyFivePercentSprite;
    //    }
    //    else if (currentHealth > 25)
    //    {
    //        spriteRenderer.sprite = fiftyPercentSprite;
    //    }
    //    else if (currentHealth > 0)
    //    {
    //        spriteRenderer.sprite = twentyFivePercentSprite;
    //    }
    //    else
    //    {
    //        spriteRenderer.sprite = fivePercentSprite;
    //    }
    //}

    //private void RespawnPlayer()
    //{
    //    if (currentHealth == 0)
    //    {
    //        Respawn();
    //Instantiate(gameObject, spawnPoint.position, spawnPoint.rotation);
    //transform.position = spawnPoint.position;
    //Debug.Log("DIOMER");
    //    }
    //}
    //private void Respawn()
    //{
    //    Instantiate(vfxRespawn, spawnPoint.position, spawnPoint.rotation);
    //    //Instantiate(gameObject, spawnPoint.position, spawnPoint.rotation);
    //    //StartCoroutine(nameof(RespawnCoroutine));
    //    transform.position = spawnPoint.position;

    //}

    //IEnumerator RespawnCoroutine()
    //{
    //    Instantiate(respawn, spawnPoint.position, spawnPoint.rotation);
    //    Invoke(RespawnPlayer, delayTime);
    //    //yi/*eld return new WaitForSeconds(4);*/
    //    Debug.Log("HoAspettato4FottutiSecondi");
    //    //Instantiate(gameObject, spawnPoint.position, spawnPoint.rotation);

    //}

}



