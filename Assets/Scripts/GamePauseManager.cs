using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("GOTO PAUSE!");
            GameManager.Instance.PauseGame();
        }
    }
}
