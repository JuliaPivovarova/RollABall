using System;
using System.Collections;
using Code.Player;
using RollaBall.Bonuses;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

namespace Code
{
    public class Bonuses //: MonoBehaviour, IAddSpeed, ILowerSpeed
    {
        //[SerializeField] private Transform[] spawnGoodBonuses;
        //[SerializeField] private Transform[] spawnBadBonuses;
        //[SerializeField] private GameObject[] goodBonuses;
        //[SerializeField] private GameObject[] badBonuses;

        //private static GameObject[] cloneGoodBonuses;
        //private GameObject[] cloneBadBonuses;

        //public static GameObject[] ClGB => cloneGoodBonuses;
        //public GameObject[] ClBB => cloneBadBonuses;

        private RollaBall.Player.Player _player;
        private FlagInterection _flag;
        private PlayerInputController _playerInputController;
        private Collider coll;
        private FastSpeedPostPrController _fastSpeedPostPrController;
        private LowSpeedPostPrController _lowSpeedPostPrController;        

        public float SpeedPlus { get; } = 2f;
        public float LowerSpeed { get; } = -2f;


        //public Func<int> DelegNumberBon;
        public Action DelegAddSp;
        public Action DelegLowerSp;
        public Action DelegDeath;
        public Action DelegInvic;
            
        

        private void Start()
        {
            //cloneGoodBonuses = new GameObject[spawnGoodBonuses.Length];
            //cloneBadBonuses = new GameObject[spawnBadBonuses.Length];
            //Clone(spawnGoodBonuses, goodBonuses, cloneGoodBonuses);
            //Clone(spawnBadBonuses, badBonuses, cloneBadBonuses);
            
            //_player = FindObjectOfType<RollaBall.Player.Player>();

            //_player._bonusesEventAddSp += NotActiveCloneBonuses;
            //_player._bonusesEventLowerSp += NotActiveCloneBonuses;
            //_player._bonusesEventInvic += NotActiveCloneBonuses;
            //_player._bonusesEventDeath += NotActiveCloneBonuses;
            
            //DelegNumberBon = NumberBonSpaw;
            DelegAddSp = AddSp;
            DelegLowerSp = LowerSp;
            DelegDeath = PlDead;
            DelegInvic = IsInvic;
        }

        private void OnDestroy()
        {
            //_player._bonusesEventAddSp -= NotActiveCloneBonuses;
            //_player._bonusesEventLowerSp -= NotActiveCloneBonuses;
            //_player._bonusesEventInvic -= NotActiveCloneBonuses;
            //_player._bonusesEventDeath -= NotActiveCloneBonuses;
        }

        #region hide

        private void Clone(Transform[] spawnpoints, GameObject[] bonus, GameObject[] clonebonuses)
        {

            if (spawnpoints != null)
            {
                if (bonus != null)
                {
                    for (int i = 0; i < spawnpoints.Length; i++)
                    {
                        var bonusClone = Random.Range(0, bonus.Length);
                        //clonebonuses[i] = Instantiate(bonus[bonusClone], spawnpoints[i].position, spawnpoints[i].rotation);
                        clonebonuses[i].SetActive(true);
                        
                    }
                }
                else
                {
                    throw new Exception("There is no bonuses");
                }
            }
            else
            {
                throw new Exception("There is no spawn points");
            }
            
        }
        
        //private void NotActiveCloneBonuses(Collider other)
        //{
            //Debug.Log("Yes");
        //    for (int i = 0; i < cloneGoodBonuses.Length; i++)
        //    {
        //        _flag = cloneGoodBonuses[i].GetComponent<FlagInterection>();
        //       if (_flag.InterectedWithPl)
        //        {
        //           cloneGoodBonuses[i].SetActive(false);
        //        }
        //    }
        //    for (int i = 0; i < cloneBadBonuses.Length; i++)
        //    {
        //        _flag = cloneBadBonuses[i].GetComponent<FlagInterection>();
        //        if (_flag.InterectedWithPl)
        //        {
        //            cloneBadBonuses[i].SetActive(false);
        //       }
        //    }
        //}

        #endregion
        

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
            yield return new WaitForSeconds(4f);
            _playerInputController.Invicibility(false);
        }

        private void IsInvic()
        {
            Invic();
        }

        private void AddSp()
        {
            //StartCoroutine(ChangeSpeed(SpeedPlus));
        }

        private void LowerSp()
        {
            //StartCoroutine(ChangeSpeed(LowerSpeed));
        }

        private void PlDead()
        {
            _playerInputController.PlayerDead(true);
        }
    }
}
