using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMovement : MonoBehaviour
{
    public bool finished = false;
    public float speed;
    private Transform target;

    void Start() {
        target = GameObject.Find("EndBarrier").transform;
    }

    void Update() {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, target.position.z), step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f) {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }
        if (transform.position.z >= 216.42f) {
            finished = true;
        }
    }
}
