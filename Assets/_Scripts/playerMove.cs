using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour 
{
	public float gravity = -10;
	public float upSpeed = 20;
	public float rightSpeed = 30;
	public bool isJump = false;

	public GameObject camera = null;

	private float upSpeed_;
	private float rightSpeed_;
	private int flag = 0;
	private bool isOver = false;

	// Use this for initialization
	void Start () 
	{
		upSpeed_ = 0;
		rightSpeed_ = 0;
//		Debug.Log (Camera.main.WorldToScreenPoint (transform.position));
//		Debug.Log (Screen.width);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isOver && Input.GetKeyDown(KeyCode.Space))
		{
			ResetMovePlayer();
		}

		if (flag == 0 && Camera.main.WorldToScreenPoint(transform.position).x >= Screen.width / 2)
		{
			//rightSpeed_ = 0;
			flag = 1;
			camera.gameObject.GetComponent<cameraFollow>().SetFlag(1);
		}

		if (isJump)
		{
			MovePlayer ();
		}

//		CollisionDetecte ();
	}

	void MovePlayer()
	{
		Vector3 pos = new Vector3 ();
		pos = transform.position;
		pos.x += Time.deltaTime * rightSpeed_;
		upSpeed_ += gravity * Time.deltaTime;
		pos.y += upSpeed_ * Time.deltaTime;
		pos.z = 0;
		transform.position = pos;
	}

	void ResetMovePlayer()
	{
		this.rigidbody.isKinematic = false;
		upSpeed_ = upSpeed;
		rightSpeed_ = rightSpeed;
		isJump = true;
		flag = 0;
	}

//	void CollisionDetecte ()
//	{
//		foreach(GameObject go in FindObjectsOfType(GameObject))
//		{
//
//		}
//	}

	void OnCollisionEnter(Collision hit)
	{
		Debug.Log("hit");
		if (hit.gameObject.tag == "zhuzi")
		{
			this.rigidbody.isKinematic = true;
			isJump = false;
			rightSpeed_ = 0;
			flag = 2;
			camera.gameObject.GetComponent<cameraFollow>().SetFlag(flag);
		}
	}


//	void OnCollisionEnter(Collision hit) 
//	{
//		Debug.Log("hit");
//		if (hit.gameObject.tag == "zhuzi")
//		{
////			Debug.Log(transform.position);
////			Debug.Log(hit.gameObject.transform.position);
//			Vector3 collisionPos = (hit.contacts[0].point + hit.contacts[2].point) / 2;
////			Debug.Log(collisionPos.x);
////			Debug.Log(collisionPos.y);
////			Debug.Log(collisionPos.z);
//			float height = hit.gameObject.transform.position.y + hit.gameObject.transform.localScale.y / 2;
//			float min_width = hit.gameObject.transform.position.x - hit.gameObject.transform.localScale.x / 2;
//			float max_width = hit.gameObject.transform.position.x + hit.gameObject.transform.localScale.x / 2;
//			Debug.Log(hit.contacts[2].point.x);
//			Debug.Log(min_width);
//			//collision zhuzi's left
//			if (transform.position.y - transform.localScale.y / 2 < (height - 0.1f))
//			{
//				Debug.Log("drop down 1");
//				isOver = true;
//				isJump = false;
//				rightSpeed_ = 0;
//				flag = 0;
//				camera.gameObject.GetComponent<cameraFollow>().SetFlag(flag);
//				transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
//				transform.GetComponent<Rigidbody>().useGravity = true;
//			}
//			else
//			{
//				//collision zhuzi's center
//				if (Mathf.Abs(collisionPos.x - (min_width + max_width) / 2) <= 0.1f ) 
//				{
//					Debug.Log ("double score");
//				}
//				//collision zhuzi's top left
//				else if (hit.contacts[2].point.x < (min_width))
//				{
//					Debug.Log("drop down");
//					isOver = true;
//					isJump = false;
//					rightSpeed_ = 0;
//					flag = 0;
//					camera.gameObject.GetComponent<cameraFollow>().SetFlag(flag);
//					transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
//					transform.GetComponent<Rigidbody>().useGravity = true;
//				}
//				//collision zhuzi's right
//				else if(hit.contacts[0].point.x == (max_width))
//				{
//					Debug.Log("right");
//					this.rigidbody.isKinematic = true;
//					isJump = false;
//					rightSpeed_ = 0;
//					flag = 2;
//					camera.gameObject.GetComponent<cameraFollow>().SetFlag(2);
//					transform.position = new Vector3(this.transform.position.x - 0.05f, this.transform.position.y, this.transform.position.z);
//				}
//				//collisiton other
//				else
//				{
//					this.rigidbody.isKinematic = true;
//					isJump = false;
//					rightSpeed_ = 0;
//					flag = 2;
//					camera.gameObject.GetComponent<cameraFollow>().SetFlag(2);
//				}
//			}
//		}
//	}

//	void OnTriggerEnter(Collider hit)
//	{
//		Debug.Log("hit");
//		if (hit.gameObject.tag == "zhuzi")
//		{
//			isJump = false;
//			rightSpeed_ = 0;
//			flag = 2;
//			camera.gameObject.GetComponent<cameraFollow>().SetFlag(2);
//		}
//	}

}
