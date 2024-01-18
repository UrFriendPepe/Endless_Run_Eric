using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    private static God instance = new God();
    public static God Instance 
    {
        get { return instance; }
    }

    public int population;
    
    private God()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        God.Instance.population = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
