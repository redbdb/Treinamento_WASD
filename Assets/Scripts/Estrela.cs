using UnityEngine;

public class Estrela : MonoBehaviour
{
    public AudioSource som;

    void Start()
    {
        som.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Mario>().Starpower();
            Destroy(gameObject);
        }    
    }
}
