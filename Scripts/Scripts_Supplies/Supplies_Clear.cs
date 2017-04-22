using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Supplies_Clear : MonoBehaviour
{
    private float TimeOver;  //清场倒计时
    private bool isClear = false;  //是否开启清场功能
    //public PlayerControl playerControl;
   



    
	// Use this for initialization
	void Start ()
	{
	   
	}
	
	// Update is called once per frame
	void Update ()
	{
        //每次清场持续2秒钟
	    TimeOver += Time.deltaTime;
	    if (TimeOver>=2)
	    {
	        TimeOver = 0;
	        //this.gameObject.SetActive(false);
	        isClear = false;
	    }
	}

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (isClear)
        {
            //print("识别到了");
            //print(collider2D.gameObject.name);
            if (collider2D.gameObject.layer.ToString()=="8")
            {
                Destroy(collider2D.gameObject);
            }
        }

        
    }

     void ClearEnemys()
    {
        //print("清除全场");
         isClear = true;
    }


}
