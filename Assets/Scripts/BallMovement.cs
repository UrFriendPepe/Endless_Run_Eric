using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    GravitySC _refToGravitySC;
    Rigidbody2D _rb;
    float _force = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _refToGravitySC = GameObject.Find("GameManager").GetComponent<GravitySC>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_refToGravitySC.GS == GravitySC.GravityState.Down)
        {
            if (collision.gameObject.CompareTag("BottomPlatform"))
            {
                _rb.AddForce(Vector3.up * _force, ForceMode2D.Impulse);
            }
        }

        if (_refToGravitySC.GS == GravitySC.GravityState.Up)
        {
            if (collision.gameObject.CompareTag("TopPlatform"))
            {
                _rb.AddForce(Vector3.down * _force, ForceMode2D.Impulse);
            }
        }

        if (_refToGravitySC.GS == GravitySC.GravityState.Left)
        {
            if (collision.gameObject.CompareTag("LeftPlatform"))
            {
                _rb.AddForce(Vector3.right * _force, ForceMode2D.Impulse);
                print("111111");
            }
        }

        if (_refToGravitySC.GS == GravitySC.GravityState.Right)
        {
            if (collision.gameObject.CompareTag("RightPlatform"))
            {
                _rb.AddForce(Vector3.left * _force, ForceMode2D.Impulse);
            }
        }

    }
}
