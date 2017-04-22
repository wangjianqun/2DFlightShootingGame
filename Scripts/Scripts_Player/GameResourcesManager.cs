using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResourcesManager : MonoBehaviour
{

    public int player_HP = 10;
    public int boss_HP = 30;
    public int journeyLength=60;
    public Text text;
    //public int m=60;
    public GameObject enemyGenerator;
    public GameObject boss;
    public GameObject player;
    public bool isToMove=false;
    public Slider player_HPSlider;
    public bool SetMove = true;


    float i = 0;

    private bool isBoss;


	// Use this for initialization
	void Start ()
	{
	    //journeyLength = 10;
	   //journeyLength = 60;
	}
	
	// Update is called once per frame
	void Update ()
	{

	    i += Time.deltaTime;
	    if (!isBoss)
	    {
            if (i>=1)
	    {
	        journeyLength--;
            //print(journeyLength);
	        i = 0;
	    }
	    
	        //m -= Time.deltaTime; 
	        
            
            //print("zhixing1l1");
            text.text = "距离Boss：" + journeyLength;
            text.text += "M";
            if (journeyLength <= 0)
            {
                Vector3 vec;
                vec = enemyGenerator.transform.position;
                //生成boss，停止生成小怪
                enemyGenerator.SetActive(false);

                Instantiate(boss, vec, Quaternion.identity);
                isBoss = true;
                journeyLength = 0;
                isToMove = true;
                //SendMessage("isEndPointToMove");  //调用isEndPointToMove函数来使终点线移动
                //isEndPointToMove();
                //print("传递消息");
            }
        }
	    if (isToMove)
	    {
	        if (SetMove)
	        {
	            PlayerToMove();
            }
	        

	    }
	    




        //print("HP="+player_HP);



        if (boss_HP<=0)
	    {
	        print("你赢了！");
            SceneManager.LoadScene("WinScene");

	    }
	}

    void PlayerToMove()
    {
        //print("主角移动");
        Vector3 playerPos = player.transform.position;
        Vector3 desPos=new Vector3(-8.2f,playerPos.y,0);
        float length = Vector3.Distance(playerPos, desPos);
        float fracLength = 0.05f / length;
        player.transform.position = Vector3.Lerp(playerPos, desPos, fracLength);
        if (playerPos.x<=desPos.x)
        {
            isToMove = false;
            print("停止移动");
        }

    }

    //游戏结束
    void GameOver()
    {
        SceneManager.LoadScene("FailureScene");
    }

    #region 主角血量管理

    //更新掉血
    public void LostBlood(int lostHP)
    {
        player_HP -= lostHP;
        if (player_HP<=0)
        {
            player_HP = 0;
            GameOver();
        }
        player_HPSlider.value = player_HP;
    }

    //加血
    public void AddBlood(int addHP)
    {
        player_HP += addHP;
        if (player_HP>=10)
        {
            player_HP = 10;
        }
        player_HPSlider.value = player_HP;


    }




    #endregion


}
