using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerRaf : MonoBehaviour
{
    public GameObject []pippo;

    public void GameOver() { SceneManager.LoadScene("GameOver"); }
    public void Menu() { SceneManager.LoadScene("Menu"); }
    public void Game() 
    {
         
        for (int i = 0; i < pippo.Length; i++)
        {

           AudioSource c = GetComponent<AudioSource>();
                
            if (i == 0)
            {
                c.Play();
            }
            else if (i==1)
            {
                c.Play();
            }
        }
            //pippo.Play();
        Invoke("Delay",2f);
        //SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    void Delay()
    {
        SceneManager.LoadScene("GameScene");
    }
}
