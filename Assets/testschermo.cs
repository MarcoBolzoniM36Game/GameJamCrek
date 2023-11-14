using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class testschermo : MonoBehaviour
{

    public List<Sprite> sprites; 
    public Image displayImage;  
    public float animationSpeed = 5f; 
    public float spinDuration = 3f;

    private int currentIndex;

 

    public void VisualizeFood()
    {
        StartCoroutine(SpinAnimation());
    }

    private IEnumerator SpinAnimation()
    {
        float elapsedTime = 0f;
        Debug.Log("CIAOOOOO!!!!");
        while (elapsedTime < spinDuration)
        {
            currentIndex = Random.Range(0, sprites.Count); 
            displayImage.sprite = sprites[currentIndex];

            elapsedTime += Time.deltaTime;

            

            yield return null;
        }

       
    }



}
