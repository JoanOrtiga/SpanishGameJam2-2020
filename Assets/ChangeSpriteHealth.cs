using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteHealth : MonoBehaviour
{
    public Sprite[] spr;

    private Image spriterender;
    private void Start()
    {
       spriterender = GetComponent<Image>();
    }

    public void ChangeSprite(int health)
    {
        spriterender.sprite = spr[health];
    }
}
