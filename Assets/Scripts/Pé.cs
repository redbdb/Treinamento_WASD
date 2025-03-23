using UnityEngine;

public class Pé : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Mario player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            player.isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            player.isGrounded = false;
    }
}
