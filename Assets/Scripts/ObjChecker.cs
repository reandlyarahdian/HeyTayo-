using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjChecker : MonoBehaviour
{
    public PlayerController player;
    public ObjPool pool;

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x - player.transform.position.x) < -10f)
        {
            pool.ObjReturn(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
