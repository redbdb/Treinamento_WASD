using UnityEngine;

public class Goomba : MonoBehaviour
{
    public int velocidade = 5;
    public Rigidbody2D corpo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidade = -velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        corpo.linearVelocity = new Vector2(velocidade, corpo.linearVelocity.y);
    }

}
