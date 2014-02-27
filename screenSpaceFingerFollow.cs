using UnityEngine;
using System.Collections;

public class screenSpaceFingerFollow : MonoBehaviour {
	LeapManager _leapManager;
	// Use this for initializationm.
	void Start () {
		_leapManager = GameObject.Find ("LeapManager").GetComponent<LeapManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = _leapManager.pointerPositionWorld + Camera.main.transform.position + (Camera.main.gameObject.transform.rotation * Vector3.forward * 10.0f);
	}
}
