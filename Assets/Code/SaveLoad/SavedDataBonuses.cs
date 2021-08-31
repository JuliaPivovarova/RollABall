using System;
using Code.BonusCode;

namespace Code.SaveLoad
{
    [Serializable]
    public sealed class SavedDataBonuses
    {
        public string KeyDictionary;
        public BonusSingleClass Bonus;
        public bool IsEnabled;
        public override string ToString() => 
            $"<color=blue>Name</color> {KeyDictionary} <color=blue>Name</color> {Bonus} <color=blue>IsVisible</color> {IsEnabled}";
        

    }
}