using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 4f;
    public Transform Target;
    private void Update()
    {
        if(Target!=null){
        Vector3 newPosition = Target.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
    }
}