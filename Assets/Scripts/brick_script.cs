using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_script : MonoBehaviour {

	public Rigidbody2D rb;
	public bool isCollision = false;
	public GameObject ui;

	// Use this for initialization
	void Start () {
		ui = GameObject.FindWithTag("UiManager");
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnCollisionEnter2D(Collision2D objItCollidedWith){
		if (objItCollidedWith.gameObject.tag == "Ball") {
			Destroy (gameObject);
			ui.GetComponent<ui_manager_script>().increment_score();
		}
	}
}
