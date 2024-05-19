using System.Collections;
using UnityEngine;
[DisallowMultipleComponent]
public class DestroyByTime : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;

    
    private void Start()
    {
        StartCoroutine(IEDestroy());
    }

    private IEnumerator IEDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
