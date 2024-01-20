using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] GameObject _topSmallP, _bottomSmallP;
    public int _pattern,_randomX;
    Vector3 _loca1,_loca2,_loca3,_loca4;
    public float _timer,_numTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingP();
    }
    void MovingP()
    {
        _numTimer += Time.deltaTime;
        if(_pattern == 0)
        {
            if (_numTimer >= 8)//time for changing to different patterns
            {
                _randomX = Random.Range(-53, 54);//for top and bottom platforms' x axis
                _pattern = Random.Range(1, 3);//how many pattern do I want?
                _numTimer = 0;
            }
        }

        _loca1 = new Vector3(_randomX, 43, 0);//for the top platforms
        _loca2 = new Vector3(_randomX, -43, 0);//for the bottom platforms
        switch (_pattern)
        {
            case 1:
                if (_timer <= 0)
                {
                    Instantiate(_topSmallP, _loca1, Quaternion.identity);
                }
                _timer += Time.deltaTime;
                if (_timer >= 4)
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
                if (_timer >= 4)
                {
                    _timer = 0;
                    _pattern = 0;
                }

                break;
        }
    }

}
