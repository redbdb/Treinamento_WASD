using UnityEngine;

public class Goomba : MonoBehaviour
{
    public AudioSource somMorteMario;
    public AudioSource somMorteGoomba;

    private SpriteRenderer spriteRenderer;
    public Sprite goombaAmassado;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotTest(transform, Vector2.down)){
                somMorteGoomba.Play();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6), ForceMode2D.Impulse);
                amassar();
            }    
            else{
                somMorteMario.Play();
                Destroy(collision.gameObject);//mario some, trocar pra logica de reiniciar fase e tduo dps
            }
               
        }
    }

    private void amassar(){
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PadraoInimigo>().enabled = false;
        spriteRenderer.sprite = goombaAmassado;
        Destroy(gameObject, 0.5f);
    }
}
