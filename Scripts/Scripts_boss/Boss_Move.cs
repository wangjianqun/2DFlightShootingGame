using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : MonoBehaviour
{

    public float speed=0.5f;
    public  Vector3 RandomVec;
    public float max_x=8;
    public float max_y=3.9f;
    public float min_x=0;
    public float min_y=-3.9f;
    public bool isRandom = false;
    private float moveTime;
    private float journeyLength;
    

    void Start()
    {
        RandomVec=new Vector3(Random.Range(min_x,max_x),Random.Range(min_y,max_y),0);

    }

    void Update()
    {
        //var velocity = Vector3.zero;
        journeyLength = Vector3.Distance(transform.position, RandomVec);
        Vector3 currentpos = transform.position;
        float fracJourney = speed/journeyLength;
        transform.Translate(RandomVec);
        //transform.position = Vector3.SmoothDamp(currentpos, RandomVec, ref velocity,speed);
        transform.position = Vector3.Lerp(currentpos, RandomVec, fracJourney);
        //transform.Translate(RandomVec.x*speed*Time.deltaTime,RandomVec.y*speed*Time.deltaTime,0);
        //print(transform.position);
        moveTime += Time.deltaTime;
        if (moveTime>=4)
        {
            isRandom = true;
            moveTime = 0;
        }
        if (isRandom)
        {
            RandomVec = new Vector3(Random.Range(min_x, max_x), Random.Range(min_y, max_y), 0);
            isRandom = false;
        }
    }


    //float stopTime;
    //float moveTime;
    //float vel_x, vel_y, vel_z;//速度
    //                          ///
    //                          /// 最大、最小飞行界限
    //                          ///
    //float maxPos_x = 7;
    //float maxPos_y = 3.94f;
    //float minPos_x = -7;
    //float minPos_y = -3.94f;
    //int curr_frame;
    //int total_frame;
    //float timeCounter1;
    //float timeCounter2;
    //// int max_Flys = 128;
    //// Use this for initialization
    //void Start()
    //{
    //    Change();
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    timeCounter1 += Time.deltaTime;
    //    if (timeCounter1 < moveTime)
    //    {
    //        transform.Translate(vel_x*Time.deltaTime, vel_y*Time.deltaTime, 0, Space.Self);
    //    }
    //    else
    //    {
    //        timeCounter2 += Time.deltaTime;
    //        if (timeCounter2 > stopTime)
    //        {
    //            Change();
    //            timeCounter1 = 0;
    //            timeCounter2 = 0;
    //        }
    //    }
    //    Check();
    //}
    //void Change()
    //{
    //    stopTime = Random.Range(0, 1);
    //    moveTime = Random.Range(1, 5);
    //    vel_x = Random.Range(1, 2);
    //    vel_y = Random.Range(1, 2);
    //}
    //void Check()
    //{
    //    //如果到达预设的界限位置值，调换速度方向并让它当前的坐标位置等于这个临界边的位置值
    //    if (transform.localPosition.x > maxPos_x)
    //    {
    //        vel_x = -vel_x;
    //        transform.localPosition = new Vector3(maxPos_x, transform.localPosition.y, 0);
    //    }
    //    if (transform.localPosition.x < minPos_x)
    //    {
    //        vel_x = -vel_x;
    //        transform.localPosition = new Vector3(minPos_x, transform.localPosition.y, 0);
    //    }
    //    if (transform.localPosition.y > maxPos_y)
    //    {
    //        vel_y = -vel_y;
    //        transform.localPosition = new Vector3(transform.localPosition.x, maxPos_y, 0);
    //    }
    //    if (transform.localPosition.y < minPos_y)
    //    {
    //        vel_y = -vel_y;
    //        transform.localPosition = new Vector3(transform.localPosition.x, minPos_y, 0);
    //    }
    //}
}
