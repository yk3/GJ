using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {
	
	private Quaternion Rot = Quaternion.Euler(0, 90, 0);
//	private bool parentFlag = false;
	private bool changeFlag = false;
	private bool endFlag = false;
	
	public GameObject CamCon;
	private float timer;
	
	private GameObject[] kagos;
	private GameObject[] sekkin;
	private string[] sekkinmuki;
	private string muki;
	
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
		if (changeFlag == false) {
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
				muki = mukiflag(CamCon);
	Debug.Log("Cam__" + muki);
				sekkinmuki = new string[j];
				if (sekkin != null){
					for(j = 0 ; j < sekkin.Length ; j++)
					{
						sekkinmuki[j] = mukiflag(sekkin[j]);
	Debug.Log("kago__"+j+"_" + sekkinmuki[j]);
						if(muki == sekkinmuki[j]){
							transform.rotation = sekkin[j].transform.rotation;
							transform.position = sekkin[j].transform.position;
							transform.parent = sekkin[j].transform;
							changeFlag = true;
							Debug.Log("changeFlag_Out");
						}
					}
					if (changeFlag == false){
						Debug.Log("_tigau!!");
							transform.parent = null;
						this.rigidbody.AddForce(new Vector3(0,-1000,0));
						
					}
					
				}
			}
		}
	}
	else{
		this.transform.position = new Vector3(0,-1,0);
	}
		if (transform.position.y < -200){
			Application.LoadLevel("title");
		}
	}
	
	string mukiflag(GameObject obj){
		Debug.Log(obj.transform.localRotation.y);
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
