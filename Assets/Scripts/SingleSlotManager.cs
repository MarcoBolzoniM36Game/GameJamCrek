using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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

    [SerializeField]
    private Light slotLight;

    public TestAudio pippo;

    public void Illuminate()
    {
        if (SlotLight != null)
        {
            slotLight.enabled = true;
        }
    }

    public bool IsEmpty { get { return (SlotProducts.Count == 0); } }
    
    public void Deilluminate()
    {
        if (SlotLight != null)
        {
            slotLight.enabled = false;
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

    void Start()
    {
        slotLight.enabled = false;
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
        pippo.Play("Mechanism");
        if (SlotProducts.Count > 0)
        {
            Debug.Log("SlotProducts.Count: " + SlotProducts.Count);
            int index = SlotProducts.Count - 1;
            if (index >= 0 && index < SlotProducts.Count)
            {
                Anim2.SetInteger("Index", index);
                Anim2.SetTrigger("MoveFall");
                yield return new WaitForSeconds(2);
                Anim.SetBool("RotateSpring", false);
                // sgancia oggetto
                if (index >= 0 && index < SlotProducts.Count)
                {
                    GameObject go = SlotProducts[index];
                    if (go != null)
                    {
                        go.transform.parent = null;
                        SlotProducts.Remove(go);
                        Collider c = go.GetComponent<Collider>();
                        c.enabled = true;
                        Rigidbody rb = go.GetComponent<Rigidbody>();
                        rb.useGravity = true;
                    }
                }
            }
        }
    }

}
