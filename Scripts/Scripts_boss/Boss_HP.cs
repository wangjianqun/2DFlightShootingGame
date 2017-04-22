using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_HP : MonoBehaviour
{

    public int bossHP;
    public GameResourcesManager manager;
    public Texture2D bruise;
    
    private SpriteRenderer spriteRenderer;
    private float flickerDuration = 0.1f;
    private float flickerTime = 0f;
    private float flickerOverTime = 1f;
    private float flicker_startTime = 0f;
    private bool isFlicker = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	    spriteRenderer = this.GetComponent<SpriteRenderer>();
        manager = GameObject.FindGameObjectWithTag("resourcesManager").GetComponent<GameResourcesManager>();
	    bossHP = manager.boss_HP;
	}
	
	// Update is called once per frame
	void Update () {
	    //renderer.color = Color.white;
	    //print("变回去");
	    if (isFlicker)
	    {
	        SpriteFlicker();
	        flicker_startTime += Time.deltaTime;
	        if (flicker_startTime>=flickerOverTime)
	        {
	            isFlicker = false;
	            spriteRenderer.color = Color.white;
	            flicker_startTime = 0;
	        }
	    }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (collider2D.gameObject.tag=="bullet")
        {
            audioSource.Play();
            print("被打到了");
            bossHP--;
            isFlicker = true;
            manager.boss_HP = bossHP;
            if (bossHP <= 10)
            {
                //替换成受伤图片
                print("我要死了");
                
                Bruise();
            }
            
            Destroy(collider2D.gameObject);
        }
        
    }

    //使物体变色
    void SpriteFlicker()
    {
        print("开始变色");
        flickerTime = flickerTime + Time.deltaTime;
        if (flickerTime>=flickerDuration)
        {
            if (spriteRenderer.color==Color.white)
            {
                spriteRenderer.color = Color.red;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            flickerTime = 0;
        }

    }


    void Bruise()
    {
        SpriteRenderer sprBruise = gameObject.GetComponent<SpriteRenderer>();
        Texture2D texture2d = bruise;
        Sprite sp = Sprite.Create(texture2d, sprBruise.sprite.textureRect, new Vector2(0.5f, 0.5f));
        sprBruise.sprite = sp;
    }
}
