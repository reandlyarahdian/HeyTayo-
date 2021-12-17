using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 25f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x > 510f)
        {
            transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
    }
}
