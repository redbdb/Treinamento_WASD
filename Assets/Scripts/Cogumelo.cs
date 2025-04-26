using UnityEngine;

public class Cogumelo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Mario>().Grow();
            Destroy(gameObject);
        }    
    }
}
