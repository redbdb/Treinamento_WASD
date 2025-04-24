using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite conchaSprite;
    private bool encolhido = false;
    private bool movendo = false;

    public AudioSource somChute;
    public AudioSource somMorteMario;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!encolhido && collision.gameObject.CompareTag("Player"))
        {
            
            if(collision.transform.DotTest(transform, Vector2.down)){
                somChute.Play();
                Concha();
            }
            else{
                somMorteMario.Play();
                Destroy(collision.gameObject);//mario morre, trocar pra logica de reiniciar fase e tduo dps
            }
                
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(movendo && other.gameObject.CompareTag("Inimigo"))
            Destroy(other.gameObject);//casco do koopa mata inimigo
        else if(encolhido && other.gameObject.CompareTag("Player")){
            if(movendo){
                somChute.Play();
                Destroy(other.gameObject);
            }else{
                Vector2 direcao = new Vector2(transform.position.x - other.transform.position.x, 0f);
                Empurra(direcao);
                somChute.Play();
            }
        }
    }

    private void Concha()
    {
        GetComponent<Animated>().enabled = false;
        GetComponent<PadraoInimigo>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = conchaSprite;
        encolhido = true;
    }

    private void Empurra(Vector2 direcao)
    {
        movendo = true;

        GetComponent<Rigidbody2D>().isKinematic = false;
        PadraoInimigo movimento = GetComponent<PadraoInimigo>();
        movimento.direcao = direcao.normalized;
        movimento.velocidade = 12f;
        movimento.enabled = true;
    }
}
