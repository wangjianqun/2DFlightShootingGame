using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    public GameObject enemySpawn;// 存放敌人的prefab  
    public int enemyCount;// 每一波敌人的个数  
    public float startWait;// 开始游戏后玩家的准备时间  
    public float spawnTime;// 生成下一波敌人的时间间隔  

    public float waveWait;// 生成下一波敌人的等待时间  

    void Start()
    {
        StartCoroutine(spawnWaves());
    }

    // 协同函数  
    IEnumerator spawnWaves()
    {
        // 开始游戏后，不会立即有敌人，需要给玩家一些准备时间waitTime  
        yield return new WaitForSeconds(startWait);
        // 循环生成一波一波的敌人  
        while (true)
        {
            for (int i = 0; i < enemyCount; ++i)
            {
                //Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 0, 12);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemySpawn,new Vector3(9.5f,Random.Range(-5f,5f),0) , spawnRotation);
                // 加入生成一波子弹的时间间隔  
                yield return new WaitForSeconds(spawnTime);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
