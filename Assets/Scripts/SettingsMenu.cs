using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public AudioMixer effectMixer;
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        effectMixer.SetFloat("effect", volume);
    }
}
