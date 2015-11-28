using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	GameObject player;
	PlayerController2 script;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		script = player.GetComponent<PlayerController2>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.CompareTag ("Player")) {
			ScoreUP();
			Destroy(this.gameObject);
		}
	}

	void ScoreUP() {
		script.ScoreUP ();
	}


}
