using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public PlayerController player;
    private float speed = 15f;
    public ObjPool pool;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if((transform.position.x - player.transform.position.x) < 5f)
        {
            speed = 7.5f;
        }
        else
        {
            speed = 15f;
        }

        if(transform.position.x > 510f)
        {
            pool.ObjReturn(this.gameObject);
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
    }
}
