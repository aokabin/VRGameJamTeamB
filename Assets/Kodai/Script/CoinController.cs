using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	GameObject player;
	PlayerController2 script;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		//script = player.GetComponent<DebugPlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.CompareTag ("Player")) {
			ScoreUP(collider);
			Destroy(this.gameObject);
		}
	}

	void ScoreUP(Collider collider) {
        script = collider.GetComponent<PlayerController2>();
        script.ScoreUP();
       // script.SendMessage("ScoreUp");
	}


}
