using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject _refToPlayer;
    GravitySC _refToGravitySC;
    GameManager _gameManager;
    GameObject _temp;
    Rigidbody2D _rb;
    float _force = 40f;
    GameObject _mouse;
    GameObject _playerGroup;
    public float PlayerSize;
    public float _timer,_generatingTime;
    float _dist;
    float _offset = 0.1f;//player speed
    bool _decreasingNum;
    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mouse = GameObject.Find("Mouse");
        _refToGravitySC = GameObject.Find("PlatformGroup").GetComponent<GravitySC>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //_playerGroup = GameObject.Find("PlayerGroup");
        //this.gameObject.transform.SetParent(_playerGroup.transform);
    }
    void Start()
    {

        //_decreasingNum = true;
        //_gameManager.PlayerNum++;
        //_refToGameManager.ChildCount.Insert(0, this.gameObject);
        _generatingTime = 5;
        //_gameManager.PlayerNum



    }

    // Update is called once per frame
    void Update()
    {
        //XMovement();
        //YMovement();
        //PlayerSize = this.transform.localScale.x;
        if (_gameManager.State == GameManager.GameState.GameStart)
        {
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
        int playerNum = GameManager.Instance.PlayerNum;
        int maxPlayer = GameManager.Instance.MaxPlayer;

        _spriteRenderer.GetComponent<TrailRenderer>().enabled = true;
        float growthfunction = (0.75f + 0.05f * Mathf.Pow((playerNum - 1), 1.35f));
        _generatingTime = growthfunction * Random.Range(6f, 10f);
        //if (playerNum<=3 && _generatingTime > 12)
        //{
        //    _generatingTime = 8;
        //}

        _timer += Time.deltaTime;
        if (_timer >= _generatingTime)//how long to generate balls
        {
            _timer = 0;
            //int spermLimit = 10;
            //if(_refToGameManager.SpermCount <= spermLimit)
            //{
            //    Instantiate(_refToRandomBall, this.transform.position, Quaternion.identity);
            //}

            //if (playerNum < maxPlayer)
            //{
            //    _temp = Instantiate(_refToPlayer, this.transform.position, Quaternion.identity);
            //    _gameManager.ChildCount.Add(_temp);//add players to the list

            //    //add to list
            //}
            if (playerNum < maxPlayer)
            {
                for (int i = 0; i < _gameManager.PlayerNum; i++)
                {
                    if (_gameManager.ChildCount[i].activeInHierarchy == false)
                    {
                        _gameManager.ChildCount[i].transform.position = this.transform.position;
                        _gameManager.ChildCount[i].SetActive(true);
                        _gameManager.Reused = true;
                        break;
                    }
                }

                if (_gameManager.Reused == false)
                {
                    _temp = Instantiate(_refToPlayer, this.transform.position, Quaternion.identity);
                    _gameManager.ChildCount.Add(_temp);
                }
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
            //remove 1 from list
            //_gameManager.ChildCount.Remove(gameObject);
            gameObject.SetActive(false);
            _spriteRenderer.GetComponent<TrailRenderer>().enabled = false;
            //if(_decreasingNum == true)
            //{
            //    _gameManager.PlayerNum--;
            //    _decreasingNum = false;
            //}
        }
    }
    private void OnDestroy()
    {
        //_refToGameManager.ChildCount.Remove(gameObject);
    }
}
