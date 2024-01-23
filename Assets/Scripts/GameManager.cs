using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static UnityEditor.Progress;

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
    GameObject _temp;
    GameObject _refToGameStart,_refToWASD,_refToMouseUI;
    public int PlayerNum, MaxPlayer;
    float _scores;
    TextMeshPro _scoreText, _gameText;
    Vector3 _uiHidesPos, _uiShowsPos;


    public Transform CamPos;

    public Vector3 ChildSumPos = new Vector3();
    public Vector3 CamXY;

    public List<GameObject> ChildCount = new List<GameObject>();
    private void Awake()
    {
        instance = this;
        _refToGameStart = GameObject.Find("GameStartWhite");
        _refToWASD = GameObject.Find("WASD");
        _refToMouseUI = GameObject.Find("MouseUI");
        _scoreText = GameObject.Find("Scores").GetComponent<TextMeshPro>();
        _gameText = GameObject.Find("GameText").GetComponent<TextMeshPro>();
        CamPos = GameObject.Find("Main Camera").GetComponent<Transform>();
        _temp = Instantiate(_refToPlayer, this.transform.position, Quaternion.identity);
        ChildCount.Add(_temp);

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }
    void Start()
    {
        MaxPlayer = 16;
        _scores = 0;
        _uiHidesPos = new Vector3(0,150,1);
        _uiShowsPos = new Vector3(0, -3f, 1);
        State = GameState.Menu;
        //_playerGroup = GameObject.Find("PlayerGroup");
        //_refToGameStart = GameObject.Find("GameStartWhite");
        //_refToWASD = GameObject.Find("WASD");
        //_refToMouseUI = GameObject.Find("MouseUI");
        //CamPos = GameObject.Find("Main Camera").GetComponent<Transform>();
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
        //CamXY = new Vector3(CamPos.localPosition.x, CamPos.localPosition.y, -10);


        //PlayerNum = _playerGroup.transform.childCount;
        //for (int i = 0; i < PlayerNum; i++)
        //{
        //    if (i >= MaxPlayer)
        //    {
        //        Destroy(_playerGroup.transform.GetChild(i).gameObject);
        //    }
        //}
        PlayerNumAndCam();


        if (State == GameState.Menu)
        {

            _scoreText.transform.position = _uiHidesPos;
            _gameText.transform.position = _uiHidesPos;
            MaxPlayer = 16;
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
            _scoreText.transform.position = new Vector3(-4.3f + CamPos.position.x, 37.3f + CamPos.position.y, 1);
            _refToGameStart.SetActive(false);
            _refToWASD.SetActive(false);
            _refToMouseUI.SetActive(false);
            _gameText.transform.position = _uiHidesPos;
            //PlayerNumber();
            ScoreSystem();
            if(ChildCount.Count == 0)
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

    //void PlayerNumber()
    //{
    //    PlayerNum = _playerGroup.transform.childCount;
    //    for (int i = 0; i < PlayerNum; i++)
    //    {
    //        if (i >= MaxPlayer)
    //        {
    //            Destroy(_playerGroup.transform.GetChild(i).gameObject);
    //        }
    //    }
    //}

    void PlayerNumAndCam()
    {
        for (int i = 0; i < ChildCount.Count; i++)
        {
            if (ChildCount[i] == null)
            {
                //Destroy(ChildCount[i].gameObject);
                ChildCount.RemoveAt(i);
            }
        }

        if(ChildCount.Count == 0) return;

        ChildSumPos = Vector3.zero;

        foreach(GameObject pos in ChildCount)
        {
            if (pos == null) return;

            ChildSumPos += pos.transform.position;
        }

        ChildSumPos = ChildSumPos / ChildCount.Count;
        CamXY = new Vector3(CamPos.localPosition.x, CamPos.localPosition.y, -10);
        CamPos.position = Vector3.Lerp(CamXY, ChildSumPos, 3.5f * Time.deltaTime);

        if (ChildCount.Count > 6)
        {
            Camera.main.orthographicSize = 40 + ChildCount.Count * 2;
        }
        else
        {
            Camera.main.orthographicSize = 40;
        }
        //use current cam size
    }

    void ScoreSystem()
    {
        // _scoreTimer += Time.deltaTime;

        if(ChildCount.Count != 0)
        {
            float scoremultiplier = (1 + 0.1354f * Mathf.Pow((ChildCount.Count - 1), 1.55f));
            _scores += scoremultiplier * 10f * Time.deltaTime;
            _scoreText.text = "Score : " + _scores.ToString("F0") + " (X" + scoremultiplier.ToString("F1") + ")";
        }
        else
        {
            _scoreText.text = "Score : " + _scores.ToString("F0");
        }
        
    }
}
