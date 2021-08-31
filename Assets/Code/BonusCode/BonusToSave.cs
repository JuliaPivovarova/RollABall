using UnityEngine;

namespace Code.BonusCode
{
    public class BonusToSave: BonusSingleClass
    {
        public Transform position;
        public bool _interctible;
        public bool _good;
        public string _bDo;
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