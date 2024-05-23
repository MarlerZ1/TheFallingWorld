using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerMoving))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerInputEnabledController : MonoBehaviour
{
    private PlayerMoving _playerMoving;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerMoving = GetComponent<PlayerMoving>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    public void DisableInput()
    {
        _playerMoving.enabled = false;
        _playerAttack.enabled = false;
    }

    public void EnableInput()
    {
        _playerMoving.enabled = true;
        _playerAttack.enabled = true;
    }
}
 