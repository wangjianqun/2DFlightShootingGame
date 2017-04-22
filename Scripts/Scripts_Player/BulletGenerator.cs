using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{

    public GameObject bullet;
    public int bulletNum;
    private AudioSource audioSource;
    public GameResourcesManager resourcesManager;

	// Use this for initialization
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	    bulletNum = resourcesManager.player_HP;
	    

	}
	
	// Update is called once per frame
	void Update () {
        //每帧查询主角血量
        bulletNum = resourcesManager.player_HP-1;
        if (bulletNum>0)
	    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InsBullet();
                
            }
        }
	    
	}

    #region 射击按钮调用处
    public void InsBullet()
    {
        if (bulletNum > 0)
        {
            Instantiate(bullet, this.gameObject.transform.position, Quaternion.identity);
            bulletNum--;
            audioSource.Play();
            if (bulletNum <= 0)
            {
                bulletNum = 0;
            }
        }

        //更新玩家血量
        resourcesManager.player_HP = bulletNum + 1;
    }


    #endregion
    

}
