using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField]
    private Text text;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = Mathf.Ceil(controller.speed).ToString();
    }
}
