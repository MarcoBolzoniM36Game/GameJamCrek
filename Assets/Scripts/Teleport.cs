using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 teleport; 
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(teleport.x, teleport.y, teleport.z);
    }
}
