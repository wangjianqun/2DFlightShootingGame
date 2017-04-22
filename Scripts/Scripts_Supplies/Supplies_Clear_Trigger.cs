using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies_Clear_Trigger : MonoBehaviour
{

    //此处要挂载Supplies_Clear脚本，耦合非常大，在后期需要优化此处的脚本
    //public Supplies_Clear suppliesClear;
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        //if (collider2D.tag=="Player")
        //{
        //    //调用Supplies_Clear脚本里的ClearEnemy函数
        //    suppliesClear.SendMessage("ClearEnemys");
            
        //}
    }
}
