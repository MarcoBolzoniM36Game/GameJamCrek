using UnityEngine;


public class RageBarManager : MonoBehaviour
{
    public Gradient gradient;
    public UnityEngine.UI.Image filledBar;
    public int minRage, maxRage;
    public int currentRage;
    public RectTransform iconaRage;
    public PlayerHealth health;


    private void Start()
    {
        health = GetComponent<PlayerHealth>();

        currentRage = 400;
       
        iconaRage.anchoredPosition = new Vector2(currentRage, 0);


    }
    public void AddRage(int points)
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
            Debug.Log("PERSO");
            currentRage = 400;
            iconaRage.anchoredPosition = new Vector2(currentRage, 0);
            health.TakeDamage(25);
        }

    }



  
}


