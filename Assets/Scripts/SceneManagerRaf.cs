using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerRaf : MonoBehaviour
{

    public void GameOver() { SceneManager.LoadScene("GameOver"); }
    public void Menu() { SceneManager.LoadScene("Menu"); }
    public void Game() 
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
