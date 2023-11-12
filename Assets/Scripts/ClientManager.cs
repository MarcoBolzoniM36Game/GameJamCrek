using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    public ScoreManager score;
    public int stati=5;
    public GameObject[] clientList;
    public GameObject currentClient;
   
    public VendingMachineManager vendingMachine;
    public PlayerMovement playerMovement;
    
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
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    ActiveClient(true);
        //}
        
        //CountClient();
    }

    public void ActiveClient(bool i) 
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
            Debug.Log("VAFFANCULO CONTE!!!!!");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            score.AddScore(-2 * i);
        }
    }

    public void CountClient()
    {
        Client c = currentClient.GetComponent<Client>();
        if (c != null)
        {
            StateScore(c.ScoreMultiplier);
            vendingMachine.SelectFood(c.HowManyFoodDrop);
            playerMovement.canDash = c.canActiveDash;
            if (c.canProvideLife)
            {
                // aggiungere una vita al player
            }
            // TODO: se il nome verrà gestito in game con un TextMeshPRO, aggiornarlo
        }
    }
}
