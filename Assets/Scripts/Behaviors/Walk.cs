using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehavior {

    public float speed = 5f;
    public float runMultiplier = 2f;
    public bool running;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        running = false;

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);

        if (right || left) {
            var tmpSpeeed = speed;

            if (run && runMultiplier > 0) {
                tmpSpeeed *= runMultiplier;
                running = true;
            }

            var velX = tmpSpeeed * (float)inputState.direction;

            body2D.velocity = new Vector2(velX, body2D.velocity.y);
        }
    }
}
