using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collide : MonoBehaviour
{
    [SerializeField]
    private UnityEvent @event;
    [SerializeField]
    private string ObjectTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTag))
            {
                @event.Invoke();
            }
    }
}
