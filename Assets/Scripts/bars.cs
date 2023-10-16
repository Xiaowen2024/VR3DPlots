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
        int[,] heights = {
        {1, 2, 3, 4},
        {5, 6, 7, 8},
        {9, 10, 11, 12},
        {13, 14, 15, 16}
        };
        List<string> labelsAlongX = new List<string> {"a", "b", "c", "d"};
        List<string> labelsAlongZ = new List<string> {"a", "b", "c", "d"};
        createCaptions(labelsAlongX, labelsAlongZ, 2, 3);
        createBars(4, 4, heights, 2, 3, 10);
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
        for (int i = 1; i <labelsAlongZ.Count; i++)
        {
            Vector3 alongZ = new Vector3(0, 1, 0) - new Vector3(0, 0, 0);
            GameObject caption = Instantiate(captionPrefab, new Vector3(0, 0, i * gapAlongZ), Quaternion.Euler(alongZ.x, alongZ.y, alongZ.z));
            caption.transform.SetParent(transform);
            caption.GetComponent<TextMesh>().text = labelsAlongZ[i];
            caption.GetComponent<TextMesh>().color = Color.black;
            caption.GetComponent<TextMesh>().fontSize =  8;
        }
    }

    public void createBars(int numberAlongX, int numberAlongZ, int[,] heights, int gapAlongX, int gapAlongZ, int axisLength){
        int maxHeight = getMaxHeight(heights);
        for (int i = 0; i < numberAlongX; i++)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            for (int j = 0; j < numberAlongZ; j++)
            {
                GameObject bar = GameObject.CreatePrimitive(PrimitiveType.Cube);
                bar.transform.position = new Vector3(i * gapAlongX + 1, 0.5f +(float) (heights[i, j] * axisLength / maxHeight )/ 2, 1 + j * gapAlongZ);
                bar.transform.localScale = new Vector3(1f, heights[i, j] * axisLength / maxHeight, 1f );
                bar.transform.SetParent(transform);
                bar.GetComponent<Renderer>().material.color = newColor;
            }
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

    int getMaxHeight (int[,] heights){
        int maxHeight = heights[0, 0];
        for (int i = 0; i < heights.GetLength(0); i++)
        {
            for (int j = 0; j < heights.GetLength(1); j++)
            {
                if (heights[i, j] > maxHeight)
                {
                    maxHeight = heights[i, j];
                }
            }
        }
        return maxHeight;
    }
}
