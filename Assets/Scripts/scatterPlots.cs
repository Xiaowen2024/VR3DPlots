using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scatterPlots : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject captionPrefab;
    void Start()
    {
       
        List<scatterPlotData> dataList = new List<scatterPlotData>();
        for (int i = 0; i < 50; i++)
        {
            scatterPlotData data = new scatterPlotData();
            data.x = Random.Range(0, 10);
            data.y = Random.Range(0, 10);
            data.z = Random.Range(0, 10);
            dataList.Add(data);
        }
        createCaptions(10, 10, 2, 2, 10, dataList);
        createScatterDots(dataList, 10);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createCaptions(float rangeAlongX, float rangeAlongZ, int gapAlongX, int gapAlongZ,int axisLength, List<scatterPlotData> data){
        int[] maxValues = getMax(data);
        int maxY = maxValues[1];
        for (int i = 0; i < axisLength; i+= gapAlongX)
        {
            GameObject caption = Instantiate(captionPrefab, new Vector3(i * gapAlongX, 0, 0), Quaternion.identity);
            caption.transform.SetParent(transform);
            caption.GetComponent<TextMesh>().text = (rangeAlongX / i).ToString();
            caption.GetComponent<TextMesh>().color = Color.black;
            caption.GetComponent<TextMesh>().fontSize =  8;
        }
        for (int i = 1; i < axisLength; i+= gapAlongZ)
        {
            GameObject caption = Instantiate(captionPrefab, new Vector3(0, 0, i * gapAlongZ), Quaternion.identity);
            caption.transform.SetParent(transform);
            caption.GetComponent<TextMesh>().text = (rangeAlongZ / i).ToString();
            caption.GetComponent<TextMesh>().color = Color.black;
            caption.GetComponent<TextMesh>().fontSize =  8;
        }
        int numberOfMarkers =  axisLength / gapAlongX * 2;
        for (int i = 0; i < numberOfMarkers; i ++){
            Vector3 pos = new Vector3(-1, i * axisLength / numberOfMarkers, 0);
            GameObject caption = Instantiate(captionPrefab, new Vector3(0, i * axisLength / numberOfMarkers, 0), Quaternion.identity);
            caption.transform.SetParent(transform);
            caption.GetComponent<TextMesh>().text = maxY * i/ numberOfMarkers  + "";
            caption.GetComponent<TextMesh>().color = Color.black;
            caption.GetComponent<TextMesh>().fontSize =  8;
        } 
    }

    public void createScatterDots(List<scatterPlotData> data, int axisLength){
        int[] maxValues = getMax(data);
        int maxX = maxValues[0];
        int maxY = maxValues[1];
        int maxZ = maxValues[2];
        for (int i = 0; i < data.Count; i++)
        {
            GameObject dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            dot.transform.position = new Vector3(data[i].x * axisLength / maxX, data[i].y * axisLength / maxY, data[i].z * axisLength / maxZ);
            dot.transform.SetParent(transform);
            dot.GetComponent<Renderer>().material.color = Color.blue;
        }

    }

    int[] getMax(List<scatterPlotData> data){
        int maxX = int.MinValue;
        int maxY = int.MinValue;
        int maxZ = int.MinValue;
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].x > maxX){
                maxX = data[i].x;
            }
            if (data[i].y > maxY){
                maxY = data[i].y;
            }
            if (data[i].z > maxZ){
                maxZ = data[i].z;
            }
        }
        int[] reesult = {maxX, maxY, maxZ};
        return reesult;
    }
}
