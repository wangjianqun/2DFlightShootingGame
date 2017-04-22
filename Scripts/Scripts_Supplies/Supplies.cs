using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //补给品遇到主角，被主角吃掉，自动消失
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
        }
    }
}
