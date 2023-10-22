using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bars : MonoBehaviour
{
    public GameObject captionPrefab;
    void Start()
    {

     
    } 

    void Update()
    {
        
    }

    public void createCaptions(List<string> labelsAlongX, List<string> labelsAlongZ, int gapAlongX, int gapAlongZ){
        for (int i = 0; i < labelsAlongX.Count; i++)
        {
            GameObject caption = Instantiate(captionPrefab, new Vector3(i * gapAlongX, 0, 0), Quaternion.identity);
            caption.transform.SetParent(transform);
            caption.GetComponent<TextMesh>().text = labelsAlongX[i];
            caption.GetComponent<TextMesh>().color = Color.black;
            caption.GetComponent<TextMesh>().fontSize =  8;
        }
        for (int i = 1; i < labelsAlongZ.Count; i++)
        {
            Vector3 alongZ = new Vector3(0, 1, 0) - new Vector3(0, 0, 0);
            GameObject caption = Instantiate(captionPrefab, new Vector3(0, 0, i * gapAlongZ), Quaternion.Euler(alongZ.x, alongZ.y, alongZ.z));
            caption.transform.SetParent(transform);
            caption.GetComponent<TextMesh>().text = labelsAlongZ[i];
            caption.GetComponent<TextMesh>().color = Color.black;
            caption.GetComponent<TextMesh>().fontSize =  8;
        }
    } 

    public void createBars(int numberAlongX, int numberAlongZ, List<int> heights, int gapAlongX, int gapAlongZ, int axisLength){
        int maxHeight = getMaxHeight(heights);
        for (int i = 0; i < numberAlongX; i++)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            GameObject bar = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bar.transform.position = new Vector3(i * gapAlongX + 1, 0.5f +(float) (heights[i] * axisLength / maxHeight )/ 2, 1 + i * gapAlongZ);
            bar.transform.localScale = new Vector3(1f, heights[i] * axisLength / maxHeight, 1f );
            bar.transform.SetParent(transform);
            bar.GetComponent<Renderer>().material.color = newColor;
        }
        int numberOfMarkers = numberAlongX * 2;
        for (int i = 0; i < numberOfMarkers; i ++){
            Vector3 pos = new Vector3(-1, i * axisLength / numberOfMarkers, 0);
            GameObject caption = Instantiate(captionPrefab, new Vector3(0, i * axisLength / numberOfMarkers, 0), Quaternion.identity);
            caption.transform.SetParent(transform);
            caption.GetComponent<TextMesh>().text = maxHeight / numberOfMarkers * i + "";
            caption.GetComponent<TextMesh>().color = Color.black;
            caption.GetComponent<TextMesh>().fontSize =  8;
        } 
    
    }

    int getMaxHeight (List<int> heights){
        int maxHeight = heights[0];
        for (int i = 0; i < heights.Count; i++)
        {
            if (heights[i] > maxHeight)
            {
                    maxHeight = heights[i];
            }
        }
        return maxHeight;
    }
}
