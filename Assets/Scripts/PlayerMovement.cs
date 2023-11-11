using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public Rigidbody rb;
    private bool isFacingRight = true;
    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 16f;
    private CapsuleCollider myCollider;
    
   
    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask groundLayerS;
    public LayerMask groundLayer0;
    private bool isJump=false;


    [Header("Dash Variables")]
    private bool canDash = true;
    private bool isDashing;
    private float dashPower=14f;
    private float dashTime=0.2f;
    private float dashCooldown=2f;
    [SerializeField]private bool isPowerUp=false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        Physics.gravity = new Vector3(0, -22, 0);
    }

    private void Update()
    {
        if(isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash && isPowerUp)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.S) && IsGroundedS())
        {
            myCollider.enabled = false;
     
        }
        else if (Input.GetKeyUp(KeyCode.S) || IsGrounded0())
        {
           myCollider.enabled = true;

        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (!isJump && IsGrounded())
        {
            

            if (context.performed && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                isJump = true;
                
            }

        }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
           
            }

        if (IsGrounded())
        {
            isJump = false;
            
        }
    }
    private bool IsGrounded0()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer0); 
        
        
        //return GetComponent<Rigidbody>().velocity.y <= 0;
    }private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer); 
       
        
        //return GetComponent<Rigidbody>().velocity.y <= 0;
    }
    
    private bool IsGroundedS()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayerS);
        
        //return GetComponent<Rigidbody>().velocity.y <= 0;
    }

    private void Flip() 
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.useGravity = false;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        yield return new WaitForSeconds(dashTime);
        rb.useGravity = true;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        
    }
}
