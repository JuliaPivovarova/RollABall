using Code.Enemy;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Code.Editor
{
    public class EnemyWindow: EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public static GameObject ObjectToWork;
        public string nameObject = "Enemy";
        public bool groupEnabled;
        public bool randomColor = false;
        private bool _isRandomColorAdded = false;
        public bool addNavMashA = false;
        private bool _isNavMeshAAdded = false;
        public bool AddToEnemy = false;
        public float PosX;
        public float PosY;
        public float PosZ;
        public Color objToWorkColor;
        private Renderer objRenderer;
        private EnemySpawn _enemySpawn;
        
        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            ObjectInstantiate = EditorGUILayout.ObjectField("Объект, который хотим вставить", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            PosX = EditorGUILayout.FloatField("Position X:", PosX);
            PosY = EditorGUILayout.FloatField("Position Y:", PosY);
            PosZ = EditorGUILayout.FloatField("Position Z:", PosZ);
            if (ObjectToWork == null)
            {
                ObjectToWork = GameObject.Instantiate(ObjectInstantiate, new Vector3(PosX, PosY, PosZ), Quaternion.identity) as GameObject;
                ObjectToWork.SetActive(true);
            }

            ObjectToWork.transform.position = new Vector3(PosX, PosY, PosZ);
            ObjectToWork = EditorGUILayout.ObjectField("Сазданный объект", ObjectToWork, typeof(GameObject), true) as GameObject;
            nameObject = EditorGUILayout.TextField("Имя объекта", nameObject);
            groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
            objToWorkColor = EditorGUILayout.ColorField("Цвет объекта", objToWorkColor);
            randomColor = EditorGUILayout.Toggle("Случайный цвет", randomColor);
            addNavMashA = EditorGUILayout.Toggle("Добавить NavMesh", addNavMashA);
            EditorGUILayout.EndToggleGroup();
            objRenderer = ObjectToWork.GetComponent<Renderer>();
            var _addToEnemy = GUILayout.Button("Добавить к врагам", EditorStyles.miniButtonLeft);
            AddToEnemy = EditorGUILayout.Toggle("Ok", AddToEnemy);
            
            if (randomColor && !_isRandomColorAdded)
            {
                objToWorkColor = Random.ColorHSV();
                objRenderer.material.color = objToWorkColor;
                _isRandomColorAdded = true;
            }
            if (!randomColor)
            {
                objRenderer.material.color = objToWorkColor;
                _isRandomColorAdded = false;
            }
            if (addNavMashA && !_isNavMeshAAdded)
            {
                ObjectToWork.AddComponent<NavMeshAgent>();
                _isNavMeshAAdded = true;
            }
            ObjectToWork.name = nameObject;

            if (_addToEnemy)
            {
                AddToEnemy = true;
                ObjectToWork.AddComponent<EnemySpawn>();
                _enemySpawn = ObjectToWork.GetComponent<EnemySpawn>();
                _enemySpawn.EnemyGO = ObjectToWork;
                _enemySpawn.wayPonits = new[] {ObjectToWork.transform};
            }
        }
    }
}