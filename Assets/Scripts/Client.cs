using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public ScoreManager score;
    public int stati=5;
    public GameObject[] clientList;
    public GameObject currentClient;
   
    
    void Start()
    {
        ActiveClient(true);

    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            ActiveClient(false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ActiveClient(true);
        }
        
        CountClient();
    }

    void ActiveClient(bool i) 
    {
        if (i)
        {
            int n = Random.Range(0, clientList.Length);

            GameObject g = clientList[n];
            g.SetActive(i);
            currentClient = g;
        }
        else
        {
            currentClient.SetActive(false);
        }
    }

    private void StateScore(int i)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            score.AddScore(5 * i);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            score.AddScore(3 * i);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            score.AddScore(4 * i);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            //score.AddScore(25);
            Debug.Log("VAFFANCULO CONTE!!!!!");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            score.AddScore(-2 * i);
        }
    }

    private void CountClient()
    {
        for (int i = 0; i < clientList.Length; i++)
        {
            if (i == 0)
            {
                StateScore(1);
            }
            else if (i == 1)
            {
                StateScore(2);
            }
            else if (i == 2)
            {
                StateScore(3);
            }
            else if (i == 3)
            {
                StateScore(4);
            }
            else if (i == 4)
            {
                StateScore(5);
            }

        }
    }
}
