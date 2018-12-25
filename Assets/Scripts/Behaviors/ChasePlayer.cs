using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    public float speed = 4f;
    public float stopDistance = 10f;
    public GameObject target;
    public float currentDirection = -1f;

    void Update()
    {
        // Get Left Or Right
        float direction = GetDirection(transform.position.x, target.transform.position.x);
        float newX = target.transform.position.x + (direction * stopDistance);

        Debug.DrawLine(transform.position, target.transform.position, Color.green);

        if (Vector2.Distance(transform.position, target.transform.position) > stopDistance) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y), speed * Time.deltaTime);

            if (direction != 0 && currentDirection != direction) {
                Flip(direction);
            }
        }
    }

    // Flip Sprite
    void Flip(float direction) {
        Vector3 scale = transform.localScale;
        scale.x = direction;
        transform.localScale = scale;

        currentDirection = direction;
    }

    // If Left or Right
    public float GetDirection(float currentX, float targetX){
        // Left
        if (targetX < currentX){
            return 1f;
        }
        // Right
        else if (targetX > currentX){
            return -1f;
        }
        else {
            return 0f;
        }
    }

}
