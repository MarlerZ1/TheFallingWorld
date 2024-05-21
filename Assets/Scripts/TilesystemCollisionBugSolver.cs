using UnityEngine;


[DisallowMultipleComponent]
public class TilesystemCollisionBugSolver : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Collision");
        Destroy(collision.gameObject);
    }
}
