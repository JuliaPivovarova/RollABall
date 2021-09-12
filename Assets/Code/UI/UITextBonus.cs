namespace Code.UI
{
    public class UITextBonus
    {
        public UITextBonus(){}

        private static string _textBonus = "";
        private static bool _courotWork = false;

        public string GetText()
        {
            return _textBonus;
        }

        public void SetText(string textBonus)
        {
            _textBonus = textBonus;
        }

        public void SetBonusWork(bool courotWork)
        {
            _courotWork = courotWork;
        }

        public bool GetBonusWork()
        {
            return _courotWork;
        }
    }
}