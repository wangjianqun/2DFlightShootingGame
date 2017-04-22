using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class EnemyRandomMove : MonoBehaviour {
    //负责随机上下移动的敌人的控制

    //float stopTime;
    public float speed = 1;
    float moveTime;
    float  vel_y=1, vel_z;//速度
                              ///
                              /// 最大、最小飞行界限
                              ///
    //float maxPos_x = 500;
    //float maxPos_y = 300;
    //float minPos_x = -500;
    //float minPos_y = -300;
    //int curr_frame;
    //int total_frame;
    float timeCounter1;

    private bool isUp;
    //float timeCounter2;
    // int max_Flys = 128;
    // Use this for initialization
    void Start()
    {
        isUp=Change();
    }
    // Update is called once per frame
    void Update()
    {
        timeCounter1 += Time.deltaTime;
        if (timeCounter1 < moveTime)
        {
            if (isUp)
            {
                //开始向上移动
                transform.Translate(-Time.deltaTime*speed, Time.deltaTime*speed, 0);
            }
            else
            {
                transform.Translate(-Time.deltaTime*speed, -Time.deltaTime*speed, 0);
            }
            
            
        }
        else
        {
            timeCounter1 = 0;
            isUp=Change();
            
            //timeCounter2 += Time.deltaTime;
            //if (timeCounter2 > stopTime)
            //{

            //    
            //    timeCounter2 = 0;
            //}
        }
        
    }
    bool Change()
    {
        bool isMoveUp;
        float mun;
        mun= Random.Range(-1, 1);
        moveTime = Random.Range(1, 5);
        if (mun>=0)
        {
            return true;
        }
        return false;

        //stopTime = Random.Range(1, 5);
        
        //vel_x = Random.Range(1, 10);
       //vel_y = Random.Range(-0.1f, 0.1f);
    }
}
