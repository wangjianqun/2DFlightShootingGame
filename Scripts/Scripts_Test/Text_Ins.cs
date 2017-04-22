using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Ins : MonoBehaviour
{
    public GameObject obj;
    private Vector3 pos;
    public float z;
	// Use this for initialization
	void Start ()
	{
	    pos = transform.position;
	    Instantiate(obj, pos, Quaternion.Euler(0, 0,z));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
