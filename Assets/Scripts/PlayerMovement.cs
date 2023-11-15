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
    public Vector2 axis;
    private float speed = 5f;
    private float jumpPower = 10f;
    public CapsuleCollider myCollider;
    public Animator anim;
    public AudioSource jump;
    public Transform myTransform;
    //public int RX = 90;
    //public int SX = -90;


    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask groundLayerS;
    public LayerMask groundLayer0;
    private bool isJump=false;

    //public bool jumping=false;


    [Header("Dash Variables")]
    public bool canDash = false;
    private bool isDashing;
    private float dashPower=30F;
    private float dashTime=0.2f;
    private float dashCooldown=2f;
    [SerializeField]private bool isPowerUp=false;


    [SerializeField]
    private GameObject vfxPrefab;
    public PlayerHealth H;
    public RageBarManager rageBarManager;
    public VendingMachineManager vendingMachineManager;
    public ClientManager cm;
    public GameFlowManager gmf;


    public TestAudio pippo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        //cm = GetComponent<ClientManager>();
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

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && isPowerUp)
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

        if ((int)axis.x ==1)
        {
            //myTransform.transform.rotation = Quaternion.Euler(0, 90, 0);
            myTransform.transform.localEulerAngles = new Vector3(0, 80, 0);
        }

        else if ((int)axis.x == -1)
        {
            //myTransform.transform.transform.rotation = Quaternion.Euler(0, -90, 0);
            myTransform.transform.localEulerAngles = new Vector3(0, -80, 0);
        }
        else if((int)axis.x == 0)
        {
            myTransform.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        //if (!jumping)
        //{
        //    anim.SetBool("Muovo", axis.x != 0);
        //}
        //else
        //{
        //    anim.SetBool("Muovo", false);
        //}

        if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.S)))
        {
            anim.SetBool("Jumpo", true);
            jump.Play();
        }
        else
        {
            anim.SetBool("Jumpo", false);
        }




    }

    [SerializeField]
    private GameFlowManager gameFlowManager;
    public void RestartGameFlow()
    {
        gameFlowManager.RestartGameFlow();
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
        Client cl = cm.currentClient.GetComponent<Client>();
        if (cl.canActiveDash)
        {
            canDash = true;
        }
        else if (cl.canActiveDash==false)
        {
            canDash = false;
        }
    }


    //private void LateUpdate()
    //{


    //}




    private bool IsGrounded0()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer0); 
        
        
        //return GetComponent<Rigidbody>().velocity.y <= 0;
    }
    private bool IsGrounded()
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
        Vector3 newRotation= new Vector3(0, 60, 0);
        horizontal = context.ReadValue<Vector2>().x;
        axis = context.ReadValue<Vector2>();

        if (context.started)
        {
            anim.SetBool("Muovo", true);
        }
        if (context.canceled)
        {
            anim.SetBool("Muovo", false);
        }


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

    private void OnTriggerEnter(Collider other)
    {
        GameObject c = other.gameObject;

        Client cl = cm.currentClient.GetComponent<Client>();

        //if (other.gameObject.layer == 6)
        //{
        //    jumping = false;
        //}   
        //if (other.gameObject.layer == 7)
        //{
        //    jumping = false;
        //}

        if (other.CompareTag("cazzo"))
        {
            Destroy(c);

            Instantiate(vfxPrefab, transform.position, Quaternion.identity);

            pippo.Play("Puff");

            rageBarManager.AddRage(400);

            if (cl != null && rageBarManager.currentRage ==2000) 
            {
                cm.ActiveClient(false);
                cl.targhetta.SetActive(false);
                gmf.RestartGameFlow();
            }
            else if (cl != null)
            {
                if (cl.HowManyFoodDrop==2) 
                {
                    vendingMachineManager.SelectFood(cl.HowManyFoodDrop/2);
                }
                else 
                {
                vendingMachineManager.SelectFood(cl.HowManyFoodDrop);
                }
            }
        }

    }
    
}
