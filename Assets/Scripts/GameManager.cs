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

    [SerializeField] int _playerNum;
    GameObject _playerGroup;
    // Start is called before the first frame update



    public List<GameObject> ChildCount = new List<GameObject>();
    private void Awake()
    {
        _playerGroup = GameObject.Find("PlayerGroup");
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public int SpermCount = 6;
    void Update()
    {
        //for (int i = 0; i < ChildCount.Count; i++)
        //{
        //    if(ChildCount[i] == null)
        //    {
        //        ChildCount.RemoveAt(i);
                
        //    }
        //}
       SpermCount =  ChildCount.Count;
    }
}
