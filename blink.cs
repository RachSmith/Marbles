using UnityEngine;
using System.Collections;

public class blink : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (blinker());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator blinker()
	{
		float blinkTime=0.5f;
		float lastBlink=0.0f;

		while (true)
		{
          if (Time.time-lastBlink>=blinkTime)
			{
				gameObject.renderer.enabled= (gameObject.renderer.enabled)? false:true; 
				lastBlink=Time.time;
			}

			yield return null;
		}
	}
}
