using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClientManager : MonoBehaviour
{
    public ScoreManager score;
    public int stati=5;
    public GameObject[] clientList;
    public GameObject currentClient;
    public int currentFoodCatch = 0;
   
    public VendingMachineManager vendingMachine;
    public PlayerMovement playerMovement;
    public RageBarManager rageManger;
    public GameFlowManager gameFlow;
    public PlayerHealth ph;
    
    void Start()
    {
        CountClient();
    }
    public void ActiveClient(bool i) 
    {
        int n = Random.Range(0, clientList.Length);

        GameObject g = clientList[n];

        if (i==true)
        {


            g.SetActive(i);

            currentClient = g;

            currentFoodCatch = 0;

            Debug.Log("CLIENT: " + currentClient.name);

        }
        else
        {
            currentClient.SetActive(false);
        }
    }

    public void FoodCatch()
    {
        currentFoodCatch++;

        Client c = currentClient.GetComponent<Client>();

        if (c != null)
        {
            if (currentFoodCatch == c.HowManyFoodDrop)
            {
                rageManger.AddRage(c.rageAmount);
            }
        }
    }

    private void StateScore(int i)
    {
      
        if (rageManger.currentRage == 400)
        {
            score.AddScore(5 * i);
        }
        else if (rageManger.currentRage == 800)
        {
            score.AddScore(3 * i);
        }
        else if (rageManger.currentRage == 1200)
        {
            score.AddScore(4 * i);
        }
        else if (rageManger.currentRage == 1600)
        {
            Debug.Log("MILLEMILAAA!!");
        }
        else if (rageManger.currentRage == 0)
        {
            score.AddScore(-2 * i);
        }
    }

    public void CountClient()
    {
        if (currentClient != null)
        {
            Client c = currentClient.GetComponent<Client>();
            if (c != null)
            {
                StateScore(c.ScoreMultiplier);

                vendingMachine.SelectFood(c.HowManyFoodDrop);

                playerMovement.canDash = c.canActiveDash;

                c.targhetta.SetActive(true);

                if (c.canProvideLife)
                {
                    ph.Yeaah();
                }
                else if (c.canProvideLife == false)
                {
                    return;
                }




                //if (c.canProvideLife)
                //{
                //    ph.canProvideLife = true;
                //}
                //else if (c.canProvideLife == false)
                //{
                //    ph.canProvideLife = false;

                //}
                // TODO: se il nome verrà gestito in game con un TextMeshPRO, aggiornarlo
            }
        }
    }
}
