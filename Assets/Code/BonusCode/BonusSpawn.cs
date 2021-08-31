using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Code.BonusCode
{
    public class BonusSpawn: ICreateBonuses, IRandomPosition
    {
        public Dictionary<int, BonusSingleClass> _bonusList;
        private DataBonus _dataBonus;
        private InstantiateBonus _instantiateBonus;

        public BonusSpawn()
        {
            CreateB();
        }
        public void CreateB()
        {
            BonusSingleClass instanceBonus = new BonusSingleClass();
            for (int i = 0; i < _dataBonus.SpawnPointsG().Length; i++)
            {
                var randomBonus = RandomP(_dataBonus.BonG);
                instanceBonus.ComplitBonus = _instantiateBonus.InstBon(randomBonus.ConstructBonus(), randomBonus.Position);
                    
                //instanceBonus.ComplitBonus = Instantiate(randomBonus.ConstructBonus(), randomBonus.Position.position,
                //    randomBonus.Position.rotation);
                instanceBonus.Interecteble = randomBonus.Interecteble;
                instanceBonus.BonusDo = randomBonus.BonusDo;
                instanceBonus.Good = randomBonus.Good;
                _bonusList.Add(i, instanceBonus);
            }

            for (int i = 0; i < _dataBonus.SpawnPointsB().Length; i++)
            {
                var randomBonus = RandomP(_dataBonus.BonB);
                instanceBonus.ComplitBonus = _instantiateBonus.InstBon(randomBonus.ConstructBonus(), randomBonus.Position);
                //instanceBonus.ComplitBonus = Instantiate(randomBonus.ConstructBonus(), randomBonus.Position.position,
                //    randomBonus.Position.rotation);
                instanceBonus.Interecteble = randomBonus.Interecteble;
                instanceBonus.BonusDo = randomBonus.BonusDo;
                instanceBonus.Good = randomBonus.Good;
                _bonusList.Add(i + _dataBonus.SpawnPointsG().Length, instanceBonus);
            }
        }

        public BonusSingleClass RandomP(BonusSingleClass[] b)
        {
            BonusSingleClass spawnBon;
            if (b != null)
            {
                spawnBon = b[Random.Range(0, b.Length)];
            }
            else
            {
                throw new DataException($"Bonuses in is not found");
            }
            return spawnBon;
        }
    }
}