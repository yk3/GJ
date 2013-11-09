using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	private Vector3 targetpos;
	private float rot;
	private bool flags = false;
	// Use this for initialization
	void Start () {
		Debug.Log("start = " + this.transform.localRotation);
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
		if (col.gameObject.tag == "Model") {
			Debug.Log("oya = " + col.gameObject.transform.localEulerAngles.y);
			//rot =  col.gameObject.transform.localEulerAngles;
			//transform.localRotation = col.gameObject.transform.localRotation;
			//transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.rotation = Quaternion.identity;
			Debug.Log("child = " + transform.localEulerAngles.y);

			//transform.rotation = Quaternion.identity;
			transform.parent = col.gameObject.transform;
			
			/*
			Vector3 targetpos = col.gameObject.transform.position;
			rot = Mathf.Atan2(targetpos.x - transform.position.x, targetpos.z - transform.position.z);
			rot = rot * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0.0f, rot, 0.0f));
			*/ 
			
			
			//this.transform.localEulerAngles.y = col.gameObject.transform.localEulerAngles.y;
			//transform.rotation = Quaternion.identity;
			//transform.rotation.y = col.gameObject.transform.localEulerAngles.y;
			//Debug.Log("tech + " + rot.y);
			//transform.parent = col.gameObject.transform;
			//transform.eulerAngle.y = col.gameObject.transform.EulerAngle.y;
			
		}
		
		
		
	}
}
