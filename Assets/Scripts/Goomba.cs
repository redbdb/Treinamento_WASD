using UnityEngine;

public class Goomba : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotTest(transform, Vector2.down)){//adicionar sprite de morte e delay pra sumir, tem que ter certeza q hitbox dele nao vai matar quando tiver amassado
                Destroy(gameObject);
            }    
            else
                Destroy(collision.gameObject);//mario some, trocar pra logica de reiniciar fase e tduo dps
        }
    }
}
