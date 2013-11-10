using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	
	public GameObject title01;
	public GameObject title02;
	public GameObject title03;

	public GameObject Stage;
//	public Animation anim;
	
	public GameObject CamComt;
		
	
	// Use this for initialization
	void Start () {
	iTween.MoveBy(title01, iTween.Hash("z", -0.5f, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	iTween.MoveBy(title02, iTween.Hash("z", 0.5f, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	iTween.MoveBy(title03, iTween.Hash("y", 2f, "easeType", "easeInOutExpo", "loopType", "none", "delay", .20));
		
		
	}
	
	// Update is called once per frame
	void Update () {
//			Debug.Log(CamComt.transform.localRotation.x);
		if (-0.5f < CamComt.transform.localRotation.x && CamComt.transform.localRotation.x < -0.3f){
//			Debug.Log("AnimStart");
			Stage.GetComponent<Animation>().Play("TitleAnim");
//			animation.Play("TitleAnim");
		StartCoroutine(Submit());
		}
	
	}
	IEnumerator Submit()
	{
			yield return new WaitForSeconds(5);
			Debug.Log("GameStart");
			Application.LoadLevel("main");
	}
	
}
