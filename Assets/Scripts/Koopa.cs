using System.Collections;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    public MenuManager menuManager;
    private Rigidbody2D rb;

    public Sprite conchaSprite;
    private bool encolhido = false;
    private bool movendo = false;

    public AudioSource somChute;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!encolhido && collision.gameObject.CompareTag("Player"))
        {
            if(!collision.gameObject.GetComponent<Mario>().starp){
                if(collision.transform.DotTest(transform, Vector2.down)){
                    menuManager.Pontuar(500);
                    somChute.Play();
                    Concha();
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                }
                else{
                    collision.gameObject.GetComponent<Mario>().TakeHit();
                }   
            }else{
                GetComponent<PadraoInimigo>().enabled = false;
                StartCoroutine(Morte());
            }            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if(movendo && other.gameObject.CompareTag("Inimigo")){
            StartCoroutine(other.GetComponent<Goomba>().Morte());
            other.GetComponent<Goomba>().enabled = false;
            other.GetComponent<PadraoInimigo>().enabled = false;
        }
            
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
                GetComponent<PadraoInimigo>().enabled = false;
                StartCoroutine(Morte());
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

    private IEnumerator Morte()
    {
        menuManager.Pontuar(200);
        somChute.Play();

        this.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PadraoInimigo>().enabled = false;
        GetComponent<Animated>().enabled = false;
        GetComponent<SpriteRenderer>().flipY = true;

        float feito = 0f;
        float duracao = 3f;

        float alturaPulo = 5f;
        float gravidade = -30f;

        Vector3 altura = Vector3.up * alturaPulo;
        altura.x = 2f;

        while (feito < duracao)
        {
            transform.position += altura * Time.deltaTime;
            altura.y += gravidade * Time.deltaTime;
            feito += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
