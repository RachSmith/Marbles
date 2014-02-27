using UnityEngine;
using System.Collections;
using Leap;


public class l1done : MonoBehaviour {
	Controller controller;
	LeapManager _leapManager;
	RaycastHit hit = new RaycastHit();
	Ray myray = new Ray();
	public LayerMask hitMask;
	public Color startcolor;
	public Color endcolor;
	float timer=0f;
	string lastHover="";
	GameObject cursor;
	GameObject targetCamera;
	Camera myCam;
	// Use this for initialization
	void Start () {
		controller= new Controller();
		_leapManager = GameObject.Find ("LeapManager").GetComponent<LeapManager> ();
		_leapManager._mainCam = Camera.main;
		cursor=GameObject.Find("Cursor");
		//targetCamera = Camera.main;
		myCam = gameObject.GetComponent<Camera> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		float percent;
		Frame frame = controller.Frame ();
		Pointable pointable = frame.Pointables.Frontmost;
		//Vector direction = pointable.Direction;
		//float length = pointable.Length;
		//float width = pointable.Width;
		//Vector stabilizedPosition = pointable.StabilizedTipPosition;
		Vector position = pointable.TipPosition;
		//Vector speed = pointable.TipVelocity;
		//float touchDistance = pointable.TouchDistance;
		Pointable.Zone zone = pointable.TouchZone;
		
		Vector3 pointerPos = gameObject.transform.position + _leapManager.pointerPositionWorld + (gameObject.transform.rotation * Vector3.forward * 10.0f);
		Vector2 screenPosition = myCam.WorldToScreenPoint (pointerPos);
		
		Ray clicker = myCam.ScreenPointToRay(screenPosition);
		if (Physics.Raycast(clicker, out hit, float.MaxValue, hitMask))
		{
			
			if (hit.collider.gameObject.name=="Restart")
			{
				if (lastHover!="Restart")
				{
					lastHover="Restart";
					timer=0f;
				}
				
				else
				{
					timer+=Time.deltaTime;
					if (timer>=3f)
					{
						Application.LoadLevel("Map");
					}
					
					else
					{
						percent=timer/3f;
						cursor.renderer.material.color=Color.Lerp(startcolor,endcolor,percent);
					}
				}
			}
			
			else if (hit.collider.gameObject.name=="Menu")
			{
				if (lastHover!="Menu")
				{
					lastHover="Menu";
					timer=0f;
				}
				
				else
				{
					timer+=Time.deltaTime;
					
					if (Time.time+timer>= Time.time+3f)
					{
						Application.LoadLevel("Startscreen");
					}
					
					else
					{
						percent=timer/3f;
						cursor.renderer.material.color=Color.Lerp(startcolor,endcolor,percent);
					}
				}
			}
			
			else if (hit.collider.gameObject.name=="Next")
			{
				if (lastHover!="Next")
				{
					lastHover="Next";
					timer=0f;
				}
				
				else
				{
					timer+=Time.deltaTime;
					
					if (Time.time+timer>= Time.time+3f)
					{
						Application.LoadLevel("Level 2");
					}
					
					else
					{
						percent=timer/3f;
						cursor.renderer.material.color=Color.Lerp(startcolor,endcolor,percent);
					}
				}
			}
			else
			{
				timer=0f;
				lastHover="";
				percent=timer/3f;
				cursor.renderer.material.color=startcolor;
			}
		}
		
		else
			cursor.renderer.material.color=startcolor;
	}
	
	
}

