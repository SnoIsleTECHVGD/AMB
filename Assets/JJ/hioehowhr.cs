using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hioehowhr : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;

    private SpriteRenderer spriteRenderer;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
            FlipSprite();
        }
    }

    // Function to flip the sprite based on the movement direction
    void FlipSprite()
    {
        if (transform.position.x < lastPosition.x)
        {
            // Moving left, flip the sprite
            spriteRenderer.flipX = true;
        }
        else
        {
            // Moving right, reset the sprite to its original orientation
            spriteRenderer.flipX = false;
        }

        // Update the last position
        lastPosition = transform.position;
    }
}
