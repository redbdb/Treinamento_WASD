using UnityEngine;

public class Goomba : MonoBehaviour
{
    public MenuManager menuManager;

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
        {   if(!collision.gameObject.GetComponent<Mario>().starp){
                if(collision.transform.DotTest(transform, Vector2.down)){
                    menuManager.Pontuar(100);
                    somMorteGoomba.Play();
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6), ForceMode2D.Impulse);
                    amassar();
                }    
                else{
                    collision.gameObject.GetComponent<Mario>().TakeHit();
                }
            }else{
                Destroy(gameObject);
            }
            
               
        }
    }

    private void amassar(){
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PadraoInimigo>().enabled = false;
        GetComponent<Animated>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        spriteRenderer.sprite = goombaAmassado;
        Destroy(gameObject, 0.5f);
    }
}
