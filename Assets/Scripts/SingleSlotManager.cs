using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSlotManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlatLight;

    [SerializeField]
    private GameObject Platform;

    [SerializeField]
    private Transform StartProductPosition;

    public Transform[] ProductStartPoints;

    public List<GameObject> SlotProducts = new List<GameObject>();

    public GameObject SlotLight;

    private Transform startSpiralRotation;
    private Transform startProductsPosition;

    [SerializeField]
    private Animator Anim;

    [SerializeField]
    private Animator Anim2;



    public void Illuminate()
    {
        if (SlotLight != null)
        {
            //Debug.Log("Illumino slot ");
            PlatLight.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            //SlotLight.Enable();
        }
    }

    public void Deilluminate()
    {
        if (SlotLight != null)
        {
            //Debug.Log("Deillumino slot ");
            PlatLight.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
            //SlotLight.Enable();
        }
    }

    public void HidePlatform()
    {
        if (Platform != null)
        {
            Platform.SetActive(false);
            // TODO: avviare il particleSystem per la distruzione 
        }
    }

    public void ShowPlatform()
    {
        if (Platform != null)
        {
            Platform.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Illuminate();
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    HidePlatform();
        //}
    }

    public void FoodFall()
    {
        Debug.Log("FoodFall");
        // ruota spirale
        // sposta pivot padre
        StartCoroutine(nameof(MoveProduct));
    }

    private IEnumerator MoveProduct()
    {
        Anim.SetBool("RotateSpring", true);
        Anim2.SetInteger("Index", SlotProducts.Count - 1);
        Anim2.SetTrigger("MoveFall");
        yield return new WaitForSeconds(2);
        Anim.SetBool("RotateSpring", false);
        // sgancia oggetto
        GameObject go = SlotProducts[SlotProducts.Count - 1];
        go.transform.parent = null;
        SlotProducts.Remove(go);
        Collider c = go.GetComponent<Collider>();
        c.enabled = true;
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }


}
