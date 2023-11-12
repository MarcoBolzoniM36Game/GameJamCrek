using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject vfxPrefab;

    
    public TestAudio pippo;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            DeathZoneBehavior dzb = other.gameObject.GetComponent<DeathZoneBehavior>();
            if (dzb != null)
            {
                dzb.ClientSatisfied();
            }
            Destroy(gameObject);
            CameraShake.Invoke();
            pippo.Play("Drop");
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
                if (pm != null)
                {
                    pm.RestartGameFlow();
                }
                Destroy(gameObject);
                Instantiate(vfxPrefab, transform.position, Quaternion.identity);

                pippo.Play("Puff");

                //if (vfxPrefab != null)
                //{
                   

                //}
            }
        }





    }
}
