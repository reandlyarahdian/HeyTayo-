using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController controller;
    [SerializeField]
    private Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.Ceil(controller.speed).ToString();
    }
}
