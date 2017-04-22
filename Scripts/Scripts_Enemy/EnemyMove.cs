using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //本脚本用于使敌人移动

    private Vector3 vec;
    public float speed=1;
    //public bool IsRandom = false;
    //private float countDown = 3.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //敌人移动
        vec = Vector3.left;
        transform.Translate(vec * Time.deltaTime*speed);
     //   if (!IsRandom)
	    //{
     //       vec = Vector3.left;
     //       transform.Translate(vec * Time.deltaTime);
     //   }
        
     //   if (IsRandom)
	    //{
     //       CountDown();

     //   }
	    
		
	}

    //void CountDown()
    //{
    //    float timePoint;
    //    timePoint = Time.time;
    //    if (timePoint==3.0f)
    //    {
    //        RandomMove();

    //    }
    //}

    //public void RandomMove()
    //{
    //    float Result;
    //    Vector3 vecRan;
    //    Result = Random.Range(0, 1);
    //    if (Result>=0.5)
    //    {
    //        vecRan=Vector3.up;
    //        transform.Translate(Time.deltaTime,Time.deltaTime,0);
    //    }
    //    else
    //    {
    //        vecRan=Vector3.down;
    //        transform.Translate(Time.deltaTime,-Time.deltaTime,0);
    //    }
    //}

    
}
