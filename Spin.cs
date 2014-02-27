using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	float rotations= 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(6.0f*rotations*Time.deltaTime,6.0f*rotations*Time.deltaTime,6.0f*rotations*Time.deltaTime);
		}

	}

