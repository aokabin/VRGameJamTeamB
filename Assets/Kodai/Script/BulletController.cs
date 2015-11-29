using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float bullet_speed = 1.0f;

	// Use this for initialization
	void Start () {
		//bullet_speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition += transform.forward * Time.deltaTime * bullet_speed;	
	}
}
