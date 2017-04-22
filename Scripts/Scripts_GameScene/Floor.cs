using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    //本脚本用于创建销毁玩家和敌人的地面

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (collider2D.gameObject.layer==8||collider2D.gameObject.layer==9)
        {
            //print("碰到敌人");
            Destroy(collider2D.gameObject);
        }
        

        //Destroy(collider2D.gameObject);
    }

}
