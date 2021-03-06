﻿using System.Collections;
using UnityEngine;

public abstract class AbstractBehavior : MonoBehaviour {

    public Buttons[] inputButtons;
    public MonoBehaviour[] disableScripts;

    protected InputState inputState;
    protected Rigidbody2D body2D;
    protected CollisionState collisionState;

    protected virtual void Awake() {
        inputState = GetComponent<InputState>();
        body2D = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    protected virtual void ToggleScripts(bool value) {
        foreach (var script in disableScripts) {
            script.enabled = value;
        }
    }
}
