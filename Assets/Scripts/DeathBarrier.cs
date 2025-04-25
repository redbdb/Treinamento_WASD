using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<Mario>().Dies();
        else
            Destroy(other.gameObject);
    }
}
