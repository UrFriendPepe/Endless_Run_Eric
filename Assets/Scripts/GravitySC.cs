using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySC : MonoBehaviour
{
    public enum GravityState {Down,Up,Left,Right };
    public GravityState GS;
    PlayerMove _refToPlayerMove;
    Vector3 _downGravity = new Vector3(0, -9.81f, 0);
    Vector3 _upGravity = new Vector3(0,9.81f,0);
    Vector3 _leftGravity = new Vector3(-9.81f, 0, 0);
    Vector3 _rightGravity = new Vector3(9.81f, 0, 0);
    [SerializeField]
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _refToPlayerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //_timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = _downGravity;
            GS = GravityState.Down;
           // _refToPlayerMove.XMovement();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = _upGravity;
            GS = GravityState.Up;
            //_refToPlayerMove.XMovement();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = _leftGravity;
            GS = GravityState.Left;
            //_refToPlayerMove.YMovement();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = _rightGravity;
            GS = GravityState.Right;
            //_refToPlayerMove.YMovement();
        }

        if (GS == GravityState.Down || GS == GravityState.Up)
        {
            _refToPlayerMove.XMovement();
        }
        else if (GS == GravityState.Left || GS == GravityState.Right)
        {
            _refToPlayerMove.YMovement();
        }

        //if (_timer >= 20)
        //{
        //    _timer = 0;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // 在按下空格键时改变重力方向为向上
        //    Physics2D.gravity = new Vector3(-9.81f, 0, 0);
        //}
    }
}
