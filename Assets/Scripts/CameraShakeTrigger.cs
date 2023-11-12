using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
           
            CameraShake.Invoke();
            Debug.Log ("Shake");
        }

      
       
    }
}
