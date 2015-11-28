using UnityEngine;
using System.Collections;

public class RingController : MonoBehaviour {

	GameObject player;
	DebugPlayerController script;
	float rotateZ = 0.0f;
	float hit_range = 20.0f;
	public float fall_speed = 1.0f;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		script = player.GetComponent<DebugPlayerController>();
		rotateZ = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
//		rotateZ = 0.1f;
//		this.transform.Rotate (new Vector3 (0, 0, rotateZ));
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.CompareTag ("Player")) {
			float userZ = player.gameObject.transform.eulerAngles.z;
			float ringZ = this.transform.eulerAngles.z;
			
			Debug.Log(userZ);

			if (userZ + hit_range >= 360.0f) {
				userZ -= 360.0f;
			}

			if (ringZ + hit_range >= 360.0f) {
				ringZ -= 360.0f;
				if (userZ + (hit_range * 2) >= 360.0f) {
					userZ -= 360.0f;
				}
			}

			Debug.Log(ringZ - hit_range);
			Debug.Log(ringZ + hit_range);
			Debug.Log(userZ);

			if ((ringZ - hit_range) <= userZ && (ringZ + hit_range) >= userZ) {
				Debug.Log("PowerUP!");
				PowerUP();
			}

//			Destroy(this.gameObject);
		}
	}

	private void PowerUP() {
		script.PowerUP();
	}
}
