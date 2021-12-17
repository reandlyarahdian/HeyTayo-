using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUI : MonoBehaviour
{
    private Image image;
    public Sprite[] signSprites;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void ChangeSprites(int index)
    {
        image.sprite = signSprites[index];
    }
}
