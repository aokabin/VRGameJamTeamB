using UnityEngine;
using System.Collections;

public class DebugPlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			transform.position += transform.forward * 0.1f;
		}
		if (Input.GetKey("right")) {
			transform.position += transform.right * 0.1f;
		}
		if (Input.GetKey ("left")) {
			transform.position += transform.right * -0.1f;
		}
	}
}
