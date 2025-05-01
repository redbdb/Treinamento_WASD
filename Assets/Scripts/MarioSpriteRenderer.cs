using UnityEngine;

public class MarioSpriteRenderer : MonoBehaviour
{
    public Sprite parado;
    public Animated correndo;
    public Sprite pulando;
    public Sprite drift;

    private SpriteRenderer spriteRenderer;
    private Mario movimento;
    public MenuManager menu;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movimento = GetComponentInParent<Mario>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

        private void LateUpdate()
    {
        if(menu.endgame)
            spriteRenderer.flipX = false;
        
        if(((Input.GetAxis("Horizontal") < 0 && movimento.sentido) || (Input.GetAxis("Horizontal") > 0 && !movimento.sentido)) && !menu.endgame){
            movimento.sentido = !movimento.sentido;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if((Input.GetAxis("Horizontal") < 0 && movimento.GetComponent<Rigidbody2D>().linearVelocity.x > 0f) || (Input.GetAxis("Horizontal") > 0 && movimento.GetComponent<Rigidbody2D>().linearVelocity.x < 0f))
            spriteRenderer.sprite = drift;

        if(movimento.isGrounded && menu.endgame){
            correndo.enabled = true;
            return;
        }

        correndo.enabled = movimento.correndo;

        if(!movimento.isGrounded){
            spriteRenderer.sprite = pulando;
        }
        else if (!movimento.correndo ){
            spriteRenderer.sprite = parado;
        }
    }
}
