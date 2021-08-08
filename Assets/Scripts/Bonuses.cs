using System;
using System.Collections;
using RollaBall.Bonuses;
using RollaBall.Player;
using UnityEngine;
using Random = UnityEngine.Random;
using static UnityEngine.Debug;

public class Bonuses : MonoBehaviour, IAddSpeed, ILowerSpeed, IDeath, IInvincibility
{
    [SerializeField] private Transform[] spawnGoodBonuses;
    [SerializeField] private Transform[] spawnBadBonuses;
    [SerializeField] private GameObject[] goodBonuses;
    [SerializeField] private GameObject[] badBonuses;
    
    
    private float _speedRotation;
    private Player _player;

    public float speedPlus { get; } = 2f;
    public float lowerSpeed { get; } = -2f;
    public bool isPlayerDead { get; set; }
    public bool IsInvincible { get; set; } = false;
    
    
    public void Rotation()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
    }

    private void Start()
    {
        GameObject[] cloneGoodBonuses = new GameObject[spawnGoodBonuses.Length];
        GameObject[] cloneBadBonuses = new GameObject[spawnBadBonuses.Length];
        Clone(spawnGoodBonuses, goodBonuses, cloneGoodBonuses);
        Clone(spawnBadBonuses, badBonuses, cloneBadBonuses);
        _speedRotation = Random.Range(1.0f, 3f);
    }

    private void Clone(Transform[] spawnpoints, GameObject[] bonus, GameObject[] clonebonuses)
    {
        
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            var bonusClone = Random.Range(0, bonus.Length);
            clonebonuses[i] = Instantiate(bonus[bonusClone], spawnpoints[i].position, spawnpoints[i].rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Death") || other.CompareTag("Player"))
        {
            if (!IsInvincible)
            {
                isPlayerDead = true;
            }
        }
        if (gameObject.CompareTag("AddSpeed") || other.CompareTag("Player"))
        {
            Debug.Log("Add speed");
            ChangeSpeed(speedPlus);
        }
        if (gameObject.CompareTag("LowerSpeed") || other.CompareTag("Player"))
        {
            Debug.Log("Lower speed");
            ChangeSpeed(lowerSpeed);
        }

        if (gameObject.CompareTag("Invicible") || other.CompareTag("Player"))
        {
            Debug.Log("Invicibility");
            Invic();
        }
    }

    private IEnumerator ChangeSpeed(float chSpeed)
    {
        _player.SpeedChange(chSpeed);
        yield return new WaitForSeconds(3f);
        _player.SpeedChange(-chSpeed);
    }

    private IEnumerator Invic()
    {
        IsInvincible = true;
        yield return new WaitForSeconds(3f);
        IsInvincible = false;
    }
    
}
