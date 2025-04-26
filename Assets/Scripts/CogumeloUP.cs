using UnityEngine;

public class CogumeloUP : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Mario>().CogumeloUP();
            Destroy(gameObject);
        }    
    }
}
