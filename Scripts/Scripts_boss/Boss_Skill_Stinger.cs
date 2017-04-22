using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Skill_Stinger : MonoBehaviour
{
    public float speed = 1;
    private float overTime;
    private float nowTime;
    private Vector3 PlayerPos;
    private bool isChange;
    
    

	// Use this for initialization
	void Start ()
	{
        //追踪时间
	    overTime = Random.Range(0.5f,2f);
	}
	
	// Update is called once per frame
	void Update () {

        //TrackToPlayer();
        if (!isChange)
	    {
            TrackToPlayer();
	        nowTime += Time.deltaTime;
	        if (nowTime>=overTime)
	        {
	            isChange = true;
                
	        }

	    }
        transform.Translate(Vector3.left*Time.deltaTime*speed);

	}

    void TrackToPlayer()
    {
        //获取主角坐标
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //将主角坐标转换成屏幕坐标
        Vector3 player = Camera.main.WorldToScreenPoint(PlayerPos);
        //将自己的坐标转换成屏幕坐标
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //将双方的屏幕坐标向量相减，得到指向主角的目标向量
        Vector3 direction = player - obj;
        //将z轴坐标设置为0，保持在2D平面里
        direction.z = 0f;
        //将目标向量归一化，即将其向量长度变为1，这里的目的是只使用向量的方向，不需要长度，因此置为1
        direction = direction.normalized;
        //将物体自身的x轴和目标向量保持一致，这个过程xy轴都会变化数值
        transform.right = -direction;


    }

}
