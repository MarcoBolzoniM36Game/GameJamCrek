using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehavior : MonoBehaviour
{
    
    public RageBarManager rageBarManager;
    [SerializeField]
    private GameFlowManager gameFlowManager;
    [SerializeField]
    private VendingMachineManager vendingMachineManager;
    public ClientManager cm;

    //[SerializeField]
    //private GameObject vfxPrefab;
    public PlayerHealth H;


    public TestAudio pippo;

    private void Start()
    {
        //rageBarManager = GetComponent<RageBarManager>();
    }
    public void ClientSatisfied()
    {
        Debug.Log("CIBO PRESO DAL CLIENT");
        
        gameFlowManager.RestartGameFlow();
        vendingMachineManager.SelectPlatform(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject c = other.gameObject;

        Client cl = cm.currentClient.GetComponent<Client>();

        if (other.CompareTag("cazzo"))
        {

               Destroy(c);
               CameraShake.Invoke();
               pippo.Play("Drop");

               rageBarManager.Satisfied(400);

            if (cl != null && rageBarManager.currentRage == 2000)
            {
                return;
            }
            else if (cl != null && rageBarManager.currentRage == 0)
            {
                cm.ActiveClient(false);
                cl.targhetta.SetActive(false);
                ClientSatisfied();
            }
            else if (cl != null)
            {
                vendingMachineManager.SelectFood(cl.HowManyFoodDrop);
            }
        }
    }
}
