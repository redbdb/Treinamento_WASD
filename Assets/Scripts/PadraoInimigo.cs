using UnityEngine;

public class PadraoInimigo : MonoBehaviour
{
    public float velocidade = 5f;
    public Vector2 direcao = Vector2.left;

    private Rigidbody2D corpo;
    private Vector2 vetorVel;

    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void Update()
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
        if(other.gameObject.CompareTag("Inimigo") || other.gameObject.CompareTag("Item"))
        {
            direcao = -direcao;
        }
    }
}
