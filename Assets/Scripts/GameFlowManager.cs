using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField]
    private ClientManager clientManager;

    private TestAudio audio;

    float StartDelay = 3f;

    bool once = true;

    //public Difficoltà dif;



    private void Start()
    {
        audio = AudioManager.Instance.GetComponent<TestAudio>();
    }

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

        //Client cl = clientManager.currentClient.GetComponent<Client>();

        audio.Play("InsertCoin");
        once = false;
        yield return new WaitForSeconds(StartDelay);
        // attendo la scadenza di un timer e
        // poi lancio un evento di scelta e avvio di un client
        clientManager.ActiveClient(true);
        clientManager.CountClient();
        //dif.SpawnPrefabBlock(cl.blockPoint);
        

        Debug.Log("ONCE COROUTINE");
    }

    public void RestartGameFlow()
    {
        once = true;
    }



}
