using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
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
        MouseMove();
    }
    void MouseMove()
    {
        Cursor.visible = false;
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0,0,10);
    }
}
