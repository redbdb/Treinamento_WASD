using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mario : MonoBehaviour
{
    public float velocidade;
    public Rigidbody2D corpo;

    public float ForcaPulo;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = corpo.Raycast(Vector2.down);
        Mover();
        Pular();
    }

    void Mover()
    {
        corpo.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, corpo.linearVelocity.y);
    }

    void Pular()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
            corpo.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
    }

}
