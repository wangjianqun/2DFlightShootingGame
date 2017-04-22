using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    //本脚本用于创建主角控制器
    public Component[] supplies_guard;
    public int HP;
    public Supplies_Clear suppliesClear;
    public Slider HPSlider;  //血条
    private AudioSource[] audioSources;

    //通过GameResourcesManager类来管理游戏资源
    public GameResourcesManager resourcesManager;

	// Use this for initialization
	void Start ()
	{
	    audioSources = GetComponents<AudioSource>();
	    HP = resourcesManager.player_HP;
        
        HPSlider.value = HPSlider.maxValue = HP;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    HP = resourcesManager.player_HP;
        //print(HP);
	    HPSlider.value = HP;
        //更新主角形状
	    transform.localScale = new Vector3(0.5f + HP * 0.05f, 0.5f + HP * 0.05f, 1);

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        //print(collider2D.gameObject.layer);
        
        //通过物品标签来确定主角遇到了什么
        //PS:因为主角在防护罩的范围内，因此不给防护罩贴标签
        switch (collider2D.gameObject.layer.ToString())
        {
            case "8":  //遇到敌人,敌人的layer为8
                Meet_Enemy(collider2D.gameObject);
                //print("layer为敌人");
                break;
            case "9"://遇到补给品，补给品的layer为9
                Meet_Supplies(collider2D.gameObject);
                break;

            default:
                //print("这个物品没有贴标签(tag)吧");
                break;
                

        }
        if (collider2D.gameObject.tag=="boss"||collider2D.gameObject.tag=="over")
        {
            GameOver();
        }


        /*if (collider2D.gameObject.tag=="enemy"||collider2D.gameObject.tag=="wall")
        {
            Debug.Log("碰到敌人-2HP");
            LostBlood(2);
            Destroy(collider2D.gameObject);  //删除碰到的敌人
            //进入无敌时间
            //减小

            //GameOver();
            //Destroy(this.gameObject);
        }
        if (collider2D.gameObject.tag == "supplies")
        {
            print("碰到补给品");

            

            //如果碰到了清除全场敌人的触发器，发送消息给supplies_Clear对象
            //if (collider2D.gameObject.name == "supplies_clear_Trigger")
            //{
            //    print("发送消息");
            //    //SendMessage("ClearEnemys");


            //}

            //通过名字确定碰到的物品
            switch (collider2D.gameObject.name)
            {
                case "supplies_clear_Trigger":
                    print("发送消息");
                    break;

                case "supplies_bloodBag":
                    print("吃到血包");
                    AddBlood(6);
                    break;

                default:
                    print("碰到了奇怪的东西");
                    break;
            }



        }*/
    }

    //游戏结束时调用
    void GameOver()
    {
        //GameObject obj=GameObject.Find("endPoint");
        //obj.GetComponent<EndPoint>().enabled = false;
        SceneManager.LoadScene("FailureScene");
    }

    

    //更新主角形状(已废弃)
    //void Shape_Change()
    //{
    //    print("更新主角形状");
          
    //}

    
    

    //处理碰到的不同怪物
    void Meet_Enemy(GameObject enemy)
    {
        audioSources[0].Play();
        //switch (enemy.name)
        //{
        //    case "enemy":
        //        print("碰到普通敌人");
        //        LostBlood(2);
        //        //Destroy(enemy);
        //        break;
                
        //    default:
        //        print("碰错人了吧！");
        //        break;
        //}

        //LostBlood(2);
        resourcesManager.LostBlood(2);
        //Shape_Change();
        //print(enemy.name);
        Destroy(enemy);
    }

    #region 处理遇到的不同补给品，名字要随时更新
    void Meet_Supplies(GameObject supplies)
    {
        audioSources[1].Play();
        switch (supplies.tag)
        {
            case "supplies_guard_Trigger":
                print("发送消息");
                supplies_guard = this.GetComponentsInChildren<Transform>(true);
                foreach (Component child in supplies_guard)
                {
                    if (child.gameObject.name == "guard")
                    {
                        //print(child.gameObject.name);
                        print("设置好了");
                        child.gameObject.SetActive(true);

                    }


                }
                break;

            case "supplies_bloodBag":
                print("吃到血包");
                //AddBlood(6);
                resourcesManager.AddBlood(10);
                //Shape_Change();
                break;

            case "supplies_clear_Trigger":
                print("清全场");
                Enemy_Clear();
                break;



            default:
                //print("碰到了奇怪的东西");
                break;
        }
        print(supplies.name);
        Destroy(supplies);
    }


    #endregion



    //开始清场
    void Enemy_Clear()
    {
        suppliesClear.SendMessage("ClearEnemys");
    }

    #region 管理主角血量（现已集成到GameResourcesmanager脚本中）

    ////更新主角掉血时的血条
    //public void LostBlood(int lostHP)
    //{
    //    HP -= lostHP;


    //    ChangeGameResourcesManager_HP();
    //    if (HP<=0)
    //    {
    //        HP = 0;

    //        ChangeGameResourcesManager_HP();
    //        GameOver();
    //    }
    //    HPSlider.value = HP;
    //    print(HP);
    //    Shape_Change();

    //}

    ////更新主角加血后的血条
    //void AddBlood(int addHP)
    //{
    //    HP += addHP;
    //    ChangeGameResourcesManager_HP();
    //    if (HP>=10)
    //    {
    //        HP = 10;
    //        ChangeGameResourcesManager_HP();

    //    }
    //    HPSlider.value = HP;
    //    Shape_Change();
    //}


    ////将更新后的主角HP数值写入管理类
    //void ChangeGameResourcesManager_HP()
    //{
    //    resourcesManager.player_HP = HP;
    //}
    #endregion

}
