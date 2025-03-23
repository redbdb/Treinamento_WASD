using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mario : MonoBehaviour//ajuste de limite de pulo faltando
{
    public float velocidade;
    public Rigidbody2D corpo;

    public float ForcaPulo;
    public bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
