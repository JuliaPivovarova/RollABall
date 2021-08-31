using System;
using System.Collections;
using RollaBall.Player;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MarkerLowSpeedPPr : MonoBehaviour
{
    private Player _player;
    private PostProcessVolume _ppv;
    private bool _exist;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _player._bonusesEventLowerSp += LowPP;
        _exist = TryGetComponent<PostProcessVolume>(out _ppv);
        if (!_exist)
        {
            throw new Exception("There is no PostProcessVolume");
        }
    }

    private void OnDestroy()
    {
        _player._bonusesEventLowerSp -= LowPP;
    }

    private void LowPP(Collider coll)
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
