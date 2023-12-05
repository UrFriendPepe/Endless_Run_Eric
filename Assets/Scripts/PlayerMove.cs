using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GravitySC _refToGravitySC;
    Rigidbody2D _rb;
    float _speed = 0.01f;
    float _force = 20f;
    GameObject _mouse;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mouse = GameObject.Find("Mouse");
        _refToGravitySC = GameObject.Find("GameManager").GetComponent<GravitySC>();
    }

    // Update is called once per frame
    void Update()
    {
        //XMovement();
        //YMovement();
    }

    public void XMovement()
    {
        //float dirX = Input.GetAxis("Horizontal");
        //_rb.velocity = new Vector2(dirX * _speed, _rb.velocity.y);
        if (_mouse.transform.position.x > this.transform.position.x)
        {
            transform.position += new Vector3(_speed, 0, 0);
        }
        else if (_mouse.transform.position.x < this.transform.position.x)
        {
            transform.position -= new Vector3(_speed, 0, 0);
        }
    }

    public void YMovement()
    {
        //float dirY = Input.GetAxis("Vertical");
        //_rb.velocity = new Vector2(_rb.velocity.x, dirY * _speed);
        if (_mouse.transform.position.y > this.transform.position.y)
        {
            transform.position += new Vector3(0, _speed, 0);
        }
        else if (_mouse.transform.position.y < this.transform.position.y)
        {
            transform.position -= new Vector3(0, _speed, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(_refToGravitySC.GS == GravitySC.GravityState.Down)
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
