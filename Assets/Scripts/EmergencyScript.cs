using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects = new List<GameObject>();

    public void Activated()
    {
        foreach(GameObject game in objects)
        {
            game.SetActive(true);
        }
    }
}
