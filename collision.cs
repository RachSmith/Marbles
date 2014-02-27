using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {
	Camera wincam;
	SmoothFollowCSharp rotScript;
	GameObject cursor;
	//NewBehaviourScript maincam;
	// Use this for initialization
	void Start () {
		//maincam = GameObject.Find ("camera").GetComponent<NewBehaviourScript> ();
		wincam = GameObject.Find ("UI Camera").GetComponent<Camera>();
		cursor=GameObject.Find("Cursor");
		rotScript = Camera.main.gameObject.GetComponent<SmoothFollowCSharp> ();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.name == "Sphere") {
			wincam.enabled=true;
			cursor.renderer.enabled=true;
			rotScript.enabled = false;
			Camera.main.gameObject.transform.rotation = Quaternion.identity;

				if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha1)) {
					Application.LoadLevel("Map");
				}
				
				else if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha2)) {
					Application.LoadLevel("Level 2");
				}
				
			}
		}
			//Camera.main.transform.LookAt(GameObject.Find("Sphere").transform);
		//	maincam.enabled=false;
				
		


	// Update is called once per frame
	void Update () {
	
	}
}