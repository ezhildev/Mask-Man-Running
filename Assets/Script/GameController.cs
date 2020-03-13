using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    private GameObject player, gui;
    private Text scoreText;
    [SerializeField]
    private AudioClip scoreMaxSound;
    private AudioSource sound;

    private float score, maxScore = 5f;
    [SerializeField] private bool isSoundStop;

    void Start()
    {
        sound = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        gui = GameObject.Find("GUI");
        scoreText = gui.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        sound.Play();
    }

    void Update()
    {
        RestartMenuPopup();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            if (gui.transform.GetChild(0).GetChild(5).gameObject.activeSelf)
            {
                ResumeButton();
            }
            else
            {
                RestartButton();
            }
        }
    }

    private void RestartMenuPopup()
    {
        if(player == null)
        {
            gui.transform.GetChild(2).transform.gameObject.SetActive(false);
            gui.transform.GetChild(0).transform.gameObject.SetActive(true);
            gui.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
            gui.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = scoreText.text;

            if (isSoundStop)
            {
                sound.Stop();
            }
        }
        else
        {
            ScoreIncrement();
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        gui.transform.GetChild(2).transform.gameObject.SetActive(false);
        gui.transform.GetChild(0).transform.gameObject.SetActive(true);
        gui.transform.GetChild(0).transform.gameObject.GetComponent<Animator>().enabled = false;
        gui.transform.GetChild(0).transform.position = Vector3.zero;
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        gui.transform.GetChild(0).transform.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void ScoreIncrement()
    {
        score += 1f * Time.deltaTime;
        scoreText.text = Convert.ToString(Mathf.Round(score));

        if(score >= maxScore)
        {
            sound.PlayOneShot(scoreMaxSound);
            maxScore += maxScore;
        }
    }
}
