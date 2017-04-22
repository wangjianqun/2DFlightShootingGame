using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class InstantiateEnemyDebris : MonoBehaviour
{
    //本脚本用于生成爆炸敌人自爆后的碎片

    public GameObject enemyDebris;
    private Vector3 vec;
    private float overTime;
    private float randomTime;
    int[] Nums=new int[] {2,3,4,5};

	// Use this for initialization
	void Start ()
	{
	    //vec = this.transform.position;
	    randomTime = Random.Range(2, 7);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //mun = Random.Range(-90, 90);
	    //Instantiate(enemyDebris, transform,
	     //   Quaternion.Euler(this.gameObject.transform.rotation.eulerAngles.x, this.gameObject.transform.rotation.eulerAngles.y,
	       //     this.gameObject.transform.rotation.eulerAngles.z + 45));
        
	    //Instantiate(enemyDebris, vec, Quaternion.Euler(0, 0, mun));
	    overTime += Time.deltaTime;
	    if (overTime>=randomTime)
	    {
            //CreateDebris(Nums[Random.Range(0, Nums.Length)]);
            //overTime = 0;
            vec.x = transform.position.x;
            vec.y = transform.position.y;
            vec.z = transform.position.z;
            EnemyDestroy();
	    }
    }


    void EnemyDestroy()
    {
        //生成碎片
        CreateDebris(Nums[Random.Range(0, Nums.Length)]);
        //播放音乐。。。
        //播放动画


        Destroy(this.gameObject);

    }

    void CreateDebris(int num)
    {
        int angle;
        for (int i = 0; i < num; i++)
        {
            angle = Random.Range(-90, 90);
            Instantiate(enemyDebris, vec, Quaternion.Euler(0, 0, angle));
        }   
    }

}
