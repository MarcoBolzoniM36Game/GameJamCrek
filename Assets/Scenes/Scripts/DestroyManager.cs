using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    public GameObject vfxPrefab;

   

    void Update()
        {
           
            if (Input.GetKeyDown(KeyCode.P))
            {
              
                Destroy(gameObject);
            }
        }
    private void OnDestroy()
    {
        if (vfxPrefab != null)
        {
            Instantiate(vfxPrefab, transform.position, Quaternion.identity);
            Debug.Log("Kaboom");
        }

    }
}

