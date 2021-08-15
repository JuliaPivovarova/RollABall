using RollaBall.Bonuses;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour, IDeath
{
    [SerializeField] private Collider player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup deadBackgroundImageCanvasGroup;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private float displayImageDuration = 1f;
    [SerializeField] private string loadingSceneName;
    
    private bool _isPlayerAtExit;
    //private bool _isPlayerDead;
    private float _timer;

    public bool IsPlayerDead { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            _isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            GameEnding(exitBackgroundImageCanvasGroup, false);
        }

        if (IsPlayerDead)
        {
            GameEnding(deadBackgroundImageCanvasGroup, true);
        }
    }

    private void GameEnding(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        _timer += Time.deltaTime;

        imageCanvasGroup.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(loadingSceneName);
            }
            else
            {
                Application.Quit();
                
            }
        }
    }

    
}
