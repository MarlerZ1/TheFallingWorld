using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class MainMenuAnimationState : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>(); 
    }

    public void OpenSettings()
    {
        _animator.SetBool("StartMovingToEngle", true);
        _animator.SetBool("StartMovingFromEngle", false);
    }

    public void CloseSettings()
    {
        _animator.SetBool("StartMovingToEngle", false);
        _animator.SetBool("StartMovingFromEngle", true);
    }

}
