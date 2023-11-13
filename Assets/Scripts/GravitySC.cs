using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySC : MonoBehaviour
{
    PlayerMove _refToPlayerSC;
    Vector3 _downGravity = new Vector3(0, -9.81f, 0);
    Vector3 _upGravity = new Vector3(0,9.81f,0);
    Vector3 _leftGravity = new Vector3(-9.81f, 0, 0);
    Vector3 _rightGravity = new Vector3(9.81f, 0, 0);
    [SerializeField]
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _refToPlayerSC = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < 5)
        {
            Physics2D.gravity = _downGravity;
            _refToPlayerSC.XMovement();
        }
        if (_timer >= 5 && _timer < 10)
        {
            Physics2D.gravity = _upGravity;
            _refToPlayerSC.XMovement();
        }
        if (_timer >= 10 && _timer < 15)
        {
            Physics2D.gravity = _leftGravity;
            _refToPlayerSC.YMovement();
        }
        if (_timer >= 15 && _timer < 20)
        {
            Physics2D.gravity = _rightGravity;
            _refToPlayerSC.YMovement();
        }
        if (_timer >= 20)
        {
            _timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 在按下空格键时改变重力方向为向上
            Physics2D.gravity = new Vector3(-9.81f, 0, 0);
        }
    }
}
