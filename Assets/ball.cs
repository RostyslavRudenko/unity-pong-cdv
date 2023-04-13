using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball : MonoBehaviour
{
    public int leftPlayerScore = 0;
    public int rightPlayerScore = 0;
    public Rigidbody2D rb2D;
    public float speed = 1f;
    public Vector2 vel;
    public TextMeshProUGUI leftPlayerText;
    public TextMeshProUGUI rightPlayerText;

    // Start is called before the first frame update
    void Start()
    {
        leftPlayerText.text = "0";
        rightPlayerText.text = "0";
        rb2D = GetComponent<Rigidbody2D>();
        resetBall();
    }
    private void Update()
    {
        if (rb2D.velocity.magnitude < .1f && Input.GetKeyUp(KeyCode.Space))
        {
            sendBAllToTheRandomDirection();
        }
    }
    private void resetBall()
    {
        rb2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    private void sendBAllToTheRandomDirection() {
        rb2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
        vel = rb2D.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector2.Reflect(vel, collision.contacts[0].normal);
        vel = rb2D.velocity;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x < 0)
        {
            Debug.Log("+1 point for blue");
            rightPlayerScore +=1;
        }
        else {
            Debug.Log("+1 point for red");
            leftPlayerScore += 1;
        }
        leftPlayerText.text = leftPlayerScore.ToString();
        rightPlayerText.text = rightPlayerScore.ToString();
        resetBall();
      //  sendBAllToTheRandomDirection();
    }
}