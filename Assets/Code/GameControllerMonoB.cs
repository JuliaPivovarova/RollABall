using System;
using Code.BonusCode;
using Code.Controllers;
using Code.Interfaces_and_Markers;
using Code.MiniMap;
using Code.Player.Player;
using Code.SaveLoad;
using Code.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class GameControllerMonoB : MonoBehaviour
    {
        [SerializeField] private Collider player;
        [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
        [SerializeField] private CanvasGroup deadBackgroundImageCanvasGroup;
        [SerializeField] private float fadeDuration = 1.0f;
        [SerializeField] private float displayImageDuration = 1f;
        [SerializeField] private string loadingSceneName;
        [SerializeField] private InputData inputData;
        [SerializeField] private Transform miniMapCamera;
        [SerializeField] private float speed = 3.0f;
        [SerializeField] private Transform[] spawnPointsGood;
        [SerializeField] private Transform[] spawnPointsBad;
        [SerializeField] private BonusSingleClass[] bonusesGood;
        [SerializeField] private BonusSingleClass[] bonusesBad;
        [SerializeField] private GameObject[] collecteble;
        [SerializeField] private Button load;
        [SerializeField] private Button save;
        [SerializeField] private Slider collectebleSlider;
        [SerializeField] private TextMeshProUGUI textBonus;
        [SerializeField] private TextMeshProUGUI textForBonus;

        private InputController _inputController;
        private CameraMove _cameraMove;
        private MiniMapController _miniMapController;
        private MiniMapInitialization _miniMapInitializ;
        private PlayerInputController _playerInputController;
        private BonusSpawn _bonusSpawn = new BonusSpawn();
        private SaveDataRepository _saveDataRepository;
        private DataBonus _dataBonus;
        private PlayerBall _playerBall;
        private EndGameController _endGameController;
        private UICollecteblesSlider _uiCollecteblesSlider;
        private UITextBonus _uiTextBonus;
        private bool _isPlayerAtExit;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other == player)
            {
                _isPlayerAtExit = true;
            }
        }

        private void Awake()
        {
            _playerBall = FindObjectOfType<PlayerBall>();
            _dataBonus = new DataBonus(spawnPointsGood, spawnPointsBad, bonusesGood, bonusesBad);
            var _camera = FindObjectOfType<MarkerMainCamera>();
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(_playerBall, inputData);
            }
            
            _cameraMove = new CameraMove(player.transform, _camera.transform);
            _miniMapController = new MiniMapController(player.transform, miniMapCamera.transform);
            _miniMapInitializ = new MiniMapInitialization(player.transform, miniMapCamera.transform);
            _miniMapInitializ.Initialize();
            _playerInputController = new PlayerInputController(_playerBall, speed);
            _saveDataRepository = new SaveDataRepository();
            _endGameController = new EndGameController(fadeDuration, displayImageDuration, loadingSceneName);
            _uiCollecteblesSlider = new UICollecteblesSlider();
            _uiTextBonus = new UITextBonus();
            save.onClick.AddListener(ToSave);
            load.onClick.AddListener(ToLoad);
            _bonusSpawn.CreateB();
            collectebleSlider.maxValue = (float)collecteble.Length;
            collectebleSlider.minValue = 0;
            collectebleSlider.value = 0;
            textBonus.enabled = true;
            textForBonus.enabled = false;
        }

        private void OnDestroy()
        {
            save.onClick.RemoveAllListeners();
            load.onClick.RemoveAllListeners();
        }

        private void Update()
        {
            _inputController.Execute();
            _cameraMove.Execute();
            _playerInputController.Execute();
            if (_isPlayerAtExit)
            {
                _endGameController.GameEnding(exitBackgroundImageCanvasGroup, false);
            }
            if (_playerInputController.IsPlayerDead())
            {
                _endGameController.GameEnding(deadBackgroundImageCanvasGroup, true);
            }
        }

        private void LateUpdate()
        {
            _miniMapController.LateExecute();
            collectebleSlider.value = _uiCollecteblesSlider.CurrentCollectebles();
            textBonus.text = _uiTextBonus.GetText();
            textForBonus.enabled = _uiTextBonus.GetBonusWork();
        }

        private void ToSave()
        {
            _saveDataRepository.Save(_playerBall);
        }
        
        private void ToLoad()
        {
            _saveDataRepository.Load(_playerBall);
        }
        
        
    }
}
