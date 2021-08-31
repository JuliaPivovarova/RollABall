using System;
using Code.BonusCode;

namespace Code.SaveLoad
{
    [Serializable]
    public sealed class SavedData
    {
        public string Name;
        public Vector3Serializable Position;
        public bool IsEnabled;

        public int[] KeyDictionary;
        public string[] Bonus;

        public override string ToString() => 
            $"<color=blue>Name</color> {Name} <color=blue>Position</color> {Position} <color=blue>IsVisible</color> {IsEnabled} " +
            $"<color=blue>KeyDictionary</color> {KeyDictionary} <color=blue>Bonuses</color> {Bonus}";
    }
}