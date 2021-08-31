using System.Data;
using System.IO;
using Code.BonusCode;
using UnityEngine;

namespace Code.SaveLoad
{
    public sealed class SaveDataRepository: ISaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;
        private BonusSpawn dic;
        private int[] keysDic;
        private string[] bonusesStr;
        private BonusToSave b;
        private DataBonus dataB;

        private int[] GetKeys()
        {
            foreach (var pair in dic._bonusList)
            {
                keysDic[pair.Key] = pair.Key;
            }

            return keysDic;
        }

        private void SetBonuses(string[] bon)
        {
            for (int i = 0; i < bon.Length; i++)
            {
                string[] parts = bon[i].Split(' ');
                Vector3 pos = default;
                for (int j = 0; j < parts.Length; j++)
                {
                    if (j == 1)
                    {
                        pos.x = float.Parse(parts[i]);
                    }

                    if (j == 3)
                    {
                        pos.y = float.Parse(parts[j]);
                    }
                    if (j == 5)
                    {
                        pos.z = float.Parse(parts[j]);
                    }
                    if (j == 7)
                    {
                        dic._bonusList[i].Interecteble = bool.Parse(parts[j]);
                    }
                    if (j == 9)
                    {
                        dic._bonusList[i].Good = bool.Parse(parts[j]);
                    }
                    if (j == 11)
                    {
                        dic._bonusList[i].BonusDo = parts[j];
                    }
                    dic._bonusList[i].Position.position = pos;

                    if (dic._bonusList[i].Good)
                    {
                        for (int k = 0; k < dataB.BonG.Length; k++)
                        {
                            if (dataB.BonG[k].BonusDo.Equals(dic._bonusList[i].BonusDo))
                            {
                                dic._bonusList[i].ComplitBonus = dataB.BonG[k].ComplitBonus;
                                dic._bonusList[i].BasicForm = dataB.BonG[k].BasicForm;
                                dic._bonusList[i].Material = dataB.BonG[k].Material;
                                dic._bonusList[i].ComplitBonus = dataB.BonG[k].ComplitBonus;
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dataB.BonB.Length; k++)
                        {
                            if (dataB.BonB[k].BonusDo.Equals(dic._bonusList[i].BonusDo))
                            {
                                dic._bonusList[i].ComplitBonus = dataB.BonB[k].ComplitBonus;
                                dic._bonusList[i].BasicForm = dataB.BonB[k].BasicForm;
                                dic._bonusList[i].Material = dataB.BonB[k].Material;
                                dic._bonusList[i].ComplitBonus = dataB.BonB[k].ComplitBonus;
                            }
                        }
                    }
                }
            }
        }

        private string[] GetBonuses()
        {
            BonusSingleClass bonus;
            foreach (var pair in dic._bonusList)
            {
                bonus = pair.Value;
                bonusesStr[pair.Key] = b.ToSave(bonus);
            }

            return bonusesStr;
        }

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new SerializableXMLData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(RollaBall.Player.PlayerBall player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            int[] keyd = GetKeys();
            string[] bon = GetBonuses();
            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = "Julia",
                IsEnabled = true,
                KeyDictionary = keyd,
                Bonus = bon
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
            Debug.Log("Save");
        }

        public void Load(RollaBall.Player.PlayerBall player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new DataException($"File {file} not found");
            }
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);
            SetBonuses(newPlayer.Bonus);

            Debug.Log(newPlayer);
        }
    }
}