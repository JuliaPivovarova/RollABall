using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Code.Interfaces_and_Markers
{
    public class MarkerFastSpeedPPr : MonoBehaviour
    {
        private Player.Player.Player _player;
        private PostProcessVolume _ppv;
        private bool _exist;

        private void Start()
        {
            _player = FindObjectOfType<Player.Player.Player>();
            //_player._bonusesEventAddSp += AddPP;
            _exist = TryGetComponent<PostProcessVolume>(out _ppv);
            if (!_exist)
            {
                throw new Exception("There is no PostProcessVolume");
            }
        }

        private void AddPP(Collider coll)
        {
            if (_exist) _ppv.enabled = true;
            StartCoroutine(AddPostPr());
        }
    
        private IEnumerator AddPostPr()
        {
            yield return new WaitForSeconds(4f);
            if (_exist) _ppv.enabled = false;
        }
    }
}
