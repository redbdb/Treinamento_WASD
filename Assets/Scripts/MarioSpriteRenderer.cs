using UnityEngine;

public class MarioSpriteRenderer : MonoBehaviour
{
    public Sprite parado;
    public Animated correndo;
    public Sprite pulando;
    public Sprite drift;

    private SpriteRenderer spriteRenderer;
    private Mario movimento;

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
        if((Input.GetAxis("Horizontal") < 0 && movimento.sentido) || (Input.GetAxis("Horizontal") > 0 && !movimento.sentido)){
            movimento.sentido = !movimento.sentido;
            spriteRenderer.flipX = !spriteRenderer.flipX;
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
