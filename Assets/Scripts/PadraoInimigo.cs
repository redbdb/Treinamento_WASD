using UnityEngine;

public class PadraoInimigo : MonoBehaviour
{//corrigir colisao com outros inimigos
    public float velocidade = 5f;
    public Vector2 direcao = Vector2.left;

    private new Rigidbody2D corpo;
    private Vector2 vetorVel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()//colocar pra ignorar outros inimigos
    { 
        vetorVel.x = direcao.x * velocidade;
        vetorVel.y += Physics.gravity.y * Time.fixedDeltaTime;

        corpo.MovePosition(corpo.position  + vetorVel * Time.fixedDeltaTime);

        if(corpo.Raycast(direcao)){
            direcao = -direcao;
        }

        if(corpo.Raycast(Vector2.down))
            vetorVel.y = Mathf.Max(vetorVel.y, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            direcao = -direcao;
        }
    }
}
