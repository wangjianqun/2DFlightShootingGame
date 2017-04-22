using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutSceneManager : MonoBehaviour {
    //管理游戏的“关于”界面


	// Use this for initialization
	void Start ()
	{
	    string btnName = "btnReturnMenu";
        GameObject btnObj=GameObject.Find("btnReturnMenu");
	    Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate()
        {
            this.OnClick(btnObj);
        } );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick(GameObject sender)
    {
        //print("返回");
        SceneManager.LoadScene("MainMenuScene");
    }
}
