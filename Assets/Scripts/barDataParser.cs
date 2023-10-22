using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class barDataParser : dataParser
{
    public string jsonFilePath = @"Assets\Resources\barPoints.json";



    void Start()
    {
        GameObject manager = GameObject.Find("manager");
        barChartData barData = ParseData<barChartData>(jsonFilePath, chartType.barChart);
        bars barManager = gameObject.GetComponent<bars>();
        List<string> xlabels = barData.x.Distinct().ToList();
        List<string> zlabels = barData.z.Distinct().ToList();
        barManager.createCaptions(xlabels, zlabels, 2, 2);
        barManager.createBars(4, 4, barData.value, 1, 1, 10);
    }
}
