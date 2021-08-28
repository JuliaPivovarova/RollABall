using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class UIPauseData
    {
        [SerializeField] private Button _btnBack;
        [SerializeField] private Button _btnEnd;
        [SerializeField] private Button _btnRetry;

        public Button BtnBack => _btnBack;
        public Button BtnEnd => _btnEnd;
        public Button BtnRetry => _btnRetry;
    }
}