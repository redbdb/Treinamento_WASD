using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }
}
