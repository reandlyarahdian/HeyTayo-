using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampUI : MonoBehaviour
{
    private Image image;
    public Color32[] color32;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void ChangeColor(int index)
    {
        image.color = color32[index];
    }
}
