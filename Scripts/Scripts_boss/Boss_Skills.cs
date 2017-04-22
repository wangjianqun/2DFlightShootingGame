using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Skills : MonoBehaviour
{

    public List<string> SkilList;
    //public List<GameObject> ObjList;  //0存放pollen,1存放stinger
    public GameObject pollen;  //花粉
    public GameObject stinger;  //毒刺
    public GameObject littleBee;  //小蜜蜂
    public GameObject bloodBag;  //血包
    private Vector3 bossPos;  //用于存放boss的位置
    private bool isSkill = false;  //判断要不要放技能
    public Boss_Move bossMove_Com;  //控制boss的移动脚本
    private bool isOpenInvoke;
    private float isTime = 0;
    public float CDTime;


    // Use this for initialization
    void Start ()
    {
        CancelInvoke();
        bossMove_Com = GetComponent<Boss_Move>();
		SkilList.Add("PollenAttack");  //技能：花粉攻击
        SkilList.Add("StingerAttack");  //技能：毒刺攻击
        SkilList.Add("DiveAttack");  //技能：俯冲攻击
        SkilList.Add("CallFriends");  //技能：呼朋引伴

	    //ObjList[0].name = "pollen";


        bossPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	    //if (isSkill)
	    //{
     //       //Pollen_Attack();
     //       //Stinger_Attack();

	    //    //bossMove_Com.enabled = false;
     //       //Dive_Attack();
     //       Call_Friends();
	    //}
	    CDTime += Time.deltaTime;
	    if (isOpenInvoke)
	    {
            //print("开始计时");
	        
	        isTime += Time.deltaTime;
	        if (isTime>=3)
	        {
                print("停止技能");
                CancelInvoke("InsLittleBee");
	            isTime = 0;
                isOpenInvoke = false;
            }
	        
	    }

	    if (CDTime>=10)
	    {
	        isSkill = true;
	    }
	    if (isSkill==true)
	    {
            switch (SkilList[Random.Range(0, SkilList.Count)])
            {
                case "PollenAttack":
                    Pollen_Attack();
                    break;
                case "StingerAttack":
                    Stinger_Attack();
                    break;
                case "DiveAttack":
                    Dive_Attack();
                    break;
                case "CallFriends":
                    Call_Friends();
                    break;
                default:
                    print("没有出技能");
                    break;

            }
	        bossMove_Com.enabled = true;
	        CDTime = 0;

	    }

	    
	}

    //技能：花粉攻击
    void Pollen_Attack()
    {
        //停止boss当前动作
        //播放动画
        

        Invoke("CreateDebris", 1);
        Invoke("CreateDebris", 2);
        Invoke("CreateDebris", 3);
        bossPos = transform.position;

        Instantiate(bloodBag, bossPos, Quaternion.Euler(0, 0, 0));


        //for (int i = 0; i < 3; i++)
        //{
        //CreateDebris();
        //}
        isSkill = false;

    }

    //得到boss位置
    void GetBossPos()
    {
        bossPos = transform.position;
    }

    //用于生成花粉
    void CreateDebris()
    {
        int angle;
        GetBossPos();
        //bossPos = transform.position;
        for (int i = 0; i < 36; i++)
        {
            //沿20°角生成花粉
            angle = i*10;
            Instantiate(pollen, bossPos, Quaternion.Euler(0, 0, angle));
        }

        
    }

    //技能：毒刺攻击
    void Stinger_Attack()
    {
        CreateStinger();
        Invoke("CreateStinger",0.5f);
        Invoke("CreateStinger",1f);
        Invoke("CreateStinger", 1.5f);
        Invoke("CreateStinger", 2f);
        Invoke("CreateStinger", 2.5f);
        isSkill = false;

    }

    void CreateStinger()
    {
        GetBossPos();
        Instantiate(stinger, bossPos, Quaternion.identity);
    }

    //技能：俯冲攻击
    void Dive_Attack()
    {
        
        bossMove_Com.enabled = false;
        bossPos = transform.position;
        Vector3 desPos = bossPos;
        desPos.x = -8;
        transform.position = Vector3.Lerp(bossPos, desPos, Time.deltaTime*1);
        if (transform.position.x<=-7.9)
        {
            isSkill = false;
            //攻击结束，切换回原来的移动方式
            bossMove_Com.enabled = true;
        }
        
    }

    //技能：呼朋引伴
    void Call_Friends()
    {
        bossMove_Com.enabled = false;
        //播放跳舞动画
        InvokeRepeating("InsLittleBee", 0, 0.5f);
        InvokeRepeating("InsLittleBee", 0, 0.5f);
        isOpenInvoke = true;
        isSkill = false;

    }

    void InsLittleBee()
    {
        Instantiate(littleBee, new Vector3(9.4f, Random.Range(-4.85f, 4.85f), 0), Quaternion.identity);

    }

}
