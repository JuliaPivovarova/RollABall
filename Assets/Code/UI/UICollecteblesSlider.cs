namespace Code.UI
{
    public sealed class UICollecteblesSlider
    {
        private static float _currentColletebles = 0;

        public UICollecteblesSlider(){}

        public float CurrentCollectebles()
        {
            return _currentColletebles;
        }

        public void AddCollecteble()
        {
            _currentColletebles++;
        }
    }
}