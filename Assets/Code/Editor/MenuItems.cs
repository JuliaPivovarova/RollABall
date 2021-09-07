using UnityEditor;

namespace Code.Editor
{
    public class MenuItems
    {
        [MenuItem("Свои окна/Окно врага")]
        private static void MenuOptions()
        {
            EditorWindow.GetWindow(typeof(EnemyWindow), false, "Enemy");
        }
    }
}