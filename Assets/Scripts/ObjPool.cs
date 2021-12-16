using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    public PoolData[] obstacleObject;
    private List<GameObject> avail = new List<GameObject>();

    private void Awake()
    {
        foreach (PoolData pool in obstacleObject)
        {
            for (int i = 0; i < pool.PoolSum; i++)
            {
                GameObject game = Instantiate(pool.prefabs, transform.position, Quaternion.identity, transform);
                game.SetActive(false);
                avail.Add(game);
            }
        }
    }

    public void ObjReturn(GameObject obj)
    {
        if (!avail.Contains(obj))
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(false);
            avail.Add(obj);
        }
    }

    private GameObject ObjRequest()
    {
        GameObject obj = null;
        if (avail.Count > 0)
        {
            obj = avail[0];
            avail.Remove(obj);
        }
        return obj;
    }

    private GameObject ObjPerRequest(string tag)
    {
        GameObject obj = null;
        if(avail.Count > 0)
        {
            foreach(GameObject game in avail)
            {
                if (game.CompareTag(tag))
                {
                    obj = game;
                    avail.Remove(obj);
                    break;
                }
            }
        }
        return obj;
    }

    public GameObject ObjSpawn(string tag, Vector3 pos, Quaternion rot)
    {
        GameObject obj = ObjPerRequest(tag);
        if (obj)
        {
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
        }
        return obj;
    }
}
