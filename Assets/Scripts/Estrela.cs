using UnityEngine;

public class Estrela : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Mario>().Starpower();
            Destroy(gameObject);
        }    
    }
}
