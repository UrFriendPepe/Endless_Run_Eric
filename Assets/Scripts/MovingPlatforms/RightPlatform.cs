using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlatform : MonoBehaviour
{
    float _timer;
    float _speed = MovingPlatforms.Instance._speed;
    float _platformDestoryTime = MovingPlatforms.Instance.PlatformDestoryTime;
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
        transform.position += new Vector3(-_speed, 0, 0);
        if (_timer >= _platformDestoryTime)
        {
            Destroy(this.gameObject);
            _timer = 0;
        }
    }
}
