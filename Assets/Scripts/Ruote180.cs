using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Ruote180 : MonoBehaviour
{
    
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //  gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        //}

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
