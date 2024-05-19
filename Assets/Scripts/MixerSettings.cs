using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


[DisallowMultipleComponent]
public class MixerSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerGroup soundMixer;


    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicValueFromSlider(); });
        soundSlider.onValueChanged.AddListener(delegate { ChangeSoundValueFromSlider(); });

        if (PlayerPrefs.HasKey("MusicValue"))
            musicSlider.value = ConvertToSliderFormat(PlayerPrefs.GetFloat("MusicValue"));
        else
            musicSlider.value = 0.8F;

        if (PlayerPrefs.HasKey("SoundValue"))
            soundSlider.value = ConvertToSliderFormat(PlayerPrefs.GetFloat("SoundValue"));
        else
            soundSlider.value = 0.8F;   
    }

    private float ConvertToSliderFormat(float val)
    {
        return val / 100 + 0.8f;
    }

    private float ConvertToMixerFormat(float val)
    {
        return (val - 0.8f) * 100;
    }

    private void Start()
    {
        ChangeMusicValueFromSlider();
        ChangeSoundValueFromSlider();
    }

    public void ChangeMusicValueFromSlider()
    {
        float musicValue = ConvertToMixerFormat(musicSlider.value);

        musicMixer.audioMixer.SetFloat("MVolume", musicValue);

        PlayerPrefs.SetFloat("MusicValue", musicValue);
        PlayerPrefs.Save();
    }

    public void ChangeSoundValueFromSlider()
    {
        float soundValue = ConvertToMixerFormat(soundSlider.value);

        soundMixer.audioMixer.SetFloat("SVolume", soundValue);

        PlayerPrefs.SetFloat("SoundValue", soundValue);
        PlayerPrefs.Save();
    }
}

