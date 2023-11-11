using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class VendingMachineManager : MonoBehaviour
{

    //[SerializeField]
    //private List<GameObject> cells = new List<GameObject>();
    private List<int> chosenNumber = new List<int>();
    private List<int> chosenPlatformNumber = new List<int>();

    [SerializeField]
    private GameObject SlotPrefab;

    [SerializeField]
    private List<GameObject> Slots = new List<GameObject>();

    [SerializeField]
    private Transform SlotStartPoint;

    [SerializeField]
    private List<GameObject> productsPrefabs = new List<GameObject>();

    private void Start()
    {
        SetupMachine(6, 6);
    }

    /// <summary>
    /// Esegue il setup dell'intero distributore automatico
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public void SetupMachine(int row = 6, int col = 6)
    {
        if (Slots == null)
        {
            Slots = new List<GameObject>();
        }
        Slots.Clear();
        for (int i = 0; i < row * col; i++)
        {
            Vector3 pos = new Vector3(0f, -(i / 6) * 0.182323f * 10f, -(i % 6) * 0.1382006f * 10f);
            pos += SlotStartPoint.position;

            GameObject slot = Instantiate(SlotPrefab, pos, Quaternion.identity, gameObject.transform);
            SingleSlotManager ssm = slot.GetComponent<SingleSlotManager>();
            SetupSlot(ssm, 4, pos);

            Slots.Add(slot);
        }

    }

    /// <summary>
    /// Esegue il setup del singolo slot del distributore
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="maxProduct"></param>
    /// <param name="slotPos"></param>
    public void SetupSlot(SingleSlotManager slot, int maxProduct, Vector3 slotPos)
    {
        for (int i = 0; i < maxProduct; i++)
        {
            GameObject prefab = productsPrefabs[Random.Range(0, productsPrefabs.Count)];
            GameObject product = Instantiate(prefab, slot.ProductStartPoints[i].position, Quaternion.identity, slot.ProductStartPoints[i]);
            slot.SlotProducts.Add(product);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SelectFood(3);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SelectPlatform(4);
        }
    }


    public void SelectFood(int howManyFoodDrop)
    {
        chosenNumber.Clear();
        for (int i = 0; i < howManyFoodDrop; i++)
        {
            int rumble;
            bool exit = false;
            do
            {
                rumble = Random.Range(0, Slots.Count);
                if (!chosenNumber.Exists(o => o == rumble))
                {
                    exit = true;
                }
            }
            while (!exit);
           

            chosenNumber.Add(rumble);
        }
        DropFood();
    }

    private void DropFood()
    {
        for(int i = 0; i < chosenNumber.Count;i++) 
        {
            int slotChoosed = chosenNumber[i];
            StartCoroutine(nameof(IlluminateSlot), slotChoosed);
        }
        chosenNumber.Clear();
    }

    private IEnumerator IlluminateSlot(int slotChoosed)
    {
        SingleSlotManager ssm = Slots[slotChoosed].GetComponent<SingleSlotManager>();
        if (ssm != null)
        {
            ssm.Illuminate();
            //Debug.Log("ILLUMINO " + slotChoosed + " Slot");
            yield return new WaitForSeconds(3);
            ssm.Deilluminate();
            //Debug.Log("DEILLUMINO" + slotChoosed + " Slot");
            ssm.FoodFall();
        }
    }


    public void SelectPlatform(int howManyPlatformDestroy)
    {
        chosenPlatformNumber.Clear();
        for (int i = 0; i < howManyPlatformDestroy; i++)
        {
            int rumble;
            bool exit = false;
            do
            {
                rumble = Random.Range(0, Slots.Count);
                if (!chosenPlatformNumber.Exists(o => o == rumble))
                {
                    exit = true;
                }
            }
            while (!exit);

            chosenPlatformNumber.Add(rumble);
        }
        DestroyPlatforms();
    }

    private void DestroyPlatforms()
    {
        for (int i = 0; i < chosenPlatformNumber.Count; i++)
        {
            int slotChoosed = chosenPlatformNumber[i];
            SingleSlotManager ssm = Slots[slotChoosed].GetComponent<SingleSlotManager>();
            ssm.HidePlatform();
        }
        chosenPlatformNumber.Clear();
    }

    //private void FoodFall(int cellsIndex)
    //{


    //}
}
