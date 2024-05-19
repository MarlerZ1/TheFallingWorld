using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private float timeToLive;

    private static DontDestroyOnLoad _instance;

    private void Start()
    {
        if (_instance != null)
        {
            StartCoroutine(IEDestroy());
        }
        else
        {
            _instance = this;
        } 

        DontDestroyOnLoad(this.gameObject);
    }

    private IEnumerator IEDestroy()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(_instance.gameObject);
        _instance = this;
    }
   

}
