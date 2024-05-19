using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerAnimationState))]
public class PlayerAttack : MonoBehaviour
{
    public event Action<float> OnReload;
    public event Action<int> OnAmmoChange;


    [Header("Attack support objects")]
    [SerializeField] private GameObject magicAttackObject;
    [SerializeField] private GameObject weaponFireSound;
    [SerializeField] private Transform magicAttackStartPoint;
    [SerializeField] private Transform swordAttackCollisionPoint;


    [Header("Support info")]
    [SerializeField] private string damagableTag;
    [SerializeField] private LayerMask dontDamagableLayers;

    [Header("Magic attack balance settings")]
    [SerializeField] private float magicAttackSpeed;
    [SerializeField] private float magicAttackColdownTime;
    [SerializeField] private float timeToReload;
    [SerializeField] private int maxAmmoCount;


    /*
    [Header("Sword attack balance settings")]
    [SerializeField] private float swordAttackDamage;
    [SerializeField] private float swordAttackDamageDelay;
    [SerializeField] private float swordAttackColdownTime;
    [SerializeField] private float swordAttackRadius; */


    private int _currentAmmoCount;
    private PlayerAnimationState _playerAnimationState;
    private Controls _controls;
    private bool _canUseMagicAttack = true;
    private bool _canUseSwordAttack = true;
    private bool _isReloading = false;
    //private SpriteRenderer _sp;

    public void Reload()
    {
        _isReloading = true;
        OnReload?.Invoke(timeToReload);

        StartCoroutine(IEReload());
    }


    private IEnumerator IEReload()
    {
        yield return new WaitForSeconds(timeToReload);
        _currentAmmoCount = maxAmmoCount;
        _isReloading = false;
        OnAmmoChange?.Invoke(_currentAmmoCount);
    }

    private void MagicAttack()
    {


        if (_canUseMagicAttack && _currentAmmoCount > 0 && !_isReloading && Time.timeScale != 0)
        {
            StartCoroutine(IEMagicAttackColdown());
            Instantiate(weaponFireSound, transform.position, Quaternion.identity);
            //_playerAnimationState.HeroAttackMagic();

            Vector3 endPoint = CameraSingletone.GetMainCamera().ScreenToWorldPoint(_controls.Attack.AttackDirection.ReadValue<Vector2>());
            endPoint.z = 0;

            Vector3 startPoint = new Vector3(magicAttackStartPoint.transform.position.x, magicAttackStartPoint.transform.position.y);

            Vector2 shotDirection = (endPoint - startPoint).normalized;
   

            GameObject magicBullet = Instantiate(magicAttackObject, magicAttackStartPoint.position, Quaternion.Euler(0, transform.rotation.y == -1 ? 180 : 0, 0));
            magicBullet.GetComponent<Bullet>().SetFrom("Player");

            Rigidbody2D magicBulletRb = magicBullet.GetComponent<Rigidbody2D>();

            //int direction = _sp.flipX ? -1 : 1;


            //int direction = transform.rotation.y == -1 ? -1 : 1;
            magicBulletRb.velocity = shotDirection * magicAttackSpeed;
            _currentAmmoCount--;
            OnAmmoChange?.Invoke(_currentAmmoCount);
        }

        if (_currentAmmoCount == 0 && !_isReloading)
        {
            Reload();
        }
    }
    /*
    private void SwordAttack()
    {
        if (_canUseSwordAttack)
        {
            _playerAnimationState.HeroAttackSword();
            StartCoroutine(IESwordAttackColdown());
        }
            
    } */

    private IEnumerator IEMagicAttackColdown()
    {
        _canUseMagicAttack = false;
        yield return new WaitForSeconds(magicAttackColdownTime);
        _canUseMagicAttack = true;
    }

/*
    private IEnumerator IESwordAttackColdown()
    {
        _canUseSwordAttack = false;

        yield return new WaitForSeconds(swordAttackDamageDelay);
        Collider2D[] others = Physics2D.OverlapCircleAll(swordAttackCollisionPoint.position, swordAttackRadius);


        if (others.Length == 0)
            yield return null;

        print("Layers: " + others.Length);
        for (int i = 0; i < others.Length; i++)
        {
            if (others[i].gameObject.tag == damagableTag && !others[i].isTrigger && !dontDamagableLayers.Contains(others[i].gameObject.layer))
            {
                others[i].GetComponent<Health>().TakeDamage(swordAttackDamage);
                print("Damage " + swordAttackDamage);
            }
        }
    



        yield return new WaitForSeconds(swordAttackColdownTime);

        _canUseSwordAttack = true;
    }
*/
    private void Awake()
    {
        _controls = ControlsSingletone.GetControls();
        _playerAnimationState = GetComponent<PlayerAnimationState>();
        _currentAmmoCount = maxAmmoCount;
        //_sp = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        _controls.Disable();
       // _controls.Attack.Sword.performed -= context => SwordAttack();
        _controls.Attack.Magic.performed -= context => MagicAttack();
        _controls.Attack.Reload.performed -= context => Reload();
    }

    private void OnEnable()
    {
        _controls.Enable();
        //_controls.Attack.Sword.performed += context => SwordAttack();
        _controls.Attack.Magic.performed += context => MagicAttack();
        _controls.Attack.Reload.performed += context => Reload();
        OnAmmoChange?.Invoke(_currentAmmoCount);


    }


    private void OnDestroy()
    {
        StopAllCoroutines();
        ControlsSingletone.Destroy();
    }
}
