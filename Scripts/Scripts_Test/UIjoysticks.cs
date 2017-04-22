using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIjoysticks : MonoBehaviour
{
    //虚拟按钮的初始位置
    public Vector3 initPos;
    //虚拟方向按钮能移动的半径
    public float r;

    private float distance;
    public RockerGameManager rockerGameManager;
    public Transform border;
    private bool isMove;  //判断是否触发了摇杆
    private Vector3 dir;

    void Awake()
    {
        Input.multiTouchEnabled = true;
    }

    // Use this for initialization
    void Start ()
	{
        //获取管理脚本
	    rockerGameManager = GameObject.Find("GameResourcesManager").GetComponent<RockerGameManager>();

        //获取边界对象（border）的位置
	    border = GameObject.Find("border").transform;
	    initPos = GetComponent<RectTransform>().position;
	    r = Vector3.Distance(transform.position, border.position);

	}
	
	// Update is called once per frame
	void Update () {
	    if (!isMove)
	    {
	        dir=Vector3.zero;
	        rockerGameManager.distance = 1;
	        rockerGameManager.dir = dir;
	    }

	}

    //鼠标拖拽
    public void OnDraglng()
    {
        
        //print("拖拽");
        //判断手指触摸有没有在边界内
        if (Vector3.Distance(Input.GetTouch(0).position,initPos)<=r)
        {
            transform.position = Input.GetTouch(0).position;
        }
        else
        {
            //计算出鼠标位置与摇杆之间的方向向量
            dir = (Vector3)Input.GetTouch(0).position - initPos;

            transform.position = initPos + dir.normalized * r;
        }
        //判断鼠标有没有在边界内
        //if (Vector3.Distance(Input.mousePosition,initPos)<=r)
        //{
        //    transform.position = Input.mousePosition;
        //}
        //else
        //{
        //    //计算出鼠标位置与摇杆之间的方向向量
        //    dir = Input.mousePosition - initPos;

        //    transform.position = initPos + dir.normalized * r;
        //}

        isMove = true;
        //将摇杆方向向量归一化后传递给管理脚本
        dir = (Vector3)Input.GetTouch(0).position - initPos;
        //dir = Input.mousePosition - initPos;
        distance = Vector3.Distance(Input.GetTouch(0).position, initPos);
        rockerGameManager.distance = distance/100;
        //print("dis="+distance);
        rockerGameManager.dir = dir.normalized;
        //print(dir.normalized);

    }

    //鼠标松开
    public void OnDragEnd()
    {
        print("松开");
        isMove = false;
        transform.position = initPos;
    }
}
