using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敌人生成器

    public GameObject enemy;
    public List<GameObject> enemys=new List<GameObject>();
    public List<float> EGTime = new List<float>();
    public List<GameObject> SuppliesList=new List<GameObject>();
    private float timeFlag;


	// Use this for initialization
	void Start () {
        
        //每隔2秒钟调用一次InstantiateEnemy函数，生成敌人
		InvokeRepeating("Instantiate_Enemy",2,Random.Range(2,5));
        InvokeRepeating("Instantiate_Supplies",9,Random.Range(5,10));
        InvokeRepeating("Instantiate_SpecialEnemy",8,Random.Range(5,10));


	}
	
	// Update is called once per frame
	void Update ()
	{
	    //timeFlag += Time.deltaTime;
	    


	}

    //生成敌人
    public void Instantiate_Enemy()
    {
        //print("执行");
        Instantiate(enemy, new Vector3(9.5f, Random.Range(-5f, 5f), 0), Quaternion.identity);


        
    }

    //生成辅助品
    public void Instantiate_Supplies()
    {
        print("生成辅助品");
        Instantiate(SuppliesList[Random.Range(0,SuppliesList.Count)], new Vector3(9.5f, Random.Range(-5f, 5f), 0), Quaternion.identity);


    }

    //生成高级敌人
    public void Instantiate_SpecialEnemy()
    {
        print("生成特殊敌人");
        Instantiate(enemys[Random.Range(0, enemys.Count)], new Vector3(9.5f, Random.Range(-5f, 5f), 0),
            Quaternion.identity);


    }


}
