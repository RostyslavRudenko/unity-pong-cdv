using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQ : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color color;
    public Rigidbody2D RigidBody2D;
    public KeyCode upKey;
    public KeyCode downKey;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(upKey) && transform.position.y < 5)
        {
            RigidBody2D.velocity = Vector2.up * speed; 
        }
        else if (Input.GetKey(downKey) && transform.position.y > - 5)
        {
            RigidBody2D.velocity = Vector2.down * speed;
        }

        else
        {
            RigidBody2D.velocity = Vector2.zero;
        }

    }
}

