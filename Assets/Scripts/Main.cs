using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dirx = Input.GetAxis("Horizontal");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(dirx*5,rb.velocity.y);


        if(Input.GetButtonDown("Jump")){
            rb.AddForce(new Vector2(0,250));

        }
    }
}
