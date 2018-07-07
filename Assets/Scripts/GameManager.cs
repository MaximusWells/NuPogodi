using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool musicMuted;
    public bool soundMuted;
    public AudioSource musicSource;
    public AudioSource soundSource;

    void Awake()
    {
        Singleton();
        SceneManager.sceneLoaded += ThatSceneWasLoaded;
    }

    private void ThatSceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        musicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();
        soundSource = GameObject.FindGameObjectWithTag("SoundSource").GetComponent<AudioSource>();
    }

    private void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
