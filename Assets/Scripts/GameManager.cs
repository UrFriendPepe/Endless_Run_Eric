using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }


    public enum GameState { Menu, GameStart, GameEnd};
    public GameState State;

    [SerializeField] GameObject _refToPlayer;
    GameObject _playerGroup;
    public int PlayerNum, MaxPlayer;
    float _scoreTimer, _scores;
    TextMeshPro _scoreText, _gameText;
    Vector3 _uiHidesPos, _uiShowsPos;



    //public List<GameObject> ChildCount = new List<GameObject>();
    private void Awake()
    {
        _playerGroup = GameObject.Find("PlayerGroup");
        _scoreText = GameObject.Find("Scores").GetComponent<TextMeshPro>();
        _gameText = GameObject.Find("GameText").GetComponent<TextMeshPro>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        MaxPlayer = 15;
        _scoreTimer = 0;
        _scores = 0;
        _uiHidesPos = new Vector3(0,50,1);
        _uiShowsPos = new Vector3(0, -3f, 1);
        State = GameState.Menu;
    }

    // Update is called once per frame

    //public int PlayerCount = 6;
    void Update()
    {
        //for (int i = 0; i < ChildCount.Count; i++)
        //{
        //    if(ChildCount[i] == null)
        //    {
        //        ChildCount.RemoveAt(i);

        //    }
        //}
        //SpermCount =  ChildCount.Count;

        if(State == GameState.Menu)
        {
            _playerGroup = GameObject.Find("PlayerGroup");
            MaxPlayer = 16;
            _scoreTimer = 0;
            _scores = 0;
            _gameText.text = "Press Space To Start";
            _gameText.transform.position = _uiShowsPos;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                State = GameState.GameStart;
            }
        }

        else if(State == GameState.GameStart)
        {
            _gameText.transform.position = _uiHidesPos;
            PlayerNumber();
            ScoreSystem();
            if(PlayerNum == 0)
            {
                State = GameState.GameEnd;
            }
        }

        else if(State == GameState.GameEnd)
        {
            _gameText.text = "Final Score : "+ _scores.ToString("F0") + "\n"+ "Press Space To Restart";
            _gameText.transform.position = _uiShowsPos;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                State = GameState.Menu;
                SceneManager.LoadScene(0);
            }
        }

    }

    void PlayerNumber()
    {
        PlayerNum = _playerGroup.transform.childCount;
        for (int i = 0; i < PlayerNum; i++)
        {
            if (i >= MaxPlayer)
            {
                Destroy(_playerGroup.transform.GetChild(i).gameObject);
            }
        }
    }

    void ScoreSystem()
    {
        // _scoreTimer += Time.deltaTime;
        float scoremultiplier = (1 + 0.1354f * Mathf.Pow((PlayerNum - 1), 1.55f));
        _scores += scoremultiplier * 10f * Time.deltaTime;
        if(PlayerNum != 0)
        {
            _scoreText.text = "Score : " + _scores.ToString("F0") + " (X" + scoremultiplier.ToString("F1") + ")";
        }
        else
        {
            _scoreText.text = "Score : " + _scores.ToString("F0");
        }
        
    }
}
