using UnityEngine;
using System.Collections;

public class RingController : MonoBehaviour {

	public Camera player;
	GameObject head;
	PlayerController2 script;
	float rotateZ = 0.0f;
	float hit_range = 40.0f;
	public float fall_speed = 1.0f;
	
	// Use this for initialization
	void Start () {
//		player = GameObject.Find("Player");
//		player = GameObject.FindWithTag ("Player");
		head = transform.FindChild("Head").gameObject;
		script = GameObject.Find("Player").GetComponent<PlayerController2>();
		rotateZ = 1.0f;
//		Debug.Log (this.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
//		rotateZ = 0.1f;
//		this.transform.Rotate (new Vector3 (0, 0, rotateZ));
//		Vector3 coinVector = new Vector3(head.transform.position.x, 0, head.transform.position.z);
//		Vector3 playerVector = new Vector3(player.transform.position.x, 0, player.transform.position.z);
//
//		Debug.Log (coinVector);
//		Debug.Log (playerVector);
//		
//		float diff = Vector3.Angle(coinVector, playerVector);
//		Debug.Log (diff); 
//		Debug.Log (this.transform.position);
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log (collider.gameObject.tag);
		if(collider.gameObject.CompareTag ("Player")) {
//			Vector3 user = new Vector3(player.gameObject.transform.position.x, 0, player.gameObject.transform.position.z);
//			GameObject head = transform.FindChild("Head").gameObject;
			Vector3 coinVector = new Vector3(head.transform.position.x, 0, head.transform.position.z);
			Vector3 playerVector = new Vector3(player.transform.position.x, 0, player.transform.position.z);

			float diff = Vector3.Angle(coinVector, playerVector);

			if(diff < hit_range) {
				Debug.Log("PowerUP!");
				PowerUP();
			}
			
			Destroy(this.gameObject);

//			float userY = player.gameObject.transform.eulerAngles.z;
//			float ringY = this.transform.eulerAngles.y;
			
//			Debug.Log(userY);

//			if (userY + hit_range >= 360.0f) {
//				userY -= 360.0f;
//			}
//
//			if (ringY + hit_range >= 360.0f) {
//				ringY -= 360.0f;
//				if (userY + (hit_range * 2) >= 360.0f) {
//					userY -= 360.0f;
//				}
//			}

//			Debug.Log(ringY - hit_range);
//			Debug.Log(ringY + hit_range);
//			Debug.Log(userY);

//			if ((ringY - hit_range) <= userY && (ringY + hit_range) >= userY) {


		}
	}

	private void PowerUP() {
		script.PowerUP();
	}
}
