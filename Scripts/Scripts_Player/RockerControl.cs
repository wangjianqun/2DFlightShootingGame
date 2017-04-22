using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockerControl : MonoBehaviour {


    //本脚本用于通过摇杆操控玩家
    public RockerGameManager manager;

    public float speed;
    public Vector3 dir;
    public float dis;  //摇杆偏移量


	// Use this for initialization
	void Start ()
	{

	    speed = manager.player_Speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //speed = manager.player_Speed;
        Speed_Classification();
        //transform.Translate(0,0, 0);
        //print(speed);

        //获取方向向量
        dir = manager.dir;

            //移动
            transform.Translate(dir.x * Time.deltaTime * speed*dis, dir.y * Time.deltaTime * speed*dis, 0);
        print(dis);
    }

    #region 对主角速度分级

    void Speed_Classification()
    {
        dis = manager.distance;
        if (dis<0.5)
        {
            dis = 1;

        }
        else if (dis>0.5||dis<=1)
        {
            dis = 2;
        }
        else if (dis>=1)
        {
            dis = 3;
        }
        
    }


    #endregion
}
