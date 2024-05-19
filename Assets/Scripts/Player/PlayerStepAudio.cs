using UnityEngine;


[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class StepAudio : MonoBehaviour
{
    [SerializeField] private GameObject _stepAudio;

    private PlayerMoving _playerMoving;

    private void Awake()
    {
        _playerMoving = GetComponent<PlayerMoving>();
    }

    public void Step()
    {
        if (_playerMoving.GetIsGrounded())
            Instantiate(_stepAudio, transform.position, Quaternion.identity);
    }
}
