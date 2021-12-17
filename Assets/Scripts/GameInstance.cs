using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : SingeltonClass<GameInstance>
{
    public LevelData level;

    public void Setup()
    {
        GameManager.instance.level = level.level;
        Time.timeScale = 1f;
    }
}
