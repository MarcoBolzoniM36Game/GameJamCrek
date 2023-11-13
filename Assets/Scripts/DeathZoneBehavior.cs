using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehavior : MonoBehaviour
{
    [SerializeField]
    private RageBarManager rageBarManager;
    [SerializeField]
    private GameFlowManager gameFlowManager;
    [SerializeField]
    private VendingMachineManager vendingMachineManager;

    //[SerializeField]
    //private GameObject vfxPrefab;
    public PlayerHealth H;


    public TestAudio pippo;

    private void Start()
    {
        rageBarManager = GetComponent<RageBarManager>();
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
        if (other.CompareTag("cazzo"))
        {
            //DeathZoneBehavior dzb = other.gameObject.GetComponent<DeathZoneBehavior>();
            //if (dzb != null)
            //{
            //}
            Destroy(c);
            CameraShake.Invoke();
            pippo.Play("Drop");
            H.TakeDamage(25);
            ClientSatisfied();
            rageBarManager.Satisfied(400);
        }
    }
}
