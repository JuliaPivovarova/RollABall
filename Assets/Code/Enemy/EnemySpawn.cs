using System;
using System.Collections.Generic;
using System.Data;
using Code.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    public class EnemySpawn: MonoBehaviour
    {
        private EnemyController _enemyController;
        public Transform[] wayPonits;
        private NavMeshAgent enemy;
        public GameObject EnemyGO;
        private GameObject _createEnemy;
        private bool _isNavMesh;
        public static List<Transform> ListWayPoints;
        private static List<GameObject> ListInstantiateWP;
        public GameObject objForWayPoint;
        private PathBot _rootWayPoint;

        private void Start()
        {
            if (EnemyGO == null)
            {
                EnemyGO = gameObject;
            }
            _isNavMesh = EnemyGO.TryGetComponent<NavMeshAgent>(out enemy);
            if (!_isNavMesh)
            {
                AddNavMeshA();
                enemy = EnemyGO.GetComponent<NavMeshAgent>();
            }
            _enemyController = new EnemyController(enemy, wayPonits);
            _enemyController.SetEnemyAtPoint();
        }

        private void Update()
        {
            _enemyController.Patrol();
        }

        private void AddNavMeshA()
        {
            EnemyGO.AddComponent<NavMeshAgent>();
        }

        public void SetObjThis()
        {
            EnemyGO = gameObject;
        }

        public void CreateEnemy()
        {
            if (wayPonits[0] != null)
            {
                _createEnemy = Instantiate(EnemyGO, wayPonits[0].position, wayPonits[0].rotation);
            }
            else
            {
                _createEnemy = Instantiate(EnemyGO, Vector3.zero, Quaternion.identity);
            }
            _createEnemy.AddComponent<NavMeshAgent>();
            _createEnemy.AddComponent<EnemySpawn>();
            EnemyGO = _createEnemy;
        }

        public void ListToArrayWayPoints()
        {
            wayPonits = new Transform[ListWayPoints.Capacity];
            int i = 0;
            foreach (var wPoint in ListWayPoints)
            {
                wayPonits[i] = wPoint;
                i++;
            }
            _enemyController.SetWayP(wayPonits);
        }

        public void CreateWayPoint(Vector3 posit)
        {
            if (!_rootWayPoint)
            {
                _rootWayPoint = new GameObject("WayPoint").AddComponent<PathBot>();
            }

            if (objForWayPoint != null)
            {
                var wPiontInst = GameObject.Instantiate(objForWayPoint, posit, Quaternion.identity, _rootWayPoint.transform);
                ListInstantiateWP.Add(wPiontInst);
                ListWayPoints.Add(wPiontInst.transform);
            }
            else
            {
                throw new Exception("There is no GameObject");
            }
        }

        public void AddToList(Transform pos)
        {
            ListWayPoints.Add(pos);
        }
    }
}