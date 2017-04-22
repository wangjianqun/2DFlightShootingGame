using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //本脚本用于子弹物体
    private float nowTime;
    public float speed = 5;
    public float overTime=5;
    private AudioSource audioSource;
    //public AudioClip audio_bomb;

	// Use this for initialization
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    nowTime += Time.deltaTime;
	    if (nowTime>=overTime)
	    {
	        
	        Destroy(this.gameObject);
	    }
        transform.Translate(Vector3.right*Time.deltaTime*speed);

	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer==8)
        {
            audioSource.Play();
            Destroy(collider2D.gameObject);
            
        }
    }
}
