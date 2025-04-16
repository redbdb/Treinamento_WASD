using UnityEngine;

public class Animated : MonoBehaviour
{
    public Sprite[] sprites;
    private int frame;

    private SpriteRenderer spriteRenderer;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    } 

    private void OnEnable(){
        InvokeRepeating(nameof(Animate), 1f/6f, 1f/6f);
    }

    private void OnDisable(){
        CancelInvoke();
    }

    private void Animate(){

        frame++;

        if(frame >= sprites.Length){
            frame = 0;
        }

        if(frame >= 0 && frame < sprites.Length){
            spriteRenderer.sprite = sprites[frame]; 
        }
    }
}