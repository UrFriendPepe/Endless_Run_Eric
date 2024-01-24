using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    GameObject _player;
    float _pSpeed = 0.002f;//platform speed
    float _dir;
    float _timer;
    bool _moving;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MovedByPlayer();
    }

    void MovedByPlayer()
    {
        Vector3 distPlatform = transform.position;
        Vector3 distPlayer = _player.transform.position;
        float xDist = distPlatform.x - distPlayer.x;
        float dir = Vector2.Distance(distPlatform, distPlayer);

        if (_timer <= 0)
        {
            _dir = Mathf.Abs(xDist) / (xDist * dir ) ;// does platform go left or right
        }

        if(_moving)
        {
            if(Mathf.Abs(xDist) >= 1)
            {
                _timer += Time.deltaTime;
                this.transform.position += new Vector3(_pSpeed / (_dir / 20), 0, 0);
            }
            else if(Mathf.Abs(xDist) <= 1)
            {
                _timer = 0;
                _moving = false;
            }

            if(_timer >= 0.1f)
            {
                _timer = 0;
                _moving = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _moving = true;
        }
    }
}
