using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float[] yPos;
    [SerializeField]
    private bool isPause = false;
    [SerializeField]
    private UnityEvent pauseEvent, resumeEvent;
    public PoolData[] datas;
    public int carNum;
    private PlayerController player;
    private LevelManager level;
    private ObjPool pool;
    private UIManager iManager;

    List<GameObject> objUsed = new List<GameObject>();

    private void Awake()
    {
        iManager = FindObjectOfType<UIManager>();
        level = GetComponent<LevelManager>();
        pool = GetComponent<ObjPool>();
        player = FindObjectOfType<PlayerController>();
        iManager.controller = player;
        level.player = player;
        pool.obstacleObject = datas;
    }

    private void Start()
    {
        PoolingCars();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            Paused();
        }
    }

    void PoolingCars()
    {
        for (int i = 0; i < carNum; i++)
        {
            GameObject game = pool.ObjSpawn("Car", new Vector3(Random.Range(0, 250), yPos[Random.Range(0, yPos.Length)], 0), transform.rotation);
            if (game.GetComponent<CarScript>()) { game.GetComponent<CarScript>().player = player; game.GetComponent<CarScript>().pool = pool; }
            objUsed.Add(game);
        } 
    }
    void Paused()
    {
        if (isPause)
        {
            Time.timeScale = 0;
            pauseEvent.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            resumeEvent.Invoke();
        }
    }
}
