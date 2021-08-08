using UnityEngine;
using UnityEngine.Serialization;

public class Collectebles : MonoBehaviour
{
    [SerializeField] private GameObject[] collecteble;

    public static bool isAllCollectebles = false;
    public static int _numberCollectebles = 0;

    private void Update()
    {
        if (_numberCollectebles == collecteble.Length + 1)
        {
            isAllCollectebles = true;
        }
    }
}
