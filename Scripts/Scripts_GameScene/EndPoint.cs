using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour {
    //本脚本用于管理物体的终点控制器


    private Vector3 vec;
    public GameObject player;
    //public Vector3 endVec;
    public Text text;
    public GameResourcesManager GameManager;
    //private float nowTime;
    
    private bool isToMove = false;
    private int m = 30;
    public int length = 60;


    // Use this for initialization
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("resourcesManager").GetComponent<GameResourcesManager>();
        length = GameManager.journeyLength;

    }

    // Update is called once per frame
    void Update()
    {


        
        
        //if (m>=14)
        //{
        //    m = (int)(length - Time.time);
        //    //print("zhixing1l1");
        //    text.text = "距离终点：" + m;
        //    text.text += "M";
        //}
        //else if (m<14)
        //{
        //    //SendMessage("isEndPointToMove");  //调用isEndPointToMove函数来使终点线移动
        //    isEndPointToMove();
        //    //print("传递消息");
        //}
        
        
        
    }

    

    //终点线开始移动
    void isEndPointToMove()
    {
        isToMove = true;
        //print("收到消息");
        Move();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag=="Player")
        {
            print("你赢了");
            SceneManager.LoadScene("WinScene");

        }
    }

    //使终点向左移动
    void Move()
    {
        vec = Vector3.left;
        transform.Translate(vec * Time.deltaTime);
        //endVec = transform.position;
        m = (int)(transform.position.x - player.transform.position.x);
        text.text = "距离终点：" + m + "M";
        
    }

}
