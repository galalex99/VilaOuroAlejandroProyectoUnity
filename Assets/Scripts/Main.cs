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
    // Animación que esta sucedendo ahora mismo
    private Animations currentAnimation;
    //rigid body do xogador
    private Rigidbody2D player;
    // animator
    private Animator animator;               
    // spriter renderer do xogador
    private SpriteRenderer spriteRenderer;
    // Capa na que comprobara o raycast
    public LayerMask groundLayer;
    //Audio 
    public AudioSource AUS_salto;
    public AudioSource AUS_saltoDoble;

    float fuerzaSalto = 330f;
    bool salto=true, saltoDoble=true;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AUS_salto=GetComponents<AudioSource>()[0];
        AUS_saltoDoble = GetComponents<AudioSource>()[1];
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
        if (y > 0.5)
        {
            TransitionTo(Animations.Jump, "Player_jump");
        }
        else if (y < -0.5)
        {
            TransitionTo(Animations.Fall, "Player_fall");
        }
        else if (x != 0)
        {
            TransitionTo(Animations.Run, "Player_run");
            if (x > 0)
            {
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
        // movimiento lateral
        player.velocity = new Vector2(dirx * 5, player.velocity.y);


        //Comprobamos si esta no suelto
        if (IsGrounded())
        {
            salto = true;
            saltoDoble = true;
        }
        // se pulsa o boton e ten o salto dispoñible saltamos 
        if (Input.GetButtonDown("Jump"))
        {           
            if (salto)
            {
                salto = false;
                player.AddForce(new Vector2(0f, fuerzaSalto));
                AUS_salto.Play();
            }
            else if (saltoDoble)
            {
                saltoDoble = false;
                player.AddForce(new Vector2(0f, fuerzaSalto * 0.7f));
                AUS_saltoDoble.Play();
               

            }

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



    bool IsGrounded()
    {
        // posicion actual do personaje
        Vector2 position = transform.position;
        // Direccion hacia a que comproba raycast
        Vector2 direction = Vector2.down;
        // distancia a que comproba raycast
        float distance = 0.9f;


        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
