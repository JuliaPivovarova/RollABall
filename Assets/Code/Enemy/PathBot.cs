using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Enemy
{
    public class PathBot: MonoBehaviour
    {
        [SerializeField] private Color _lineColor = Color.magenta;
        private List<Transform> _nodes = new List<Transform>();

        private void OnValidate()
        {
            _nodes = GetComponentsInChildren<Transform>().ToList();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _lineColor;
            for (int i = 0; i < _nodes.Count; i++)
            {
                var currentNode = _nodes[i].position;
                var previosNode = Vector3.zero;
                if (i > 0)
                {
                    previosNode = _nodes[i - 1].position;
                }
                else if (i == 0 && _nodes.Count > 1)
                {
                    previosNode = _nodes[_nodes.Count - 1].position;
                }
                Gizmos.DrawLine(previosNode, currentNode);
                Gizmos.DrawSphere(currentNode, 0.3f);
            }
        }
    }
}