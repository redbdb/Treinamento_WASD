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

    /*private void LateUpdate()//mudanças futuras 
    {
        if(movimento.pulando){
            spriteRenderer.sprite = pulando;
        }else if(movimento.drift){
            spriteRenderer.sprite = drift;
        }else if(movimento.correndo){
            spriteRenderer = correndo;
        }else{
            spriteRenderer = parado;
        }
    }*/
}
