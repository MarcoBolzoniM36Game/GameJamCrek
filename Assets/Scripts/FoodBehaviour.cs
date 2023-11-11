using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);

            }
        }





    }
}
