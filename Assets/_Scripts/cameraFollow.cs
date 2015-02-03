using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	private int flag = 0;
	private Transform target = null;
	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (flag == 0)
		{

		}
		if (flag == 1)
		{
			Vector3 pos = target.position;
			pos.y = transform.position.y;
			pos.z = transform.position.z;
			transform.position = pos;
		}
		if (flag == 2)
		{
			Vector3 pos = transform.position;
			pos.x += 5 * Time.deltaTime;
			transform.position = pos;
			float dis = transform.position.x - target.position.x;
			if (dis >= 2)
			{
				flag = 0;
			}
		}
	}

	public void SetFlag(int flag)
	{
		this.flag = flag;
	}
}
