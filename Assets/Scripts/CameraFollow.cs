using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset;
    public Transform Target;

    public Transform mastro;

    void Awake()//verificar logica do y
    {
        yOffset = Target.position.y + yOffset;
    }

    void Update()
    {   
        Vector3 newPos = new Vector3( Mathf.Min(Mathf.Max(Target.position.x, transform.position.x), mastro.position.x), Mathf.Max(Target.position.y, yOffset), -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
