using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour {

    //本脚本用于创建游戏胜利界面
	// Use this for initialization
	void Start () {
        //创建列表用于存放按钮
		List<string> btnsName=new List<string>();
        //btnsName.Add("btnResume");
        btnsName.Add("btnReturMenu");  //返回主菜单


	    foreach (string btnName in btnsName)
	    {
	        GameObject btnObj = GameObject.Find(btnName);
	        Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate()
            {
                this.OnClick(btnObj);
            } );
	    }

	}

    public void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            //case "btnResume":
            //    //print("按下了btnResume");
            //    resume();
            //    break;
            case "btnReturMenu":
                //print("按下了btnReturMenu");
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



    public void resume()
    {
        SceneManager.LoadScene("AudioPitch");
    }

}
