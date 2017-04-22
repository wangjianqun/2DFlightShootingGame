using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailureSceneManager : MonoBehaviour {
    //管理游戏失败界面


	// Use this for initialization
    //
	void Start () {
        //创建一个列表用于存放按钮
		List<string> btnsName=new List<string>();
        //btnsName.Add("btnReturnGame");  //增加按钮
        btnsName.Add("btnToMenu");

	    foreach (string btnName in btnsName)
	    {
            //按照列表里的名字将按钮与列表
	        GameObject btnObj=GameObject.Find(btnName);
	        Button btn = btnObj.GetComponent<Button>();
            //利用委托来调用OnClick()函数
            btn.onClick.AddListener(delegate()
            {
                OnClick(btnObj);
            });
	    }
	}

    //管理各个按钮的功能
    void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            //case "btnReturnGame":
            //    //print("返回游戏");
            //    SceneManager.LoadScene("AudioPitch");
            //    break;
            case "btnToMenu":
                //print("返回主菜单");
                SceneManager.LoadScene("MainMenuScene");
                break;
            default:
                print("没有找到按钮");
                break;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
