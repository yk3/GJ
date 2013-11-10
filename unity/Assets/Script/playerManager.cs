using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {
	
	private Vector3 targetPos;
	private bool changeFlag = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Model" && !changeFlag) {
			//Debug.Log(targetPos);
			//targetPos = col.gameObject.transform.position;
			//transform.position = targetPos;
			//Debug.Log("oya = " + col.gameObject.transform.localEulerAngles.y);
			transform.rotation = Quaternion.identity;
			//Debug.Log("child = " + transform.localEulerAngles.y);
			
			//transform.rotation = Quaternion.identity;
			transform.parent = col.gameObject.transform;
			changeFlag = true;
			
			
		} else if (col.gameObject.tag == "Close") {
			//Debug.Log("close");
		}
			

		
	}
	
	void OnTriggerStay(Collider cols) {
		if (cols.gameObject.tag == "Close") {
				//Debug.Log("test");
				
		}
	}
}
