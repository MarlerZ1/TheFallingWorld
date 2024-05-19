using UnityEngine;

[DisallowMultipleComponent]
public class EnemyStepAudio : MonoBehaviour
{
    [SerializeField] private GameObject _stepAudio;


    public void Step()
    {
       
        Instantiate(_stepAudio, transform.position, Quaternion.identity);
    }
}
