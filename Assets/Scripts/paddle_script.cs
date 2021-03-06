using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class paddle_script : MonoBehaviour { 

	public Rigidbody2D rb;
	public float SPEED; 
	public float MAX_X;

	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				Vector3 touch_position = Camera.main.ScreenToWorldPoint (touch.position);
				if (touch_position.y < -3) {  // we are using the bottom length*3 area of the screen as the slider touch input area.
					if (touch_position.x > 0)
						move (1);
					else if (touch_position.x < 0)
						move (-1);
					else if (touch_position.x == 0)
						move (0);
				}	
			}
		}else move (0);
		constrain ();
	}

	void constrain(){
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x, -MAX_X, MAX_X);
		transform.position = pos;
	}


	void move(float xDir){
		if (xDir > 0) 
			rb.velocity = new Vector2(SPEED * Time.deltaTime, 0f);
		if (xDir < 0)
			rb.velocity = new Vector2(-SPEED * Time.deltaTime, 0f);
		if (xDir == 0)
			rb.velocity = new Vector2(0,0);
	}
		

}
