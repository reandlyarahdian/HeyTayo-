using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private float[] yPos;
    private int xMax = 500, xMin = 20;
    private ObjPool pool;
    List<GameObject> objUsed = new List<GameObject>();
    public PlayerController player;

    private void Start()
    {
        pool = GetComponent<ObjPool>();
    }

    public void SpawnObj(string tagNnum)
    {
        string[] split = tagNnum.Split(","[0]);
        string tag = split[0];
        int num = int.Parse(split[1]);
        for(int i = 0; i < num; i++)
        {
            GameObject game = pool.ObjSpawn(tag, new Vector3(Random.Range(xMin, xMax), yPos[Random.Range(0, yPos.Length)], 0), transform.rotation);
            if (game.GetComponent<ObjChecker>()) { game.GetComponent<ObjChecker>().player = player; game.GetComponent<ObjChecker>().pool = pool; }
            objUsed.Add(game);
        }
    }
}
