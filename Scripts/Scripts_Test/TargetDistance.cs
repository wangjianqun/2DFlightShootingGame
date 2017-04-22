using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDistance : MonoBehaviour
{
    //本脚本为测试距离终点时所用，勿使用

    public Text text;
    private int m=20;
    public bool endPointIsMove;
    

	// Use this for initialization
	void Start () {
        
    }

    void OnEnable()
    {
        if (this.GetComponent<Text>()==null)
        {
            this.gameObject.AddComponent<Text>();

        }
        text = this.GetComponent<Text>();
    }

	// Update is called once per frame
	void Update ()
	{

	    if (m>=14)
	    {
            m = (int)(20 - Time.time);
        }
	    else
	    {
	        endPointIsMove = true;
            SendMessage("isEndPointToMove");//调用EndPoint脚本里的isEndPointToMove函数来使终点移动
            //print("传递消息");
        }
        

        text.text = "距离终点：" + m;
        text.text += "M";
    }

    void isEndPointToMove()
    {
        print("被我调用了");
    }
}
