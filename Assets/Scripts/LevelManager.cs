using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private float[] yPos;
    [SerializeField]
    private int xMax, xMin;
    private ObjPool pool;
    [SerializeField]
    private int numberObs;
    [SerializeField]
    List<GameObject> objUsed = new List<GameObject>();

    private void Start()
    {
        pool = GetComponent<ObjPool>();
    }

    public void SpawnObj(string tag)
    {
        for(int i = 0; i < numberObs; i++)
        {
            GameObject game = pool.ObjSpawn(tag, new Vector3(Random.Range(xMin, xMax), yPos[Random.Range(0, yPos.Length + 1)], 0), transform.rotation);
            objUsed.Add(game);
        }
    }
}
