using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeSceneManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        List<string> btnsName = new List<string>();
        btnsName.Add("btnNormalMode");  //普通模式按钮
        btnsName.Add("btnVoiceMode");  //声控模式按钮
        btnsName.Add("btnReturnMain");   //返回主菜单按钮

        foreach (string btnName in btnsName)
        {
            GameObject btnObj = GameObject.Find(btnName);
            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                OnClick(btnObj);
            });
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            case "btnNormalMode":  //跳转到普通模式
                //print("about");
                SceneManager.LoadScene("RockerGameScene");
                break;
            case "btnVoiceMode":  //跳转到声控模式
                //print("start");
                SceneManager.LoadScene("AudioPitch");
                break;
            case "btnReturnMain":  //返回游戏主菜单
                //print("exit");
                SceneManager.LoadScene("MainMenuScene");
                break;
            default:
                print("没有找到按钮");
                break;

        }
    }
}
