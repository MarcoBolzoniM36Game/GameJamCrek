using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField]
    private ClientManager clientManager;

    float StartDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool once = true;

    void Update()
    {
        if (once)
        {
            Debug.Log("ONCE");
            StartCoroutine(nameof(AptendDelay));
        }
    }

    public IEnumerator AptendDelay()
    {
        once = false;
        yield return new WaitForSeconds(StartDelay);
        // attendo la scadenza di un timer e
        // poi lancio un evento di scelta e avvio di un client
        clientManager.ActiveClient(true);
        clientManager.CountClient();

        Debug.Log("ONCE COROUTINE");
    }

    public void RestartGameFlow()
    {
        once = true;
    }



}
