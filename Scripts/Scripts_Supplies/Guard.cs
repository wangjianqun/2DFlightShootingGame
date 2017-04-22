using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    //本脚本用于创建保护玩家的辅助品

    public float overTime;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    overTime += Time.deltaTime;
	    if (overTime>=10)
	    {

	        overTime = 0;
            OnSleep();
	    }
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        //print("碰到了");
        if (collider2D.gameObject.layer==8)
        {
            audioSource.Play();
            Destroy(collider2D.gameObject);
        }
    }

    void OnSleep()
    {
        this.gameObject.SetActive(false);
    }



}
