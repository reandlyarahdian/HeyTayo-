using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjChecker : MonoBehaviour
{
    private PlayerController player;
    private ObjPool pool;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        pool = FindObjectOfType<ObjPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x - player.transform.position.x) < -7f)
        {
            pool.ObjReturn(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
