using UnityEngine;

public class Goomba : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotTest(transform, Vector2.down))
                Destroy(gameObject);
            else
                Destroy(collision.gameObject);//mario morre, trocar pra logica de reiniciar fase e tduo dps
        }
    }
}
