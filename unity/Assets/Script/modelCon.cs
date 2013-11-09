using UnityEngine;
using System.Collections;

public class modelCon : MonoBehaviour {

	private RaycastHit	hit;				//hitオブジェクト取得;
	public GameObject Box;
	public float m_Speed = 1;
	public float m_DownSpeed = 8;
	private bool LaneEndFlg = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Physics.Raycast(this.transform.position , Box.transform.up ,out hit,100);
//		Debug.Log(hit.transform);
		if (hit.transform != null){
			if (hit.transform.gameObject.tag == "LaneEnd"){
				LaneEndFlg = true;
			}
		}	
		transform.Translate(-Vector3.forward * Time.deltaTime * m_Speed);
		
		if (LaneEndFlg){
			transform.Translate(Vector3.down * Time.deltaTime * m_DownSpeed);
			if (this.transform.position.y < -50)
			{
				Destroy(gameObject);
			}
		}
	}
	
	
}
