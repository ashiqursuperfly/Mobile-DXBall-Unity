using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ui_manager_script : MonoBehaviour
{
    // Start is called before the first frame update
	int score = 0;
	public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void increment_score(){
		score++;
		scoreText.text = "Score: " + score;
	}
}
