	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityStandardAssets.CrossPlatformInput;
	public class ball_script : MonoBehaviour {

		public Rigidbody2D rb;
		public Rigidbody2D parentRb;
		public float ballForce;
		bool isBallOnPaddle;
		public float ballWidth;

		// Use this for initialization
		void Start () {
			isBallOnPaddle = true;
		}
		
		// Update is called once per frame
		void Update () {
		if (rb.position.y < parentRb.position.y - ballWidth) {
				rb.AddForce(Vector2.zero);
				rb.MovePosition (new Vector2 (parentRb.position.x, parentRb.position.y + ballWidth));
				rb.MoveRotation (0f);
				isBallOnPaddle = true;
				rb.isKinematic = true;
			}
			if (Input.touchCount > 0) {
				foreach (Touch touch in Input.touches) {
					Vector3 touch_position = Camera.main.ScreenToWorldPoint (touch.position);
					if (touch_position.y > -3f && isBallOnPaddle) {
						Debug.DrawLine (parentRb.position, touch_position, Color.blue);
						float angleX = AngleBetweenVector2(parentRb.position, touch_position);
						rb.isKinematic = false;
						Vector2 force = new Vector2 (ballForce * Mathf.Cos ((angleX*Mathf.PI)/180f), ballForce * Mathf.Sin ((angleX*Mathf.PI)/180f));  
						rb.AddForce(force, ForceMode2D.Force);
						Debug.Log ("AngleX :"+angleX + "Force Added :" + force.ToString(), this);
						isBallOnPaddle = false;
					}
				}
			}
		}
		void OnCollisionEnter2D(Collision2D objItCollidedWith){
			if (objItCollidedWith.gameObject.tag == "Paddle") {
				Debug.Log ("Ball collided with paddle");
			}
		}
		private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
		{
			Vector2 difference = vec2 - vec1;
			float sign = (vec2.y < vec1.y)? -1.0f : 1.0f;
			return Vector2.Angle(Vector2.right, difference) * sign;
		}
	}
