using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mario : MonoBehaviour
{
    public float velocidade;
    public Rigidbody2D corpo;

    public float ForcaPulo;
    public bool isGrounded;

    public bool correndo;
    public bool sentido;

    public AudioSource somPuloPequeno;
    public AudioSource somPuloGrande;

    void Update()
    {
        isGrounded = corpo.Raycast(Vector2.down);

        if(Mathf.Abs(corpo.linearVelocity.x) > 0.25f)
            correndo = true;
        else
            correndo = false;

        Mover();
        Pular();
    }

    void Mover()
    {
        corpo.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, corpo.linearVelocity.y);
    }

    void Pular()
    {
        if(Input.GetButtonDown("Jump") && isGrounded){//verificar se esta grande ou nao pra tocar o som
            somPuloPequeno.Play();
            corpo.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
        }
            
            
    }

}
