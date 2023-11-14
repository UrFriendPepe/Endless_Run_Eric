using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    float _speed = 10f;
    float _force = 30f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //XMovement();
        //YMovement();
    }

    public void XMovement()
    {
        float dirX = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(dirX * _speed, _rb.velocity.y);
    }

    public void YMovement()
    {
        float dirY = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(_rb.velocity.x, dirY * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BottomPlatform"))
        {
            _rb.AddForce(Vector3.up * _force, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("TopPlatform"))
        {
            _rb.AddForce(Vector3.down * _force, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("LeftPlatform"))
        {
            _rb.AddForce(Vector3.right * _force, ForceMode2D.Impulse);
            print("111111");
        }
        else if (collision.gameObject.CompareTag("RightPlatform"))
        {
            _rb.AddForce(Vector3.left * _force, ForceMode2D.Impulse);
        }
    }
}
