using System;
using System.Collections;
using Code;
using Code.BonusCode;
using Code.Interface;
using Code.MiniMap;
using Code.Player;
using RollaBall.Bonuses;
using RollaBall.Player;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Collider player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup deadBackgroundImageCanvasGroup;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private float displayImageDuration = 1f;
    [SerializeField] private string loadingSceneName;
    [SerializeField] private InputData _inputData;
    [SerializeField] private Transform _miniMapCamera;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Transform[] spawnPointsGood;
    [SerializeField] private Transform[] spawnPointsBad;
    [SerializeField] private BonusSingleClass[] bonusesGood;
    [SerializeField] private BonusSingleClass[] bonusesBad;
    private BonusSpawn _spawn;
    
    private InputController _inputController;
    private CameraMove _cameraMove;
    private MiniMapController _miniMapController;
    private MiniMapInitialization _miniMapInitializ;
    private PlayerInputController _playerInputController;
    private BonusSpawn _bonusSpawn;
    private FastSpeedPostPrController _fastSpeedPostPrController;
    private LowSpeedPostPrController _lowSpeedPostPrController;
    private DataBonus _dataBonus;
    private bool _isPlayerAtExit;
    private float _timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            _isPlayerAtExit = true;
        }
    }

    private void Awake()
    {
        var _playerBall = FindObjectOfType<PlayerBall>();
        _dataBonus = new DataBonus(spawnPointsGood, spawnPointsBad, bonusesGood, bonusesBad);
        var _camera = FindObjectOfType<MarkerMainCamera>();
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            _inputController = new InputController(_playerBall, _inputData);
        }
        _cameraMove = new CameraMove(player.transform, _camera.transform);
        _miniMapController = new MiniMapController(player.transform, _miniMapCamera.transform);
        _miniMapInitializ = new MiniMapInitialization(player.transform, _miniMapCamera.transform);
        _miniMapInitializ.Initialize();
        _playerInputController = new PlayerInputController(_playerBall, speed);
    }

    private void Start()
    {
        _spawn = new BonusSpawn();
    }

    private void Update()
    {
        _inputController.Execute();
        _cameraMove.Execute();
        _playerInputController.Execute();
        if (_isPlayerAtExit)
        {
            GameEnding(exitBackgroundImageCanvasGroup, false);
        }

        if (_playerInputController.IsPlayerDead())
        {
            GameEnding(deadBackgroundImageCanvasGroup, true);
        }
    }

    private void LateUpdate()
    {
        _miniMapController.LateExecute();
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
