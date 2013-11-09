using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	private Vector3 rot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.localEulerAngles.y;
		//Debug.Log(transform.localEulerAngles.y);
	
	}
	
	void OnTriggerEnter(Collider col){
		//Debug.Log("Hit");
		/*
			if (col.gameObject.tag == "Model"){
				this.gameObject.transform.position = col.transform.position;
				Debug.Log("hit");

			}
		*/
		Debug.Log("hitss");
	}
}
