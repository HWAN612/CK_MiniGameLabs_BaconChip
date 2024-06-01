using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatStep : MonoBehaviour
{
    private float timer;
    private float random;

    private Animator cat;

    private void Start()
    {
        cat = GetComponent<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0;
            CatUp();
        }
    }

    private void CatUp()
    {
        random = Random.Range(0, 10f);
        int step = cat.GetInteger("Step");

        if (random < 5f)
        {
            step++;
            if (step == 3) step = 0;
            cat.SetInteger("Step", step);
        }
    }
}