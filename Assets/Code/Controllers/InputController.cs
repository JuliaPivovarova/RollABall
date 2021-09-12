using Code.Interfaces_and_Markers;
using Code.Player.Player;
using Code.SaveLoad;
using UnityEngine;

namespace Code.Controllers
{
    public sealed class InputController: IExecute
    {
        private readonly PlayerBall _player;
        private readonly InputData _inputData;
        private readonly ISaveDataRepository _saveDataRepository;

        public InputController(){}
        public InputController(PlayerBall player, InputData inputData)
        {
            _player = player;
            _inputData = inputData;

            _saveDataRepository = new SaveDataRepository();
        }
        
        public void Execute()
        {
            if (Input.GetKeyDown(_inputData.SavePlayer))
            {
                _saveDataRepository.Save(_player);
            }
            if (Input.GetKeyDown(_inputData.LoadPlayer))
            {
                _saveDataRepository.Load(_player);
            }
        }
    }
}