using UnityEngine;

public class FollowGameobject : MonoBehaviour
{
    [SerializeField] private Transform obj;
    [SerializeField] private float offset;
    private void FixedUpdate()
    {
        if (obj != null)
            transform.position = new Vector3(obj.position.x, obj.position.y + offset, transform.position.z);
    }
}
