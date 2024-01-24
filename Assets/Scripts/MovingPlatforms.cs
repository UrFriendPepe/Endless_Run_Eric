using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    private static MovingPlatforms instance = new MovingPlatforms();
    public static MovingPlatforms Instance
    {
        get { return instance; }
    }

    [SerializeField] GameObject _topSmallP, _bottomSmallP, _leftSmallP, _rightSmallP;
    public int _pattern,_randomX,_randomY;
    int _patternChangingTime,_platformGeneratingTime;
    Vector3 _loca1,_loca2,_loca3,_loca4;
    public float _timer,_numTimer,_speedUpTimer;
    public float _speed;
    GameManager _gameManager;
    // Start is called before the first frame update

    private MovingPlatforms()
    {
        instance = this;
    }
    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        _speed = 0.1f;
        _platformGeneratingTime = 5;//how long to generate platforms
        _patternChangingTime = 5;//how long to change patterns after generated platform
    }

    // Update is called once per frame
    void Update()
    {

        if (_gameManager.State == GameManager.GameState.GameStart)
        {
            MovingP();
            SpeedUp();
        }


    }
    void MovingP()
    {
        _numTimer += Time.deltaTime;
        if(_pattern == 0)
        {
            if (_numTimer >= _platformGeneratingTime)
            {
                _randomX = Random.Range(-53, 54);//for top and bottom platforms' x axis
                _randomY = Random.Range(-25, 25);//for left and right platforms' y axis
                _pattern = Random.Range(1, 5);//how many pattern do I want?
                _numTimer = 0;
            }
        }

        _loca1 = new Vector3(_randomX, 43, 0);//for the top platforms
        _loca2 = new Vector3(_randomX, -43, 0);//for the bottom platforms
        _loca3 = new Vector3(-74, _randomY, 0);//for the left platforms
        _loca4 = new Vector3(74, _randomY, 0);//for the right platforms
        switch (_pattern)
        {
            case 1:
                if (_timer <= 0)
                {
                    Instantiate(_topSmallP, _loca1, Quaternion.identity);
                }
                _timer += Time.deltaTime;
                if (_timer >= _patternChangingTime)//time for changing to different patterns
                {
                    _timer = 0;
                    _pattern = 0;
                }
                break;
            case 2:
                if (_timer <= 0)
                {
                    Instantiate(_bottomSmallP, _loca2, Quaternion.identity);
                }
                _timer += Time.deltaTime;
                if (_timer >= _patternChangingTime)
                {
                    _timer = 0;
                    _pattern = 0;
                }

                break;
            case 3:
                if (_timer <= 0)
                {
                    Instantiate(_leftSmallP, _loca3, Quaternion.identity);
                }
                _timer += Time.deltaTime;
                if (_timer >= _patternChangingTime)
                {
                    _timer = 0;
                    _pattern = 0;
                }

                break;
            case 4:
                if (_timer <= 0)
                {
                    Instantiate(_rightSmallP, _loca4, Quaternion.identity);
                }
                _timer += Time.deltaTime;
                if (_timer >= _patternChangingTime)
                {
                    _timer = 0;
                    _pattern = 0;
                }

                break;
        }
    }
    void SpeedUp()
    {
        _speedUpTimer += Time.deltaTime;
        if (_speedUpTimer >= 40)
        {
            _speed = 0.2f;
        }
        if (_speedUpTimer >= 80)
        {
            _speed = 0.4f;
        }
        if (_speedUpTimer >= 120)
        {
            _speed = 0.6f;
        }
        if( _speedUpTimer >= 140)
        {
            _speed = 0.8f;
        }
        if (_speedUpTimer >= 160)
        {
            _speed = 1.2f;
        }
    }

}
