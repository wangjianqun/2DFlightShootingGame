using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockerGameManager : MonoBehaviour
{
    //本脚本由于通过虚拟摇杆控制主角的移动
    public GameObject player;
    public Vector3 player_Pos;
    public Vector3 dir;  //接收摇杆的方向向量
    public float distance; //接收摇杆偏移量

    public float player_Speed=1;
    //规定玩家能移动的范围
    public float XMax;
    public float YMax;
    public float xMin;
    public float yMin;

    //private Vector3 limitPos;

    // Use this for initialization
    void Start ()
	{

	    player = GameObject.FindGameObjectWithTag("Player");
	    GetPlayer_Pos();

	}
	
	// Update is called once per frame
	void Update ()
	{

        //设置移动范围
	    if (player.transform.position.x > XMax)
	    {
            GetPlayer_Pos();
            //limitPos=new Vector3(XMax,player_Pos.y,0);
	        //Transform player_tra = player.GetComponent<Transform>();
            
	        //player.transform.position.x = XMax;
	        player.transform.position=new Vector3(XMax, player_Pos.y, 0);
	    }
	    else if (player.transform.position.x < xMin)
	    {
	        GetPlayer_Pos();
            player.transform.position=new Vector3(xMin,player_Pos.y,0);
	    }
	     if (player.transform.position.y>YMax)
        {
	        GetPlayer_Pos();
            player.transform.position=new Vector3(player_Pos.x,YMax,0);
	    }else if (player.transform.position.y<yMin)
        {
	        GetPlayer_Pos();
            player.transform.position=new Vector3(player_Pos.x,yMin,0);
	    }
	    int touchCount = 0;
	    foreach (Touch touch in Input.touches)
	    {
	        if (touch.phase!=TouchPhase.Ended&&touch.phase!=TouchPhase.Canceled)
	        {
	            touchCount++;
	            
            }
	        
	    }
	    //player_Speed = player_Speed * distance;
	    //print(distance);

	    //print("你现在按的手指数为：" + touchCount);


	    //print(dir);
	    //player_Pos = player_Pos + dir * player_Speed*Time.deltaTime;
	    //Vector3 vec=new Vector3(player.transform.position.x + dir.x * player_Speed, player.transform.position.y + dir.y * player_Speed,0);
	    //player.transform.Translate(vec);
	    //player.transform.Translate(player.transform.position+dir);

	}

    void GetPlayer_Pos()
    {
        player_Pos = player.transform.position;
    }
}
