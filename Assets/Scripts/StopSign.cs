using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopSign : MonoBehaviour
{
    private float timer = 10f;
    [SerializeField]
    private UnityEvent[] TrafficLight;

    private void Start()
    {
        StartCoroutine(RedLight(timer));
    }

    IEnumerator RedLight(float timer)
    {
        while (true)
        {
            for(int i = 0; i < TrafficLight.Length; i++)
            {
                TrafficLight[i].Invoke();
                yield return new WaitForSeconds(timer);
            }
        }
    }
}
