using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField]
    private ClientManager clientManager;

    float StartDelay = 3f;
    float lastTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (currentTime >= lastTime + StartDelay)
        {

            // attendo la scadenza di un timer e
            // poi lancio un evento di scelta e avvio di un client
            clientManager.ActiveClient(true);
            clientManager.CountClient();






            lastTime = currentTime;
        }
    }
}
