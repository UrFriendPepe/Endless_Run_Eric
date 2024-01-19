using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] GameObject _refToTopP;
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
            if (_numTimer >= 5)
            {
                _randomX = Random.Range(-53, 54);
                _pattern = Random.Range(1, 2);
                _numTimer = 0;
            }
        }

        _loca1 = new Vector3(_randomX, 43, 0);
        switch (_pattern)
        {
            case 1:
                if (_timer <= 0)
                {
                    Instantiate(_refToTopP, _loca1, Quaternion.identity);
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
                    Instantiate(_refToTopP, _loca1, Quaternion.identity);
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
