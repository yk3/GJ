using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {
	
	private Quaternion Rot = Quaternion.Euler(0, 90, 0);
	private bool changeFlag = false;
	private bool endFlag = false;
	
	public GameObject CamCon;
	public GameObject OyaMdel;
	public GameObject NextKag;

	private float timer;
	
	private GameObject[] kagos;
	private GameObject[] sekkin;

	private string Nextmuki;
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
	timer -= Time.deltaTime;
//		if (timer < 0) {
//		if (changeFlag == false) {

		//かごを全て取得;
		kagos = GameObject.FindGameObjectsWithTag("Model");
		j = 0;
		sekkin = null;		//接近かごのリストを入れる配列を初期化;

		if (kagos != null){
//				Debug.Log( kagos.Length);
			for (int i = 0 ; i < kagos.Length ; i++){		//近いかごの数を取得;
				if (Vector3.Distance(transform.position, kagos[i].transform.position) < 0.2f)
				{
					j++;
				}
			}
			
			sekkin = new GameObject[j];		//近いかごの数だけ配列を作成;

			j=0;
			for (int i = 0 ; i < kagos.Length ; i++){
				if (Vector3.Distance(transform.position, kagos[i].transform.position) < 0.2f)
				{
					if (Vector3.Distance(transform.position, kagos[i].transform.position) < 0.1f)
					{
						OyaMdel = kagos[i];	//親のかごを取得;
					}
					sekkin[j] = kagos[i];
					
					if (OyaMdel.transform.localRotation.y != kagos[i].transform.localRotation.y) {
						NextKag = kagos[i];		//近いかごの中で向きが親かごと違うものを取得;
					}
					j++;
				}
			}
		mukiCam = mukiflag(CamCon);		//カメラの向いている向きを取得;
//乗り換える処理;
			if (NextKag != null){
				Nextmuki = mukiflag(NextKag);
				if (Nextmuki == mukiCam){	//向きが同じ場合;
//					transform.rotation = NextKag.transform.rotation;
					transform.position = NextKag.transform.position;
					transform.parent = NextKag.transform;
					changeFlag = true;	//かごに乗ったらもう使わない処理;
				}
			}
			else{
				if (OyaMdel != null){
					transform.position = OyaMdel.transform.position;
					transform.parent = OyaMdel.transform;
					changeFlag = true;	//かごに乗ったらもう使わない処理;
				}
			}
/*
//向きが違った時に落ちる処理フラグを建てる;
		if (NextKag != OyaMdel && NextKag != OyaMdel){
			Debug.Log("_tigau!!");
			transform.parent = null;
			endFlag = true;
		}
*/
		}
	}
	if (endFlag == true){		//落下処理;
		this.transform.position = new Vector3(0,-1,0);
	}
	if (transform.position.y < -20){		//死亡処理　タイトルに戻す;
		Application.LoadLevel("title");
	}
}
	
	string mukiflag(GameObject obj){
		float renY = 0;
		renY = obj.transform.localRotation.y;
		if (renY > 1){renY = renY -1;}
		if (renY < -1){renY = renY +1;}
//Debug.Log(renY);
		string mukiA ="";
		if (-0.25 < renY && renY < 0.25)
		{
			mukiA = "Mae";
		}
		if (0.25 < renY && renY < 0.75)
		{
			mukiA = "Migi";
		}
		if (0.75 < renY || renY < -0.75)
		{
			mukiA = "Usiro";
		}
		if (-0.75 < renY && renY < -0.25)
		{
			mukiA = "Hidari";
		}
		
		return mukiA;
	}

/*
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Model" && changeFlag == false){
			transform.rotation = col.gameObject.transform.rotation;
			transform.position = col.gameObject.transform.position;
			transform.parent = col.gameObject.transform;
			changeFlag = true;	//かごに乗ったらもう使わない処理;
		}
	}
*/
	
	void OnTriggerStay(Collider cols) {
		if (cols.gameObject.tag == "Close") {
			changeFlag = false;
		}
		if (cols.gameObject.tag == "Goal") {
			Application.LoadLevel("title");
		}
	}
//デバッグ表示;
	
	private void OnGUI()
	{
		GUILayout.Label("mukiCam__" + mukiCam);
		GUILayout.Label("Nextmuki__" + Nextmuki);
		GUILayout.Label("CamCon__" + CamCon.transform.localRotation.y);
	}

	
}
