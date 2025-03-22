using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mario : MonoBehaviour//ajuste de limite de pulo faltando
{
    public float velocidade;
    public float ForcaPulo;
    public Rigidbody2D corpo;

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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * velocidade;
    }

    void Pular()
    {
        if(Input.GetButtonDown("Jump"))
            corpo.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
    }
}
