using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public float StationaryZ = 1;
    public float StationaryY = 1;
    public GameObject Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Target)
        {
            Vector3 MoveInput = GetInput();
            /***カメラの方向取得***/
            Target.transform.Rotate(MoveInput.normalized);
        }
	}

    Vector3 GetInput()
    {
        Vector3 input = new Vector3
        {
            x = 0f,//-Input.GetAxis("Vertical") * StationaryY, /***横の入力情報***/
            y = 0f,   /***縦の入力情報***/
            z = Input.GetAxis("Horizontal") * StationaryZ
        };

        return input;
    }
}
