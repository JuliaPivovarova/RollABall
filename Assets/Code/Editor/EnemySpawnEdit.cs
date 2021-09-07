using System;
using Code.Enemy;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Code.Editor
{
    [CustomEditor(typeof(EnemySpawn))]
    public class EnemySpawnEdit: UnityEditor.Editor
    {
        private bool _isPressBtnAddWayPointsWithMouse;
        private bool _isPressBtnCreate;
        private bool _isPressBtnListToArrWP;
        private bool _pathBAdded = false;
        private int _arrayLenght;
        private GameObject[] wayP;
        private EnemySpawn enemy;

        private void OnEnable()
        {
            enemy = (EnemySpawn) target;
            enemy.SetObjThis();
        }

        public override void OnInspectorGUI()
        {
            enemy.EnemyGO = EditorGUILayout.ObjectField("Объекта для создания Враг", enemy.EnemyGO, typeof(GameObject), false) as GameObject;
            enemy.objForWayPoint = EditorGUILayout.ObjectField("Объекта для WayPoint", enemy.objForWayPoint, typeof(GameObject), true) as GameObject;
            if (enemy.objForWayPoint != null && !_pathBAdded)
            {
                enemy.objForWayPoint.AddComponent<PathBot>();
                _pathBAdded = true;
            }
            var isPressBtn = GUILayout.Button("Создание врага по кнопке", EditorStyles.miniButtonLeft);
            _isPressBtnCreate = GUILayout.Toggle(_isPressBtnCreate, "OK");
            if (isPressBtn)
            {
                enemy.CreateEnemy();
                _isPressBtnCreate = true;
            }

            _arrayLenght = EditorGUILayout.IntSlider("Количество точек патруля", _arrayLenght, 1, 20);
            wayP = new GameObject[_arrayLenght];
            if(_arrayLenght > 1)
            {
                for (int i = 0; i < _arrayLenght; i++)
                {
                    wayP[i] = EditorGUILayout.ObjectField($"WayPoint{i}", wayP[i], typeof(GameObject), true) as GameObject;
                }
            }

            if (wayP[wayP.Length - 1] != null)
            {
                for (int i = 0; i < wayP.Length; i++)
                {
                    enemy.AddToList(wayP[i].transform);
                }
                enemy.ListToArrayWayPoints();
            }
            var _wayPMouse = GUILayout.Button("Добавление точек потруля мышкой", EditorStyles.miniButtonLeft);
            _isPressBtnAddWayPointsWithMouse = GUILayout.Toggle(_isPressBtnAddWayPointsWithMouse, "Ok");
            if (_wayPMouse)
            {
                _isPressBtnAddWayPointsWithMouse = true;
            }

            if (_isPressBtnAddWayPointsWithMouse)
            {
                var _listToArrWP = GUILayout.Button("Добавить точки", EditorStyles.miniButtonLeft);
                _isPressBtnListToArrWP = GUILayout.Toggle(_isPressBtnListToArrWP, "Ok");
                if (_listToArrWP)
                {
                    _isPressBtnListToArrWP = true;
                    enemy.ListToArrayWayPoints();

                    for (int i = 0; i < enemy.wayPonits.Length; i++)
                    {
                        enemy.wayPonits[i] = EditorGUILayout.ObjectField("WayPoint", enemy.wayPonits[i], typeof(GameObject), true) as Transform;
                    }
                }
            }
        }

        private void OnSceneGUI()
        {
            if (_isPressBtnAddWayPointsWithMouse)
            {
                if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
                {
                    Ray ray = Camera.current.ScreenPointToRay(new Vector3(Event.current.mousePosition.x,
                        SceneView.currentDrawingSceneView.camera.pixelHeight - Event.current.mousePosition.y));
                    if (Physics.Raycast(ray, out var hit))
                    {
                        enemy.CreateWayPoint(hit.point);
                        SetObjectDirty(enemy.gameObject);
                    }
                }
                Selection.activeGameObject = FindObjectOfType<EnemySpawn>().gameObject;
            }
        }

        public void SetObjectDirty(GameObject obj)
        {
            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(obj);
                EditorSceneManager.MarkSceneDirty(obj.scene);
            }
        }
    }
}