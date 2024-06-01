using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RatMove : MonoBehaviour
{
    private Animator baconAnim;
    private bool cover;
    

    public GameObject myBacon;
    public GameObject GameOverUI;
    public GameObject GameClearUI;
    public TMP_Text recordText;
    
    public float speed;
    public bool detectCat;
    private float record;
    
    private void Start()
    {
        baconAnim = myBacon.GetComponent<Animator>();
    }

    private void Update()
    {
        record += Time.deltaTime;
        Move();
        BaconCover();
        DetectToCat();
    }

    void Move()
    {
        if (baconAnim.GetBool("isCover")) return;
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void BaconCover()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            baconAnim.SetBool("isCover", !baconAnim.GetBool("isCover"));
        }
    }

    void DetectToCat()
    {
        if(baconAnim.GetBool("isCover")) return;
        if (detectCat)
        {
            GameOverUI.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cat")
        {
            detectCat = true;
        }
        
        if (other.gameObject.tag == "Cheese")
        {
            GameClearUI.SetActive(true);
            recordText.text = $"Your Record : {record}";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cat")
        {
            detectCat = false;
        }
    }
    
}
