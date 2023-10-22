using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class dataParser : MonoBehaviour
{
    public enum chartType {barChart, scatterPlot};

    protected T ParseData<T>(string filePath, chartType dataType)
    {
        string jsonText = System.IO.File.ReadAllText(filePath);

        switch (dataType)
        {
            case chartType.barChart:
                return JsonConvert.DeserializeObject<T>(jsonText);
            case chartType.scatterPlot:
                return JsonConvert.DeserializeObject<T>(jsonText);
            default:
                Debug.LogError("Unsupported data type");
                return default(T);
        }
    }


    
}
