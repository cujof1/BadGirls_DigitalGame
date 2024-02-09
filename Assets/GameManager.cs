using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State { Playing, Lost, Won }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioClip menuMusic;
    AudioClip backgroundMusic;
    public AudioSource backgroundMusicSource;

    public State state;

    private void Awake()
    {
        Instance = this;

        state = State.Playing;

        backgroundMusic = backgroundMusicSource.clip;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && state != State.Playing)
        {
            if (state == State.Won && SceneManager.GetActiveScene().name != "Night") SceneManager.LoadScene("Night");

            if (state == State.Lost) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnPLayerKilled()
    {
        state = State.Lost;

        UIManager.Instance.ToggleLoseUI();

        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = menuMusic;
        backgroundMusicSource.Play();
    }

    public void OnReachedEndOfLevel()
    {
        state = State.Won;

        UIManager.Instance.ToggleWinUI();

        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = menuMusic;
        backgroundMusicSource.Play();
    }
}
