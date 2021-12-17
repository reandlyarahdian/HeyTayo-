using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent @event;
    [SerializeField]
    private string ObjectTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTag))
        {
            StartCoroutine(waitToActive());
        }
    }

    IEnumerator waitToActive()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        @event.Invoke();
    }
}
