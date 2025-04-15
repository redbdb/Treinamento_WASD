using UnityEngine;

public class Goomba : MonoBehaviour
{
    public AudioSource somMorteMario;
    public AudioSource somMorteGoomba;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotTest(transform, Vector2.down)){
                somMorteGoomba.Play();
                //tirar hitbox
                //amassar
                //delay
                Destroy(gameObject);
            }    
            else{
                somMorteMario.Play();
                Destroy(collision.gameObject);//mario some, trocar pra logica de reiniciar fase e tduo dps
            }
               
        }
    }
}
