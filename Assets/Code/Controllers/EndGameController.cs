using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Controllers
{
    public sealed class EndGameController
    {
        private float _fadeDuration;
        private float _displayImageDuration;
        private string _loadingSceneName;
        
        private float _timer;

        public EndGameController(){}
        public EndGameController(float fadeDuration, float displayImageDuration, string loadingSceneName)
        {
            _fadeDuration = fadeDuration;
            _displayImageDuration = displayImageDuration;
            _loadingSceneName = loadingSceneName;
        }
        
        public void GameEnding(CanvasGroup imageCanvasGroup, bool doRestart)
                {
                    _timer += Time.deltaTime;
        
                    imageCanvasGroup.alpha = _timer / _fadeDuration;
        
                    if (_timer > _fadeDuration + _displayImageDuration)
                    {
                        if (doRestart)
                        {
                            SceneManager.LoadScene(_loadingSceneName, LoadSceneMode.Single);
                        }
                        else
                        {
                            Application.Quit();
                        }
                    }
                }
    }
}