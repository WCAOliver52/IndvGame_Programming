using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //Implamented from learning from these tutorials: https://learn.unity.com/project/john-lemon-s-haunted-jaunt-3d-beginner?uv=2019.4
    public float fadeDur = 1f;
    public GameObject player;
    public CanvasGroup escapeCanvasGroup;
    public float imageDur = 1f;
    public CanvasGroup caughtCanvasGroup;

    bool atExit;
    float timer;
    bool playerCaught;

    void Update()
        {
            if (atExit)
            {
                EndLevel(escapeCanvasGroup, false);
            }
            else if (playerCaught)
            {
                EndLevel(caughtCanvasGroup, true);
            }
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            atExit = true;
        }
    }

    public void CaughtPlayer()
    {
        playerCaught = true;
    }

    

    void EndLevel(CanvasGroup imageCanvasGroup, bool restartLevel)
    {
        timer += Time.deltaTime;

        imageCanvasGroup.alpha = timer / fadeDur;

        if (timer > fadeDur + imageDur)
        {
            if (restartLevel)
            {
                SceneManager.LoadScene(0);

            }
            else
            {
                Application.Quit();
            }

        }

    }
}