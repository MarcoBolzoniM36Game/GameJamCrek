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

    public UnityEvent ChangeClient = new UnityEvent();

    //void Start()
    //{
    //    //ActiveClient(true);

    //}


    void Update()
    {
        //ChangeClientWithRage();
        //    if (Input.GetKeyDown(KeyCode.K))
        //    {
        //        ActiveClient(false);
        //    }
        //    //if (Input.GetKeyDown(KeyCode.J))
        //    //{
        //    //    ActiveClient(true);
        //    //}

        //    //CountClient();
    }

    public void ActiveClient(bool i) 
    {
        if (i)
        {
            int n = Random.Range(0, clientList.Length);

            GameObject g = clientList[n];
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
        

        if (rageManger.currentRage >= 400)
        {
            score.AddScore(5 * i);
        }
        else if (rageManger.currentRage >= 800)
        {
            score.AddScore(3 * i);
        }
        else if (rageManger.currentRage >= 1200)
        {
            score.AddScore(4 * i);
        }
        else if (rageManger.currentRage >= 1600)
        {
            Debug.Log("MILLEMILAAA!!");
            //ActiveClient(false);
            //ChangeClient?.Invoke();
        }
        else if (rageManger.currentRage <= 0)
        {
            score.AddScore(-2 * i);
            //Debug.Log("ZEROOO!!");
            // tolgo una vita al player
            //ActiveClient(false);
            //ChangeClient?.Invoke();
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

    public void ChangeClientWithRage()
    {
        if (rageManger.currentRage >= 2000)
        {
            ActiveClient(false);
            ChangeClient?.Invoke();
        }

        if (rageManger.currentRage >= 0)
        {
            ActiveClient(false);
            ChangeClient?.Invoke();
        }
    }
}
