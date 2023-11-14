using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMovement : MonoBehaviour
{
    bool jumping;
    bool walk;
    Animator anim;
    Rigidbody rb;
    CapsuleCollider myCollider;
    public float velo = 10;
    public Vector2 axisRow;
    public Transform pivot;
    public LayerMask groundLayer;
    public LayerMask groundLayerS;
    public LayerMask groundLayer0;

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.S) && IsGroundedS())
        {
            myCollider.enabled = false;

        }
        else if (Input.GetKeyUp(KeyCode.S) || IsGrounded0())
        {
            myCollider.enabled = true;

        }
    }

        public void Arrows_performed(InputAction.CallbackContext obj)
    {
        axisRow = obj.ReadValue<Vector2>();

        if ((int)axisRow.x ==1)
        {
            pivot.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        if ((int)axisRow.x ==-1)
        {
            pivot.transform.localEulerAngles = new Vector3(0, -90, 0);
        }

        walk = axisRow.x != 0;
    }

    private void LateUpdate()
    {
        if (!jumping)
        {
            anim.SetBool("jumpo", axisRow.x != 0);
            //axisRow.x !=0
        }
        else 
        {
            anim.SetBool("jumpo", false);
        }

    }

    private void FixedUpdate()
    {
        if (walk)
        {
            rb.velocity = new Vector3(axisRow.x*velo, rb.velocity.y,0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            jumping = false;
        }
    }


        private bool IsGrounded0()
        {
            return Physics.CheckSphere(pivot.position, 0.2f, groundLayer0);

        }
        private bool IsGrounded()
        {
            return Physics.CheckSphere(pivot.position, 0.2f, groundLayer);

        }

    private bool IsGroundedS()
    {
        return Physics.CheckSphere(pivot.position, 0.2f, groundLayerS);

    }
}
