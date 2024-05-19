using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[DisallowMultipleComponent]
public class AmmoVisualizator : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private GameObject reloadText;
    [SerializeField] private TMP_Text ammoText;


    private void OnEnable()
    {
        playerAttack.OnReload += Reload;
        playerAttack.OnAmmoChange += ChangeAmmo;
    }


    private void ChangeAmmo(int newAmmo)
    {
        ammoText.text = newAmmo.ToString();
    }

    private void Reload(float timeToReload)
    {
        reloadText.SetActive(true);
        StartCoroutine(IEReload(timeToReload));
    }

    private IEnumerator IEReload(float timeToReload)
    {
        yield return new WaitForSeconds(timeToReload);
        reloadText.SetActive(false);
    }
}
