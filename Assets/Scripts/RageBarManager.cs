using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;


public class RageBarManager : MonoBehaviour
{
    public Gradient gradient;
    public UnityEngine.UI.Image filledBar;
    public int minRage, maxRage;
    public int currentRage;
    public RectTransform iconaRage;


    private void Start()
    {

        currentRage = 400;
       
        iconaRage.anchoredPosition = new Vector2(currentRage, 0);


    }
    public void Rage(int points)
    {
        currentRage = (currentRage + points);
        float nuovaPosizioneX = filledBar.rectTransform.sizeDelta.x * currentRage * 0.001f;
        iconaRage.anchoredPosition = new Vector2(nuovaPosizioneX, iconaRage.anchoredPosition.y);
        iconaRage.anchoredPosition = new Vector2(currentRage, 0);
        


        if (currentRage == 2000)
        {
            currentRage = 400;
            iconaRage.anchoredPosition = new Vector2(currentRage, 0);
            Debug.Log("Rabbia Massima");
        }

        

    }

    public void Satisfied(int points)
    {

        currentRage = (currentRage - points);
        float nuovaPosizioneX = filledBar.rectTransform.sizeDelta.x * currentRage * 0.001f;
        iconaRage.anchoredPosition = new Vector2(nuovaPosizioneX, iconaRage.anchoredPosition.y);
        iconaRage.anchoredPosition = new Vector2(currentRage, 0);

        if (currentRage == 0)
        {
            Debug.Log("ALESSIO MAZZAPIODA");
            currentRage = 400;
            iconaRage.anchoredPosition = new Vector2(currentRage, 0);
        }

    }



  
}


