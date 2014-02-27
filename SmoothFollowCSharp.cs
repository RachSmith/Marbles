using UnityEngine;
using System.Collections;
using Leap;

// Place the script in the Camera-Control group in the component menu
[AddComponentMenu("Camera-Control/Smooth Follow CSharp")]

public class SmoothFollowCSharp : MonoBehaviour
{
	/*
    This camera smoothes out rotation around the y-axis and height.
    Horizontal Distance to the target is always fixed.
 
    There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.
 
    For every of those smoothed values we calculate the wanted value and the current value.
    Then we smooth it using the Lerp function.
    Then we apply the smoothed values to the transform's position.
    */
	
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
	public float height = 5.0f;
	public float offset = 0f;
	// How much we 
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	Controller myController;

	private float rot = 0.0f;

	void Start() {
				myController = new Controller ();
		}
	
	void  LateUpdate ()
	{
		// Early out if we don't have a target
		if (!target)
			return;

		Frame myFrame = myController.Frame();
		HandList myHands = myFrame.Hands;
		Hand rightHand = myHands.Rightmost;
		Vector3 movement = (rightHand.PalmNormal.ToUnity ());
		
		// Calculate the current rotation angles

		Vector3 movementDirection = target.rigidbody.velocity;
		if (movementDirection.magnitude < 0.25f) {
						movementDirection = gameObject.transform.forward;
				}
		else { movementDirection.Normalize(); }
		Debug.Log (movementDirection); 
		float rad= Mathf.Atan2(movementDirection.z, movementDirection.x);
		float angle = Mathf.Rad2Deg *rad;

		float wantedRotationAngle = angle+offset; //target.eulerAngles.y;*/
		float wantedHeight = target.position.y + height;
		rot += (movement.x * -1*150 * Time.deltaTime);
		float currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		//currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0, rot, 0);
		//gameObject.transform.rotation = currentRotation;

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		//transform.position = target.position;
		//transform.position -= currentRotation * Vector3.forward*distance;

		transform.position = target.transform.position + (currentRotation * Vector3.forward* distance);// -1 * movementDirection * distance; 
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
		
		// Always look at the target
		transform.LookAt (target);
	}
}
