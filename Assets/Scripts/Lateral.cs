using UnityEngine;

public class Lateral : MonoBehaviour
{
    public Goomba inimigo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(){
        inimigo.velocidade = -inimigo.velocidade;
    }
}
