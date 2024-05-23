using UnityEngine;

public class RedirectDelitingSignal : MonoBehaviour
{
    [SerializeField] private Portal portal;

    public void RedirectDestroySignal()
    {
        portal.DestroyGameObject();
    }
    
}
