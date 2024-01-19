using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    GameObject _mouse;
    // Start is called before the first frame update
    void Start()
    {
        _mouse = GameObject.Find("Mouse");
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = (_mouse.transform.position - this.transform.position);
    }
}
