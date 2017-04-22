using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour {

    //本脚本用于创建墙生成器

    public GameObject wall;

    // Use this for initialization
    void Start () {
        InvokeRepeating("InstantiateEnemy", 5, 6);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //生成敌人
    public void InstantiateEnemy()
    {
        print("执行");
        Instantiate(wall, new Vector3(9.5f, Random.Range(-7f, -2.6f), 0), Quaternion.identity);

    }

}
