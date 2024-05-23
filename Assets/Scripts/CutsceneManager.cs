using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private float timeToPlayerSpawn;
    [SerializeField] private float timeBeforeCameraMove;
    [SerializeField] private float timeToCamerasMove;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerInputEnabledController playerInputController;
    [SerializeField] private GameObject[] cameras;
    [SerializeField] private GameObject[] afterCutsceneEndActivatedObjects;

    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        CutsceneMode();
        StartCoroutine(IEPlayCutscene());

    }

    private IEnumerator IEPlayCutscene()
    {
        
        yield return new WaitForSeconds(timeToPlayerSpawn);
        player.SetActive(true);
        playerInputController.DisableInput();
        yield return new WaitForSeconds(timeBeforeCameraMove);


        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].SetActive(true);
            if (i > 0)
                cameras[i-1].SetActive(false);
            yield return new WaitForSeconds(timeToCamerasMove);
        }

        _animator.SetTrigger("isEnd");
    }
    private void CutsceneMode()
    {
        for (int i = 0; i < afterCutsceneEndActivatedObjects.Length; i++)
        {
            afterCutsceneEndActivatedObjects[i].SetActive(false);
        }
        player.SetActive(false);
    }
    public void PlayMode()
    {
        for (int i = 0; i < afterCutsceneEndActivatedObjects.Length; i++)
        {
            afterCutsceneEndActivatedObjects[i].SetActive(true);
        }
        playerInputController.EnableInput();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
