using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    //本脚本用于创建会帮助玩家的移动炮台（暂定）

    private float timeOver;
    private GameObject player;
    private bool isFollow=false;
    private Vector3 vec_player;
    public float speed=1;

	// Use this for initialization
	void Start () {
		player=GameObject.FindWithTag("Player");
	    isFollow = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
        //timeOver += Time.deltaTime;
        //if (timeOver>=6)
        //{
        //    isFollow = true;
        //}
        vec_player = player.transform.position;
        Follow_Player(isFollow,vec_player);
	    //isFollow = false;
        //transform.LookAt(player.transform,Vector3.left);



	}

    //跟随主角移动
    void Follow_Player(bool isFollow,Vector3 vec_player)
    {
        if (isFollow)
        {
            float step = speed*Time.deltaTime;

            

            

            //var rotation = Quaternion.LookRotation(vec_player);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime); //控制角色朝向

            //Vector3 relativePos = vec_player - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(relativePos);
            //transform.rotation = rotation;

            //改变朝向
            Vector3 moveDirection;
            float turnSpeed=1;
            moveDirection = vec_player - transform.position;
            moveDirection.z = 0;
            float taget = Mathf.Atan2(moveDirection.y, moveDirection.x)*Mathf.Rad2Deg;  //mathf.Rad2Deg为度到弧度的转化常量，Atan2为返回弧度角的正切是y/x
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, taget), turnSpeed*Time.deltaTime);



            //跟随主角移动
            //gameObject.transform.localPosition=new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x,vec_player.x,step),Mathf.Lerp(gameObject.transform.localPosition.y,vec_player.y,step),Mathf.Lerp(gameObject.transform.localPosition.z,vec_player.z,step));

            //环绕主角转动
            transform.Translate(Vector3.right*Time.deltaTime);


        }
        
    }

}
