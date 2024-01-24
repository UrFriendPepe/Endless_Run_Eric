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
    GameObject _refToGameStart,_refToWASD,_refToMouseUI;
    public int PlayerNum, MaxPlayer;
    float _scoreTimer, _scores;
    TextMeshPro _scoreText, _gameText;
    Vector3 _uiHidesPos, _uiShowsPos;
    public int myFrameRate = 60;




    //public List<GameObject> ChildCount = new List<GameObject>();
    private void Awake()
    {
        _playerGroup = GameObject.Find("PlayerGroup");
        _refToGameStart = GameObject.Find("GameStartWhite");
        _refToWASD = GameObject.Find("WASD");
        _refToMouseUI = GameObject.Find("MouseUI");
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
        Application.targetFrameRate = myFrameRate;
        QualitySettings.vSyncCount = 0;
        MaxPlayer = 15;
        _scoreTimer = 0;
        _scores = 0;
        _uiHidesPos = new Vector3(0,65,1);
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
            _refToGameStart = GameObject.Find("GameStartWhite");
            _refToWASD = GameObject.Find("WASD");
            _refToMouseUI = GameObject.Find("MouseUI");
            _scoreText.transform.position = _uiHidesPos;
            _gameText.transform.position = _uiHidesPos;
            MaxPlayer = 16;
            _scoreTimer = 0;
            _scores = 0;
            //_gameText.text = "Press Space To Start";
            //_gameText.transform.position = _uiShowsPos;
            _refToGameStart.SetActive(true);
            _refToWASD.SetActive(true);
            _refToMouseUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                State = GameState.GameStart;
            }
        }

        else if(State == GameState.GameStart)
        {
            _scoreText.transform.position = new Vector3(-4.3f, 37.3f, 1);
            _refToGameStart.SetActive(false);
            _refToWASD.SetActive(false);
            _refToMouseUI.SetActive(false);
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
            _scoreText.transform.position = _uiHidesPos;
            _refToGameStart.SetActive(false);
            _refToWASD.SetActive(false);
            _refToMouseUI.SetActive(false);
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

        if(PlayerNum != 0)
        {
            float scoremultiplier = (1 + 0.1354f * Mathf.Pow((PlayerNum - 1), 1.55f));
            _scores += scoremultiplier * 10f * Time.deltaTime;
            _scoreText.text = "Score : " + _scores.ToString("F0") + " (X" + scoremultiplier.ToString("F1") + ")";
        }
        else
        {
            _scoreText.text = "Score : " + _scores.ToString("F0");
        }
        
    }
}
