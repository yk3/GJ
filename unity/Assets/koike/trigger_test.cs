using UnityEngine;
using System.Collections;

public class trigger_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col) {
    	Debug.Log("juns!");
	}
}
