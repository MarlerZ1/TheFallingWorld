using UnityEngine;
using UnityEngine.SceneManagement;


[DisallowMultipleComponent]
public class Menu : MonoBehaviour
{
    [Header("Pause Activate Sound")]
    [SerializeField] private AudioSource audioSource;


    [Header("Event`s OnPause")]
    [SerializeField] GameObject[] onPauseActivateElements;
    [SerializeField] GameObject[] onPauseDeactivateElements;

    [Header("Event`s OnPlay")]
    [SerializeField] GameObject[] onPlayActivateElements;
    [SerializeField] GameObject[] onPlayDeactivateElements;

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void ChangePauseState()
    {
        if (audioSource)
            audioSource.Play();

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            for (int i = 0; i < onPlayDeactivateElements.Length; i++)
            {
                onPlayDeactivateElements[i].SetActive(false);
            }

            for (int i = 0; i < onPlayActivateElements.Length; i++)
            {
                onPlayActivateElements[i].SetActive(true);
            }


        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

            for (int i = 0; i < onPauseDeactivateElements.Length; i++)
            {
                onPauseDeactivateElements[i].SetActive(false);
            }

            for (int i = 0; i < onPauseActivateElements.Length; i++)
            {
                onPauseActivateElements[i].SetActive(true);
            }
        }
    }



    public void LoadMainMenu()
    {
        LoadLvl(0);
    }

    public void ReloadCurrentLvl() 
    {
        LoadLvl(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLvl()
    {
        LoadLvl(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public bool LoadNextLvlBool()
    {
        return LoadLvl(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public bool CanLoadNextLvl()
    {
        return CanLoadLvl(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public bool CanLoadLvl(int lvlNumber)
    {
        if (lvlNumber > SceneManager.sceneCount)
            return false;
        return true;
    }

    public bool LoadLvl(int lvlNumber)
    {
        if (!CanLoadLvl(lvlNumber))
            return false;

        SceneManager.LoadScene(lvlNumber);
        Time.timeScale= 1;
        return true;
    }
}
