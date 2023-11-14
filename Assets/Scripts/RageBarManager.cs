using UnityEngine;


public class RageBarManager : MonoBehaviour
{
    public Gradient gradient;
    public UnityEngine.UI.Image filledBar;
    public int minRage, maxRage;
    public int currentRage;
    public RectTransform iconaRage;
    public PlayerHealth health;
    public DeathZoneBehavior dz;
    public GameFlowManager gfm;
    public ClientManager clm;

    public bool canChange = false;

    private void Start()
    {
        //health = GetComponent<PlayerHealth>();

        //dz = GetComponent<DeathZoneBehavior>();

        currentRage = 400;
       
        iconaRage.anchoredPosition = new Vector2(currentRage, 0);



    }
    public void AddRage(int points)
    {
        currentRage = (currentRage + points);
        float nuovaPosizioneX = filledBar.rectTransform.sizeDelta.x * currentRage * 0.001f;
        iconaRage.anchoredPosition = new Vector2(nuovaPosizioneX, iconaRage.anchoredPosition.y);
        iconaRage.anchoredPosition = new Vector2(currentRage, 0);
        canChange = true;



        if (currentRage ==2000)
        {

            
            Invoke("Rage400", 2f);
            iconaRage.anchoredPosition = new Vector2(currentRage, 0);
            Invoke("Fake0", 2f);
            Debug.Log("Rabbia Massima");
           
            //if (clm !=null ) 
            //{ 
            //  clm.ActiveClient(false);
            //}

            //if (gfm != null)
            //{
            //    //gfm.RestartGameFlow();
            //}

        }



    }

    public void Satisfied(int points)
    {

        currentRage = (currentRage - points);
        float nuovaPosizioneX = filledBar.rectTransform.sizeDelta.x * currentRage * 0.001f;
        iconaRage.anchoredPosition = new Vector2(nuovaPosizioneX, iconaRage.anchoredPosition.y);
        iconaRage.anchoredPosition = new Vector2(currentRage, 0);
        canChange = true;

        if (currentRage == 0)
        {
            int nw = 400;
            Debug.Log("PERSO");
            Invoke("Rage400", 1f);
            Invoke("Fake0", 2f);
            iconaRage.anchoredPosition = new Vector2(currentRage, 0);
            health.TakeDamage(25);
            
            //if (clm != null)
            //{
            //    clm.ActiveClient(false);
            //}

            //dz.ClientSatisfied();
        }

    }
    void Rage400()
    {
        currentRage = 400;
    }

    void Fake0()
    {
        iconaRage.anchoredPosition = new Vector2(400, 0);
    }
    



  
}


