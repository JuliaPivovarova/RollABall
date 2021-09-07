using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Code.BonusCode
{
    public class BonusSpawn: ICreateBonuses, IRandomPosition
    {
        public static Dictionary<int, BonusSingleClass> _bonusList = new Dictionary<int, BonusSingleClass>();
        public static int[] Length;
        private DataBonus _dataBonus = new DataBonus();
        private InstantiateBonus _instantiateBonus;
        private static BonusSingleClass spawnBon;

        public void CreateB()
        {
            BonusSingleClass instanceBonus = new BonusSingleClass();
            Length = new int[_dataBonus.SpawnPointsG().Length + _dataBonus.SpawnPointsB().Length];
            for (int i = 0; i < _dataBonus.SpawnPointsG().Length; i++)
            {
                var randomBonus = RandomP(_dataBonus.BonG);
                var obj = InstantiateBonus.InstBon(randomBonus.ComplitBonus, _dataBonus.SpawnPointsG()[i]);
                instanceBonus.ComplitBonus = obj;
                    
                //instanceBonus.ComplitBonus = Instantiate(randomBonus.ConstructBonus(), randomBonus.Position.position,
                //    randomBonus.Position.rotation);
                instanceBonus.Interecteble = randomBonus.Interecteble;
                instanceBonus.BonusDo = randomBonus.BonusDo;
                instanceBonus.Good = randomBonus.Good;
                instanceBonus.Material = randomBonus.Material;
                instanceBonus.BasicForm = randomBonus.BasicForm;
                instanceBonus.Position = _dataBonus.SpawnPointsG()[i];
                instanceBonus.ComplitBonus.SetActive(true);
                _bonusList.Add(i, instanceBonus);
                Length[i] = i;
            }

            for (int i = 0; i < _dataBonus.SpawnPointsB().Length; i++)
            {
                var randomBonus = RandomP(_dataBonus.BonB);
                instanceBonus.ComplitBonus = InstantiateBonus.InstBon(randomBonus.ComplitBonus, _dataBonus.SpawnPointsB()[i]);
                //instanceBonus.ComplitBonus = Instantiate(randomBonus.ConstructBonus(), randomBonus.Position.position,
                //    randomBonus.Position.rotation);
                instanceBonus.Interecteble = randomBonus.Interecteble;
                instanceBonus.BonusDo = randomBonus.BonusDo;
                instanceBonus.Good = randomBonus.Good;
                instanceBonus.Material = randomBonus.Material;
                instanceBonus.BasicForm = randomBonus.BasicForm;
                instanceBonus.Position = _dataBonus.SpawnPointsB()[i];
                instanceBonus.ComplitBonus.SetActive(true);
                _bonusList.Add(i + _dataBonus.SpawnPointsG().Length, instanceBonus);
            }
        }

        public BonusSingleClass RandomP(BonusSingleClass[] b)
        {
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