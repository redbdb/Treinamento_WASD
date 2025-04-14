using UnityEngine;

public class MarioSpriteRenderer : MonoBehaviour
{
    public Sprite parado;
    public Sprite correndo;
    public Sprite pulando;
    public Sprite drift;

    private SpriteRenderer spriteRenderer;
    private Mario movimento;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movimento = GetComponentInParent<Mario>();
    }

        private void LateUpdate()
    {
        if(!movimento.isGrounded){
            spriteRenderer.sprite = pulando;
        }/*else if(movimento.drift){
            spriteRenderer.sprite = drift;
        }*/else if(movimento.correndo){//finalizar animaçõa de corrida
            spriteRenderer.sprite = correndo;
        }else{
            spriteRenderer.sprite = parado;
        }
    }
}
