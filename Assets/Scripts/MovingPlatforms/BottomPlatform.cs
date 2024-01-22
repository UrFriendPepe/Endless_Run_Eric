using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPlatform : MonoBehaviour
{
    float _timer;
    float _speed = MovingPlatforms.Instance._speed;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        transform.position += new Vector3(0, _speed, 0);
        if (_timer >= 60)
        {
            Destroy(this.gameObject);
            _timer = 0;
        }
    }
}
