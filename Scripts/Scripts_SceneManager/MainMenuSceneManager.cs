using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSceneManager : MonoBehaviour {
    //本脚本用于管理游戏主界面
    

	// Use this for initialization
	void Start () {
        List<string> btnsName = new List<string>();
        btnsName.Add("btnAbout");  //关于界面按钮
        btnsName.Add("btnStartGame");  //开始游戏按钮
        btnsName.Add("btnExitGame");   //退出游戏按钮

	    foreach (string btnName in btnsName)
	    {
	        GameObject btnObj=GameObject.Find(btnName);
	        Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate()
            {
                OnClick(btnObj);
            } );
	    }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            case "btnAbout":  //跳转到关于界面
                //print("about");
                SceneManager.LoadScene("AboutScene");
                break;
            case "btnStartGame":  //跳转到游戏模式界面
                //print("start");
                SceneManager.LoadScene("SwitchGameModeScene");
                break;
            case "btnExitGame":  //退出游戏
                print("exit");
                Application.Quit();
                break;
            default:
                print("没有找到按钮");
                break;

        }
    }
}
