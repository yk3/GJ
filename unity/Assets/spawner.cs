using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	
	public Transform modelPrefab;
	public float startTime = 5.0f;
	private float timer;
	private GameObject m_kago;
	
	// Use this for initialization
	void Start () {
		timer = startTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			Instantiate(modelPrefab, transform.position, this.transform.localRotation);
			
			//Debug.Log("count0");
			timer = startTime;
		}
		
	}
}
