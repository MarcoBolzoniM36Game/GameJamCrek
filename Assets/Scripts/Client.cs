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
        //StartCoroutine("CalculateTime");
        //StartCoroutine(CalculateTime());
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



        StateScore();
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


    //IEnumerator CalculateTime()
    //{
    //    yield return new WaitForSeconds(10);
    //    Debug.Log("Il tempo passa");
    //}
    private void StateScore()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            score.AddScore(5);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            score.AddScore(3);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            score.AddScore(4);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            //score.AddScore(25);
            Debug.Log("VAFFANCULO CONTE!!!!!");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            score.AddScore(-2);
        }
    }

    
}
