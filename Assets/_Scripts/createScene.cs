using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class createScene : MonoBehaviour {

	private List<GameObject> list = new List<GameObject>();
	public float posY = 0;
	public GameObject prefab = null;
	public GameObject first = null;
	private GameObject last = null;
	private int flag = 1;
	// Use this for initialization
	void Start () 
	{
		list.Add (first);
		last = first;
		for (int i = 1; i < 6; i++)
		{
			float dis = Random.Range (2.0f, 5.0f);
			float scale = Random.Range (0.3f, 0.8f);
			float height = Random.Range (7.0f, 14.0f);
			GameObject go = Instantiate(prefab, new Vector3(last.transform.position.x + dis, posY, 0), new Quaternion()) as GameObject;
			go.transform.localScale = new Vector3(scale, height, 1);
			last = go;
			list.Add(go);
		}
//		Debug.Log (list [1].transform.position);
//		Debug.Log (list [2].transform.position);
//		foreach(GameObject go in list)
//		{
//			Debug.Log(go.transform.position);
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if (list.Count <= 6)
		if (Camera.main.WorldToScreenPoint(list[3].transform.position).x <= 0)
		{
			Destroy(list[1].gameObject);
			list.RemoveAt(1);

			float dis = Random.Range (2.0f, 5.0f);
			float scale = Random.Range (0.4f, 0.8f);
			float height = Random.Range (7.0f, 14.0f);
			GameObject go = Instantiate(prefab, new Vector3(last.transform.position.x + dis, posY, 0), new Quaternion()) as GameObject;
			go.transform.localScale = new Vector3(scale, height, 1);
			last = go;
			list.Add(go);
			//flag = flag + 1;
		}
	}
}
