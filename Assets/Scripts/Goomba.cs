using UnityEngine;

public class Goomba : MonoBehaviour
{
    public MenuManager menuManager;

    public AudioSource somMorteGoomba;

    private SpriteRenderer spriteRenderer;
    public Sprite goombaAmassado;

    private Vector3 pos;

    private void Awake()
    {
        pos = GetComponent<Transform>().position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(pos.y + 0.001f < GetComponent<Transform>().position.y)
            Destroy(gameObject);//botar anim morte
        pos = GetComponent<Transform>().position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {   if(!collision.gameObject.GetComponent<Mario>().starp){
                if(collision.transform.DotTest(transform, Vector2.down)){
                    menuManager.Pontuar(100);
                    somMorteGoomba.Play();
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 12), ForceMode2D.Impulse);
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
