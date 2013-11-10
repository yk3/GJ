using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {
	
	private Quaternion Rot = Quaternion.Euler(0, 90, 0);
	private bool changeFlag = false;
	// Use this for initialization
	void Start () {
		OVRCameraController[] CameraControllers;
		CameraControllers = gameObject.GetComponentsInChildren<OVRCameraController>();
		if (CameraControllers.Length > 0) {
		//Debug.Log("CCCCCCCCCCCCCCCCCCCCCC");
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Model" && col.gameObject.transform.localEulerAngles.y == transform.localEulerAngles.y) {
			//Debug.Log("sin");
			//targetPos = col.gameObject.transform.position;
			//transform.position = targetPos;
			//Debug.Log("oya = " + col.gameObject.transform.localEulerAngles.y);
			transform.rotation = Quaternion.identity;
			//Debug.Log("child = " + transform.localEulerAngles.y);
			//currentRot = col.gameObject.transform.localEulerAngles.y;
			//transform.rotation = Quaternion.identity;
			transform.parent = col.gameObject.transform;
			changeFlag = true;
		} 			 
	}

	
	void OnTriggerStay(Collider cols) {
		if (cols.gameObject.tag == "Close") {
			//rot = cols.gameObject.transform.localEulerAngles.y;
			//Debug.Log("testes" + rot);
			//Debug.Log("ayaya" +cols.gameObject.transform.eulerAngles.y);
			//transform.rotation(new Vector3(0, 90, 0));
			//transform.parent = cols.gameObject.transform;
				
		}
	}
}
