using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Button play, back;
    [SerializeField]
    GameObject levelMenu;
    [SerializeField]
    LevelData[] levelDatas; 

    public void onPlayClick()
    {
        levelMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(back.gameObject);
    }

    public void onBackClick()
    {
        levelMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(play.gameObject);
    }

    public void onExitClick()
    {
        Application.Quit();
    }

    public void onLevelSelect(int index)
    {
        GameInstance.Instance.level = levelDatas[index];
        SceneManager.LoadScene(1);
    }
}
