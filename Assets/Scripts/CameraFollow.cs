using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset;
    public Transform Target;

    void Update()//ajustes de limites faltando
    {
        Vector3 newPos = new Vector3(Target.position.x,Target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
