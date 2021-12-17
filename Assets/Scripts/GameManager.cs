using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float[] yPos;
    public bool isPause = false;
    [SerializeField]
    private UnityEvent pauseEvent, resumeEvent;
    [SerializeField]
    private GameObject[] objects;
    public Level level;
    public static GameManager instance;
    private PlayerController player;
    private LevelManager lvManager;
    private ObjPool pool;
    private UIManager iManager;

    List<GameObject> objUsed = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        GameInstance.Instance.Setup();
        iManager = FindObjectOfType<UIManager>();
        lvManager = GetComponent<LevelManager>();
        pool = GetComponent<ObjPool>();
        player = FindObjectOfType<PlayerController>();
        iManager.controller = player;
        lvManager.player = player;
    }

    private void Start()
    {
        Leveling();
        AudioManager.Instance.PlaySound("Theme");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            Paused();
        }
    }

    void Leveling()
    {
        switch (level)
        {
            case Level.Easy:
                LevelGen(3);
                PoolingCars(5);
                break;
            case Level.Medium:
                LevelGen(5);
                PoolingCars(15);
                break;
            case Level.Hard:
                LevelGen(7);
                PoolingCars(25);
                break;
            default:
                break;
        }
    }

    void LevelGen(int index)
    {
        for(int i = 0; i < index; i++)
        {
            GameObject game = Instantiate(objects[Random.Range(0, objects.Length)],
                new Vector3(Random.Range(0, 200), -1.5f, 0),
                transform.rotation, transform);
        }
    }

    void PoolingCars(int index)
    {
        for (int i = 0; i < index; i++)
        {
            GameObject game = pool.ObjSpawn("Car", new Vector3(Random.Range(5, 250), yPos[Random.Range(0, yPos.Length)], 0), transform.rotation);
            if (game.GetComponent<CarScript>()) { game.GetComponent<CarScript>().player = player; game.GetComponent<CarScript>().pool = pool; }
            objUsed.Add(game);
        } 
    }

    void Paused()
    {
        if (isPause)
        {
            pauseEvent.Invoke();
        }
        else
        {
            resumeEvent.Invoke();
        }
    }
}

public enum Level
{
    Easy,
    Medium,
    Hard
}
