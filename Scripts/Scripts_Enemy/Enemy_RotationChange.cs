using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RotationChange : MonoBehaviour {

    //此脚本用于创建会在移动一段时间后突然加速，跟踪玩家的敌人

    private bool isChange = false;
    public float speed = 1.5f;
    private float OverTime = 0;
    private Vector3 PlayerVec;

    // Use this for initialization
    void Start()
    {
        //PlayerVec = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update()
    {
        if (!isChange)
        {
            OverTime += Time.deltaTime;
            if (OverTime >= 5.0f)
            {
                isChange = true;
                speed = 4;
                ChangeToDirection();
            }


        }


        transform.Translate(Vector3.left * Time.deltaTime * speed);

        /*if (Input.GetMouseButton(0))  //此代码参考https://my.oschina.net/acitiviti/blog/603318里的效果
                {
                    //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换
                    Vector3 mouse = Input.mousePosition;
                    //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直
                    Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
                    //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段
                    Vector3 direction = mouse - obj;
                    //将Z轴置0,保持在2D平面内
                    direction.z = 0f;
                    //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1
                    direction = direction.normalized;
                    //当目标向量的Y轴大于等于0.4F时候，这里是用于限制角度，可以自己条件
                    //if (direction.y >= -0.4f&&direction.y<=0.4f)
                    //{
                        //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值
                        transform.up = -direction;
                    //}
                }*/
    }

    void ChangeToDirection()
    {
        //获取主角坐标
        PlayerVec = GameObject.FindGameObjectWithTag("Player").transform.position;
        //将主角坐标转换成屏幕坐标
        Vector3 player = Camera.main.WorldToScreenPoint(PlayerVec);
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
