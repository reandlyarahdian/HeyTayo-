using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text WLText;
    private SignUI sign;
    [SerializeField]
    private List<LampUI> lamps = new List<LampUI>();
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private Color32[] color32s;
    [SerializeField]
    private GameObject WL, Menu;
    void Start()
    {
        sign = GetComponentInChildren<SignUI>();
        foreach(LampUI lamp in GetComponentsInChildren<LampUI>())
        {
            lamp.color32 = color32s;
            lamps.Add(lamp);
        }
        sign.signSprites = sprites;
    }

    void Update()
    {
        text.text = Mathf.Ceil(controller.speed).ToString();
    }

    public void RedAndGreen(bool isRed)
    {
        if (isRed)
        {
            lamps[0].ChangeColor(1);
            lamps[lamps.Count -1].ChangeColor(0);
        }
        else
        {
            lamps[0].ChangeColor(color32s.Length - 1);
            lamps[lamps.Count -1].ChangeColor(1);
        }
    }
    public void WinLose(string desc)
    {
        WLText.text = desc;
    }

    public void MenuActive(bool test)
    {
        Menu.SetActive(test);
    }

    public void WLActive(bool test)
    {
        WL.SetActive(test);
    }

    public void Scale(int i)
    {
        Time.timeScale = i;
    }

    public void ButtonPrefs(int index)
    {
        SceneManager.LoadScene(index);
    }
}
