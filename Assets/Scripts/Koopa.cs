using UnityEngine;

public class Koopa : MonoBehaviour
{
    public MenuManager menuManager;

    public Sprite conchaSprite;
    private bool encolhido = false;
    private bool movendo = false;

    public AudioSource somChute;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!encolhido && collision.gameObject.CompareTag("Player"))
        {
            if(!collision.gameObject.GetComponent<Mario>().starp){
                if(collision.transform.DotTest(transform, Vector2.down)){
                    menuManager.Pontuar(500);
                    somChute.Play();
                    Concha();
                }
                else{
                    collision.gameObject.GetComponent<Mario>().TakeHit();
                }   
            }else{
                Destroy(gameObject);
            }            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(movendo && other.gameObject.CompareTag("Inimigo"))
            Destroy(other.gameObject);
        else if(encolhido && other.gameObject.CompareTag("Player")){
            if(!other.gameObject.GetComponent<Mario>().starp){
                if(movendo){
                    somChute.Play();
                    Destroy(other.gameObject);
                }else{
                    menuManager.Pontuar(400);
                    Vector2 direcao = new Vector2(transform.position.x - other.transform.position.x, 0f);
                    Empurra(direcao);
                    somChute.Play();
                }
            }else{
                Destroy(gameObject);
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
