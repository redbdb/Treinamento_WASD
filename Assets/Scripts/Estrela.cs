using UnityEngine;

public class Estrela : MonoBehaviour
{
    public AudioSource som;

    public float velocidade = 5f;
    private Vector2 direcao = Vector2.right;

    private Rigidbody2D corpo;
    private Vector2 vetorVel;
    private bool isGrounded;

    void Start()
    {
        som.Play();
        corpo = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        isGrounded = corpo.Raycast(Vector2.down);

        vetorVel.x = direcao.x * velocidade;
        vetorVel.y += (Physics.gravity.y * Time.fixedDeltaTime)/2;

        

        if(isGrounded)
            vetorVel.y = 7f;

        corpo.linearVelocity = new Vector2(vetorVel.x, vetorVel.y);

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Mario>().Starpower();
            Destroy(gameObject);
        }    
    }
}
