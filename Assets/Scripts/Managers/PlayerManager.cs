using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private InputState inputState;
    private Walk walkBehaviour;
    private Animator animator;
    private CollisionState collisionState;
    private Duck duckBehaviour;

    private void Awake()
    {
        inputState = GetComponent<InputState>();
        walkBehaviour = GetComponent<Walk>();
        animator = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
        duckBehaviour = GetComponent<Duck>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (collisionState.standing) {
            ChangeAnimationState(0);
        }
        if (inputState.absVelX > 0){
            ChangeAnimationState(1);
        }
        if (inputState.absVelY > 0) {
            ChangeAnimationState(2);
        }

        animator.speed = walkBehaviour.running ? walkBehaviour.runMultiplier : 1;

        if (duckBehaviour.ducking){
            ChangeAnimationState(3);
        }
    }

    void ChangeAnimationState(int value) {
        animator.SetInteger("AnimState", value);
    }
}
