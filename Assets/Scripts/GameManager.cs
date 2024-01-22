using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    
    GameObject _playerGroup;
    public int PlayerNum, MaxPlayer;


    private GameManager()
    {
        instance = this;
    }
    //public List<GameObject> ChildCount = new List<GameObject>();
    private void Awake()
    {
        _playerGroup = GameObject.Find("PlayerGroup");
        
    }
    void Start()
    {
        MaxPlayer = 15;
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
        PlayerNum = _playerGroup.transform.childCount;
        for(int i = 0; i < PlayerNum; i++)
        {
            if(i >= MaxPlayer)
            {
                Destroy(_playerGroup.transform.GetChild(i).gameObject);
            }
        }
    }
}
