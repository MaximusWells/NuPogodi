using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {

    public static AudioController instance;
    private Toggle toggleMusicButton;
    private Toggle toggleSoundButton;

    public Scene thisScene;

    void Awake()
    {
//       Instancenate();
        thisScene = SceneManager.GetActiveScene();
        toggleMusicButton = gameObject.GetComponent<Toggle>();
    }

    void Start ()
    {
        toggleMusicButton.onValueChanged.AddListener(delegate { ToggleMusic(); });
        toggleMusicButton.isOn = GameManager.instance.musicMuted;
        GameManager.instance.musicSource.mute = toggleMusicButton.isOn;
        //
/*       toggleSoundButton.onValueChanged.AddListener(delegate { ToggleSound(); });
        toggleSoundButton.isOn = GameManager.instance.soundMuted;
        GameManager.instance.soundSource.mute = toggleSoundButton.isOn;
    }

    public void ToggleSound()
    {
        if (GameManager.instance.soundMuted == true)
        {
            GameManager.instance.soundSource.mute = false;
            GameManager.instance.soundMuted = false;
            toggleSoundButton.isOn = GameManager.instance.soundMuted;
        }
        else
        {
            GameManager.instance.soundSource.mute = true;
            GameManager.instance.soundMuted = true;
            toggleSoundButton.isOn = GameManager.instance.soundMuted;
        }
*/
    }


    public void ToggleMusic ()
    {
        if (GameManager.instance.musicMuted == true)
        {
            GameManager.instance.musicSource.mute = false;
            GameManager.instance.musicMuted = false;
            toggleMusicButton.isOn = GameManager.instance.musicMuted;
        }
        else
        {
            GameManager.instance.musicSource.mute = true;
            GameManager.instance.musicMuted = true;
            toggleMusicButton.isOn = GameManager.instance.musicMuted;
        }
    }

    private void Instancenate()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



}
