using Code.Enemy;
using Code.Interfaces_and_Markers;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Controllers
{
    public class EnemyController: IEnemyPatrol
    {
        private NavMeshAgent _enemy;
        private Transform[] _wayPoints;
        private int _currentWayPointIndex;
        
        public EnemyController(){}

        public EnemyController(NavMeshAgent enemy, Transform[] wayPoints)
        {
            _enemy = enemy;
            _wayPoints = wayPoints;
        }

        public void SetEnemyAtPoint()
        {
            _enemy.SetDestination(_wayPoints[0].position);
        }

        public void Patrol()
        {
            if (_enemy.remainingDistance < _enemy.stoppingDistance)
            {
                _currentWayPointIndex = (_currentWayPointIndex + 1) % _wayPoints.Length;
                _enemy.SetDestination(_wayPoints[_currentWayPointIndex].position);
            }
        }

        public void SetWayP(Transform[] wP)
        {
            _wayPoints = wP;
        }
    }
}
