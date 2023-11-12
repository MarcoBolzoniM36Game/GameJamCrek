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

    public void ClientSatisfied()
    {
        Debug.Log("CIBO PRESO DAL CLIENT");
        rageBarManager.Satisfied(400);
        gameFlowManager.RestartGameFlow();
        vendingMachineManager.SelectPlatform(2);
    }
}
