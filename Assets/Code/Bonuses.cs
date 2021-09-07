using System;
using System.Collections;
using Code.Player;
using RollaBall.Bonuses;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

namespace Code
{
    public class Bonuses
    {
        private RollaBall.Player.Player _player;
        private FlagInterection _flag;
        private PlayerInputController _playerInputController = new PlayerInputController();
        private Collider coll;
        private FastSpeedPostPrController _fastSpeedPostPrController;
        private LowSpeedPostPrController _lowSpeedPostPrController;

        public IEnumerator ChangeSpeed(float chSpeed, PostProcessVolume ppv)
        {
            _playerInputController.ChangeSpeed(chSpeed);
            ppv.enabled = true;
            yield return new WaitForSeconds(4f);
            _playerInputController.ChangeSpeed(-1 * chSpeed);
            ppv.enabled = false;
        }

        public IEnumerator Invic()
        {
            _playerInputController.Invicibility(true);
            yield return new WaitForSeconds(5f);
            _playerInputController.Invicibility(false);
        }
    }
}
