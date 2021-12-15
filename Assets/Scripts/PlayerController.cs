using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float[] yPos;
    [SerializeField]
    private int test; 
    [SerializeField]
    private float smoothTime;
    private Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            speed += 0.05f;
            speed = speed > 75 ? 75 : speed;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            speed -= 0.05f;
            speed = speed < 0 ? 0 : speed;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           test--;
           MoveToTrack(test);
           test = test < 0 ? 0: test;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           test++;
           MoveToTrack(test);
           test = test > yPos.Length ? yPos.Length : test;
        }

        ObjMove(speed);
    }

    Vector3 ChangeTrack(int wayPoints)
    {
        return new Vector3(transform.position.x, yPos[wayPoints], 0);
    }

    void MoveToTrack(int points)
    {
        transform.position = Vector3.MoveTowards(transform.position, ChangeTrack(points), moveSpeed);
    }

    void ObjMove(float xSpeed)
    {
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
    }
}
