using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject _refToRandomBall;
    GravitySC _refToGravitySC;
    GameManager _refToGameManager;
    Rigidbody2D _rb;
    float _speed = 0.01f;
    float _force = 40f;
    GameObject _mouse;
    GameObject _playerGroup;
    public float PlayerSize;
    public float _timer;
    float _dist;
    float _offset = 0.05f;
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mouse = GameObject.Find("Mouse");
        _refToGravitySC = GameObject.Find("GameManager").GetComponent<GravitySC>();
        _playerGroup = GameObject.Find("PlayerGroup");
        _refToGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.gameObject.transform.SetParent(_playerGroup.transform);
    }
    void Start()
    {
        _refToGameManager.ChildCount.Insert(0, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //XMovement();
        //YMovement();
        //PlayerSize = this.transform.localScale.x;
        if (_refToGravitySC.GS == GravitySC.GravityState.Down)
        {
            XMovement();
        }
        if (_refToGravitySC.GS == GravitySC.GravityState.Up)
        {
            XMovement();
        }
        if (_refToGravitySC.GS == GravitySC.GravityState.Left)
        {
            YMovement();
        }
        if (_refToGravitySC.GS == GravitySC.GravityState.Right)
        {
            YMovement();
        }
        MoreBalls();
    }

    public void XMovement()//using in GravitySC
    {
        //float dirX = Input.GetAxis("Horizontal");
        //_rb.velocity = new Vector2(dirX * _speed, _rb.velocity.y);
        _dist = Vector2.Distance(_mouse.transform.position, transform.position);
        if (_mouse.transform.position.x > this.transform.position.x)
        {
            //transform.position += new Vector3(_speed, 0, 0);
            _rb.AddForce(Vector2.right * _offset * _dist);
        }
        else if (_mouse.transform.position.x < this.transform.position.x)
        {
            //transform.position -= new Vector3(_speed, 0, 0);
            _rb.AddForce(Vector2.right * -_offset * _dist);
        }
    }

    public void YMovement()//Using in GravitySC
    {
        //float dirY = Input.GetAxis("Vertical");
        //_rb.velocity = new Vector2(_rb.velocity.x, dirY * _speed);
        _dist = Vector2.Distance(_mouse.transform.position, transform.position);
        if (_mouse.transform.position.y > this.transform.position.y)
        {
            //transform.position += new Vector3(0, _speed, 0);
            _rb.AddForce(Vector2.up * _offset * _dist);
        }
        else if (_mouse.transform.position.y < this.transform.position.y)
        {
            //transform.position -= new Vector3(0, _speed, 0);
            _rb.AddForce(Vector2.up * -_offset * _dist);
        }
    }

    public void MoreBalls()
    {
        _timer += Time.deltaTime;
        if (_timer >= 1)//how long to generate balls
        {
            _timer = 0;
            int spermLimit = 10;
            if(_refToGameManager.SpermCount <= spermLimit)
            {
                Instantiate(_refToRandomBall, this.transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_refToGravitySC.GS == GravitySC.GravityState.Down)
        {
            if (collision.gameObject.CompareTag("BottomPlatform"))
            {
                _rb.AddForce(Vector3.up * _force, ForceMode2D.Impulse);
                //if(this.gameObject.name == "Player")
                //{
                //    Instantiate(_refToRandomBall, new Vector3(0, 0, 0), Quaternion.identity);
                //}
            }
        }

        if (_refToGravitySC.GS == GravitySC.GravityState.Up)
        {
            if (collision.gameObject.CompareTag("TopPlatform"))
            {
                _rb.AddForce(Vector3.down * _force, ForceMode2D.Impulse);
                //if (this.gameObject.name == "Player")
                //{
                //    Instantiate(_refToRandomBall, new Vector3(0, 0, 0), Quaternion.identity);
                //}
            }
        }

        if (_refToGravitySC.GS == GravitySC.GravityState.Left)
        {
            if (collision.gameObject.CompareTag("LeftPlatform"))
            {
                _rb.AddForce(Vector3.right * _force, ForceMode2D.Impulse);
                //if (this.gameObject.name == "Player")
                //{
                //    Instantiate(_refToRandomBall, new Vector3(0, 0, 0), Quaternion.identity);
                //}
            }
        }

        if (_refToGravitySC.GS == GravitySC.GravityState.Right)
        {
            if (collision.gameObject.CompareTag("RightPlatform"))
            {
                _rb.AddForce(Vector3.left * _force, ForceMode2D.Impulse);
                //if (this.gameObject.name == "Player")
                //{
                //    Instantiate(_refToRandomBall, new Vector3(0, 0, 0), Quaternion.identity);
                //}
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 jumpVec = transform.position - collision.transform.position;
            float jumpForce = 250;
            _rb.AddForce(jumpVec * jumpForce);
            collision.transform.GetComponent<Rigidbody2D>().AddForce(-jumpVec * jumpForce);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingP"))
        {
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        _refToGameManager.ChildCount.Remove(gameObject);
    }
}
