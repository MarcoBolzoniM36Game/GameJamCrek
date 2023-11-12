using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
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
    public Material myMaterial;

    private Transform startSpiralRotation;
    private Transform startProductsPosition;

    [SerializeField]
    private Animator Anim;

    [SerializeField]
    private Animator Anim2;

    [SerializeField]
    private GameObject vfxPrefab;
    [SerializeField]
    private Transform vfxSpawn;

    public void Illuminate()
    {
        if (SlotLight != null)
        {
            myMaterial.SetFloat("_FrePower", 0);
            Debug.Log("Illumino slot ");
            //PlatLight.GetComponent<MeshRenderer>().material.SetFloat("_FrePower", 0);
            //SlotLight.Enable();
        }
    }

    public void Deilluminate()
    {
        if (SlotLight != null)
        {
            myMaterial.SetFloat("_FrePower", 5);
            //Debug.Log("Deillumino slot ");
            //PlatLight.GetComponent<MeshRenderer>().material.SetFloat("_FrePower", 5);
            //SlotLight.Enable();
        }
    }

    public void HidePlatform()
    {
        if (Platform != null)
        {
            if (Platform.activeSelf) {
                Platform.SetActive(false);
                if (vfxPrefab != null)
                {
                    Instantiate(vfxPrefab, vfxSpawn.position, Quaternion.identity);
                }
            }
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
