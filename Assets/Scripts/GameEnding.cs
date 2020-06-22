using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup winPanel;
    public CanvasGroup caughtPanel;
    public float fadeDuration;
    public float displayDuration;
    private bool _isPlayerAtExit = false;
    private bool _isPlayerCaught = false;
    private float _timer = 0f;

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(winPanel, false);
        }
        else if (_isPlayerCaught)
        {
            EndLevel(caughtPanel, true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        _isPlayerCaught = true;
    }

    private void EndLevel(CanvasGroup panel, bool doRestart)
    {
        _timer += Time.deltaTime;
        panel.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration + displayDuration)
        {
            if (doRestart)
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
