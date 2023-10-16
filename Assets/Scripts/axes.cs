using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axes : MonoBehaviour
{
    // Start is called before the first frame update
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public Color c3 = Color.green;
    
    private LineRenderer lineRenderer1;
    private LineRenderer lineRenderer2;
    private LineRenderer lineRenderer3;
    
    public GameObject conePrefab; 
    void Start()
    {
        lineRenderer1 = gameObject.AddComponent<LineRenderer>();
        lineRenderer1.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer1.widthMultiplier = 0.2f;
        var child1 = new GameObject();
        child1.transform.SetParent( transform);
        lineRenderer2 = child1.AddComponent<LineRenderer>();
        lineRenderer2.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer2.widthMultiplier = 0.2f;
        var child2 = new GameObject();
        child2.transform.SetParent( transform);
        lineRenderer3 = child2.AddComponent<LineRenderer>();
        lineRenderer3.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer3.widthMultiplier = 0.2f;
        create3DAxes(new Vector3(0, 0, 0), 10);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void create3DAxes( Vector3 origin, int length)
    {
        lineRenderer1.startColor = Color.black; 
        lineRenderer1.endColor = Color.black;
        lineRenderer1.SetPosition(0, origin);
        lineRenderer1.SetPosition(1, origin + new Vector3(length, 0, 0));
        Vector3 direction1 = new Vector3(length, 0, 0) - origin;
        Instantiate(conePrefab, new Vector3(length, 0, 0), Quaternion.Euler(direction1.x, direction1.y, direction1.z));
        lineRenderer2.startColor = Color.black;
        lineRenderer2.endColor = Color.black;
        lineRenderer2.SetPosition(0, origin);
        lineRenderer2.SetPosition(1, origin + new Vector3(0, length, 0));
        Vector3 direction2 = new Vector3(0, length, 0) - origin;
        Instantiate(conePrefab, new Vector3(length, 0, 0), Quaternion.Euler(direction2.x, direction2.y, direction2.z));
        lineRenderer3.startColor = Color.black;
        lineRenderer3.endColor = Color.black;
        lineRenderer3.SetPosition(0, origin);
        lineRenderer3.SetPosition(1, origin + new Vector3(0, 0, length));
        Vector3 direction3 = new Vector3(0, 0, length) - origin;
        Instantiate(conePrefab, new Vector3(length, 0, 0), Quaternion.Euler(direction3.x, direction3.y, direction3.z));
    }
}
