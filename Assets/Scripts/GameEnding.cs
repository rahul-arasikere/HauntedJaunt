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
    public AudioClip _winAudio;
    public AudioClip _loseAudio;

    private void Start()
    {

    }
    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(winPanel, false, _winAudio);
        }
        else if (_isPlayerCaught)
        {
            EndLevel(caughtPanel, true, _loseAudio);
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

    private IEnumerator PlayAudio(AudioClip audio)
    {
        AudioSource audioToPlay = new AudioSource();
        audioToPlay.clip = audio;
        audioToPlay.Play();
        yield return new WaitForSeconds(audio.length);
    }
    private void EndLevel(CanvasGroup panel, bool doRestart, AudioClip audio)
    {
        // StartCoroutine(PlayAudio(audio));
        _timer += Time.deltaTime;
        panel.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration + displayDuration)
        {
            if (doRestart)
            {
                GameState.Instance.PlayerEscaped();
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
