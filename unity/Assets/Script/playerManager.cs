using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {
	
	private Quaternion Rot = Quaternion.Euler(0, 90, 0);
//	private bool parentFlag = false;
	private bool changeFlag = false;
	private bool endFlag = false;
	
	public GameObject CamCon;
	public GameObject CamConR;
	private float timer;
	
	private GameObject[] kagos;
	private GameObject[] kagos2;
	private GameObject[] sekkin;
	private string[] sekkinmuki;
	private string muki;
	private string mukiCam;
	
	private int j;
	
	// Use this for initialization
	void Start () {
		OVRCameraController[] CameraControllers;
		CameraControllers = gameObject.GetComponentsInChildren<OVRCameraController>();
		if (CameraControllers.Length > 0) {
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (endFlag == false){
//		timer -= Time.deltaTime;
//		if (timer < 0) {
//		if (changeFlag == false) {
			kagos = GameObject.FindGameObjectsWithTag("Model");
			j = 0;
			sekkin = null;
			if (kagos != null){
//				Debug.Log( kagos.Length);
				for (int i = 0 ; i < kagos.Length ; i++){
					if (Vector3.Distance(transform.position, kagos[i].transform.position) < 0.5f)
					{
						j++;
					}
				}
				Debug.Log("Countj__" + j);
				sekkin = new GameObject[j];
				j=0;
				for (int i = 0 ; i < kagos.Length ; i++){
					if (Vector3.Distance(transform.position, kagos[i].transform.position) < 0.5f)
					{
						sekkin[j] = kagos[i];
//						Debug.Log ("_" + sekkin[j]);
//						Debug.Log ("_" + kagos[i]);
						j++;
					}
				}
				
				
//				Debug.Log ("tikai___" + j);
	Debug.Log("Cam__" + mukiCam);
				sekkinmuki = new string[j];
				if (sekkin != null){
					for(j = 0 ; j < sekkin.Length ; j++)
					{
						sekkinmuki[j] = mukiflag(sekkin[j]);
	Debug.Log("kago__"+j+"_" + sekkinmuki[j]);
							
			kagos2 = GameObject.FindGameObjectsWithTag("Model");
				for (int i = 0 ; i < kagos2.Length ; i++){
					if (Vector3.Distance(transform.position, kagos2[i].transform.position) < 0.1f)
					{
						CamConR = kagos2[i];
					}
				}
							
							
						mukiCam = mukiflag2(CamConR,CamCon);
						if(mukiCam == sekkinmuki[j]){
							transform.rotation = sekkin[j].transform.rotation;
							transform.position = sekkin[j].transform.position;
							transform.parent = sekkin[j].transform;
							changeFlag = true;
							Debug.Log("changeFlag_Out");
						}
					}
/*					if (changeFlag == false){
						Debug.Log("_tigau!!");
							transform.parent = null;
						endFlag = true;
					}
*/
				}
//			}
		}
	}
	else{
		this.transform.position = new Vector3(0,-1,0);
	}
	if (transform.position.y < -50){
		Application.LoadLevel("title");
	}
}
	
	string mukiflag(GameObject obj){
//		Debug.Log(obj.transform.localRotation.y);
		string mukiA ="";
		if (-0.25 < obj.transform.localRotation.y && obj.transform.localRotation.y < 0.25)
		{
			mukiA = "mae";
		}
		if (0.25 < obj.transform.localRotation.y && obj.transform.localRotation.y < 0.75)
		{
			mukiA = "rigi";
		}
		if (0.75 < obj.transform.localRotation.y || obj.transform.localRotation.y < -0.75)
		{
			mukiA = "usiro";
		}
		if (-0.75 < obj.transform.localRotation.y && obj.transform.localRotation.y < -0.25)
		{
			mukiA = "hidari";
		}
		
		Debug.Log(mukiA);
		return mukiA;
	}
	string mukiflag2(GameObject obj,GameObject Cam){
		
		float renY = Cam.transform.localRotation.y;
		
/*		if (obj != null){
			if (obj.transform.localRotation.y < 0.4f && obj.transform.localRotation.y < 0.6f){
			renY = Cam.transform.localRotation.y - 0.5f;
			}
			if (obj.transform.localRotation.y < -0.6f && obj.transform.localRotation.y < -0.4f){
			renY = Cam.transform.localRotation.y + 0.5f;
			}
			if (obj.transform.localRotation.y < -1.1f && obj.transform.localRotation.y < -0.9f){
			renY = Cam.transform.localRotation.y +1f;
			}
			if (obj.transform.localRotation.y < 9.9f && obj.transform.localRotation.y < 1.1f){
			renY = Cam.transform.localRotation.y - 1f;
			}
		}
		*/
		renY = Cam.transform.localRotation.y - obj.transform.localRotation.y;
		if (renY > 1){renY = renY -1;}
		if (renY < 0){renY = renY +1;}
		Debug.Log(renY);
		
		string mukiA ="";
		if (-0.25 < renY && renY < 0.25)
		{
			mukiA = "mae";
		}
		if (0.25 < renY && renY < 0.75)
		{
			mukiA = "rigi";
		}
		if (0.75 < renY || renY < -0.75)
		{
			mukiA = "usiro";
		}
		if (-0.75 < renY && renY < -0.25)
		{
			mukiA = "hidari";
		}
		
		Debug.Log(mukiA);
		return mukiA;
	}
	
/*
	void OnTriggerEnter(Collider col) {
//Debug.Log("OnTriggerEnter_Check__" + col.name);
		if (col.gameObject.tag == "Model" && changeFlag == false && parentFlag == false){
			transform.rotation = col.gameObject.transform.rotation;
			transform.position = col.gameObject.transform.position;
			transform.parent = col.gameObject.transform;
			changeFlag = true;
			parentFlag = true;
		} 
	}
*/
	
	void OnTriggerStay(Collider cols) {
		if (cols.gameObject.tag == "Close") {
			Debug.Log("testes__" + cols.gameObject.tag);
			changeFlag = false;
		}
		if (cols.gameObject.tag == "Goal") {
//			Debug.Log("Goal!!!!!!");
			Application.LoadLevel("title");
		}
	}
}
