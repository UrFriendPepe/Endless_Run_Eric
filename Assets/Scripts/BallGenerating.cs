using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerating : MonoBehaviour
{
    [SerializeField] GameObject _refToRandomBall;
    PlayerMove _refToPlayerMove;
    float _playerSize;
    int _spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        _refToPlayerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        _playerSize = _refToPlayerMove.PlayerSize;
        _spawnCount = 9;
        GetRandomBalls();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetRandomBalls()
    {
        for(int i = 0; i < _spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(i * 2.0f, i * 1.0f, 0.0f);
            Instantiate(_refToRandomBall, spawnPosition, Quaternion.identity);
        }
    }
}
