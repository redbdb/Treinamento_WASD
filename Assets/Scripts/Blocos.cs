using UnityEngine;

public class Blocos : MonoBehaviour
{   
    public int Maxhits = -1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotTest(transform, Vector2.up))
                Hit();
        }
    }

    private void Hit()
    {
        Maxhits--;
        if(Maxhits == 0){

        }
    }
}
