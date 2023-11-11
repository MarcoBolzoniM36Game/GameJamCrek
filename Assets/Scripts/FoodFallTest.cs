using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFallTesty : MonoBehaviour
{
    
    private Rigidbody rb;

    
    private bool isFalling = false;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        
        rb.useGravity = false;

        
        GetComponent<Collider>().enabled = false;
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            // Attiva la gravità
            rb.useGravity = true;

            
            GetComponent<Collider>().enabled = true;

            
            isFalling = true;
        }
    }

    // Animator anim

    // PlayerHealthManager healthManager

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // TODO: eventuale animazione di esplosione
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("DeathZone"))
            {
                // riduzione della vita del player
                // healthManager.
                Destroy(gameObject);
            }
        }
    }
}
