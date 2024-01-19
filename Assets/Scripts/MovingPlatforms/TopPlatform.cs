using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlatform : MonoBehaviour
{
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        transform.position -= new Vector3(0, 0.02f, 0);
        if (_timer >= 15)
        {
            Destroy(this.gameObject);
            _timer = 0;
        }
    }
}
