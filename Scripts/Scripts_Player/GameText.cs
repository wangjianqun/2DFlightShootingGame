using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameText : MonoBehaviour {

    //本脚本为实验性脚本，请勿使用

    public Component[] supplies_guard;


    // Use this for initialization
    void Start () {
        supplies_guard = GetComponentsInChildren<Transform>(true);
        foreach (Component child in supplies_guard)
        {
            if (child.gameObject.name == "child")
            {
                print("激活好了");
                child.gameObject.SetActive(true);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
