using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerRaf : MonoBehaviour
{
    public AudioSource coin;
    public AudioSource crek;

    public void GameOver() { SceneManager.LoadScene("GameOver"); }
    public void Menu() { SceneManager.LoadScene("Menu"); }
    public void Game() 
    {
        coin.Play();
        Invoke("Delay",1.5f);
    }

    public void QuitSound()
    {
        crek.Play();
        Invoke("Quit",1f);
    }
    public void Quit()
    {
        Application.Quit();
    }

    void Delay()
    {
        /*SceneManager.LoadScene("GameScene");*/
        SceneManager.LoadScene("GameScene_RaffaTest");
    }
}
