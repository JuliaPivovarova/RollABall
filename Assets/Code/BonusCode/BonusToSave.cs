using UnityEngine;

namespace Code.BonusCode
{
    public class BonusToSave: BonusSingleClass
    {
        private static Transform position;
        private static bool _interctible;
        private static bool _good;
        private static string _bDo;
        public string ToSave(BonusSingleClass bonus)
        {
            position = bonus.Position;
            _interctible = bonus.Interecteble;
            _good = bonus.Good;
            _bDo = bonus.BonusDo;
            
            return  $"positionX {position.position.x} positionY {position.position.y} positionZ {position.position.z} isInterecteble {_interctible} isGood {_good} bonusDo {_bDo}";
        }
    }
}