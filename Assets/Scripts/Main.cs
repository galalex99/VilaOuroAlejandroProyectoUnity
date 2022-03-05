using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public enum Animations
    {
        Idle,
        Run,
        Jump,
        Fall
    }

    public Animations currentAnimation;        // Animación que esta sucediendo ahora mismo
    public Rigidbody2D player;
    public Animator animator;                // animator
    public SpriteRenderer spriteRenderer;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // Chamamos o método de movimiento
        movimiento();

        //obtemos as velocidades do personaje
        float y = player.velocity.y;
        float x = player.velocity.x;

        // Comprobamos que animación hay que utilizar
        if (y > 0)
        {
            TransitionTo(Animations.Jump, "Player_jump");
        }
        else if (y < 0)
        {
            TransitionTo(Animations.Fall, "Player_fall");
        }
        else if (x != 0)
        {
            TransitionTo(Animations.Run, "Player_run");
            if (x > 0) {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            TransitionTo(Animations.Idle, "Player_iddle");
        }






    }


    void movimiento()
    {
        // Comprobamos que quiere hacer el usuario
        float dirx = Input.GetAxis("Horizontal");


        player.velocity = new Vector2(dirx * 5, player.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            player.AddForce(new Vector2(0, 250));

        }
    }



    // metodo para llamar a la animación que queremos usar
    void TransitionTo(Animations anim, string name)
    {
        // Comprobamos se a animación a que se quere pasar e a que xa esta correndo
        if (currentAnimation != anim)
        {
            animator.Play(name);
            currentAnimation = anim;
        }
    }



}
