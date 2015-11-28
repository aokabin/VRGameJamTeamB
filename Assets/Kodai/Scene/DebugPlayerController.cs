using UnityEngine;
using System.Collections;

public class DebugPlayerController : MonoBehaviour {

	public float power = 1.0f;
	public float score = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			transform.position += transform.forward * 0.1f;
		}
		if (Input.GetKey ("down")) {
			transform.position += transform.forward * -0.1f;
		}
		if (Input.GetKey("right")) {
			transform.position += transform.right * 0.1f;
		}
		if (Input.GetKey ("left")) {
			transform.position += transform.right * -0.1f;
		}

	}

	public void PowerUP() {
		Debug.Log("Power UP!!");
		power *= 2.0f;
	}

	public void ScoreUP() {
		Debug.Log("Score UP!!");
		score *= 1.1f;
	}
}
