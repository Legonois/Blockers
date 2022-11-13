using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip winClip;
    public AudioSource audioSource;
    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void GoalReached()
    {
        winScreen.SetActive(true);
        audioSource.PlayOneShot(winClip);
        Time.timeScale = 0;
    }

    public void LevelFailed()
    {
        loseScreen.SetActive(true);
        audioSource.PlayOneShot(deathClip);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
