using System;
using System.Collections;
using System.Collections.Generic;
using RollaBall.Player;
using UnityEngine;

public class CollectebleJustOne : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerBall>(out var pl) || gameObject.activeInHierarchy)
            {
                Collectebles._numberCollectebles++;
                gameObject.SetActive(false);
            }
        }
}
