using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject vfxPrefab;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {

            Destroy(gameObject);
            CameraShake.Invoke();
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                Instantiate(vfxPrefab, transform.position, Quaternion.identity);
                //if (vfxPrefab != null)
                //{
                   

                //}
            }
        }





    }
}
