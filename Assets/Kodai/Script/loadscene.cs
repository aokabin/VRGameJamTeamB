using UnityEngine;
using System.Collections;

public class loadscene : MonoBehaviour {
    private int count;
	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (Input.GetMouseButton(0))
        //{
        //    Application.LoadLevel(1);
        //}

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, 100))
        {
            count++;
            Debug.Log(count);
            if (count >= 150)
            {
                Application.LoadLevel(1);
            }
        }
	}
}
