using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator; 
    private bool puedoSaltar = false;

    //PUNTAJE
    public Text scoreBronze;
    public Text scoreSilver;
    public Text scoreGold;

    private int scoreBronzes = 0;
    private int scoreSilvers = 0;
    private int scoreGolds = 0;
    void Start()
    {
      sr = GetComponent<SpriteRenderer>();
      rb2d = GetComponent<Rigidbody2D>(); 
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        SetIdleAnimation();
        scoreBronze.text = "Moneda Tipo_1: " + scoreBronzes;
        scoreSilver.text = "Moneda Tipo_2: " + scoreSilvers;
        scoreGold.text = "Moneda Tipo_3: " + scoreGolds;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            SetRunAnimation();
            rb2d.velocity = new Vector2(10, rb2d.velocity.y);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            SetRunAnimation();
            rb2d.velocity = new Vector2(-10, rb2d.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && puedoSaltar)
        {
            var jump = 80f;
            SetJumpAnimation();
            rb2d.velocity = Vector2.up * jump;
            puedoSaltar = false;
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        puedoSaltar = true;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Bronze")
        {
            incremetarPuntajeBronze();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Silver")
        {
            incremetarPuntajeSilver();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Gold")
        {
            incremetarPuntajeGold();
            Destroy(other.gameObject);
        }
    }

    private void SetIdleAnimation()
    {
        animator.SetInteger("Estado",0);

    }
    private void SetRunAnimation()
    {
        animator.SetInteger("Estado",1);

    }
    private void SetJumpAnimation()
    {
        animator.SetInteger("Estado",2);

    }
    public void incremetarPuntajeBronze()
    {
        scoreBronzes += 10;
    }
    public void incremetarPuntajeSilver()
    {
        scoreSilvers += 20;
    }
    public void incremetarPuntajeGold()
    {
        scoreGolds += 30;
    }
   
}
