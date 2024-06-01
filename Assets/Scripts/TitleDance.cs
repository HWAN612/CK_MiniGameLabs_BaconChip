using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TitleDance : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private float timer;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0;
            Dance();
        }
    }

    void Dance()
    {
        _sprite.flipX = !_sprite.flipX;
    }
}
