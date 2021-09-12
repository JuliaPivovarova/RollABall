using System.Collections;
using Code.Controllers;
using Code.UI;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Code.BonusCode
{
    public class Bonuses
    {
        private PlayerInputController _playerInputController = new PlayerInputController();
        private UITextBonus _uiTextBonus = new UITextBonus();

        public IEnumerator ChangeSpeed(float chSpeed, PostProcessVolume ppv)
        {
            _playerInputController.ChangeSpeed(chSpeed);
            if (chSpeed > 0)
            {
                _uiTextBonus.SetText("faster");
            }
            if (chSpeed < 0)
            {
                _uiTextBonus.SetText("slower");
            }
            _uiTextBonus.SetBonusWork(true);
            ppv.enabled = true;
            yield return new WaitForSeconds(4f);
            _playerInputController.ChangeSpeed(-1 * chSpeed);
            ppv.enabled = false;
            _uiTextBonus.SetBonusWork(false);
            _uiTextBonus.SetText("");
        }

        public IEnumerator Invic()
        {
            _uiTextBonus.SetText("invicible");
            _uiTextBonus.SetBonusWork(true);
            _playerInputController.Invicibility(true);
            yield return new WaitForSeconds(5f);
            _playerInputController.Invicibility(false);
            _uiTextBonus.SetBonusWork(false);
            _uiTextBonus.SetText("");
        }
    }
}
