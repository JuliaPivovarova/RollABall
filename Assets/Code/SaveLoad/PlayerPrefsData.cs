using Code.BonusCode;
using UnityEngine;
using System.Xml;
using Code.Interfaces_and_Markers;

namespace Code.SaveLoad
{
    public class PlayerPrefsData: IData<SavedData>
    {
        private DataBonus length;
        
        public void Save(SavedData data, string path = null)
        {
            PlayerPrefs.SetString("Name", data.Name);
            PlayerPrefs.SetFloat("PosX", data.Position.X);
            PlayerPrefs.SetFloat("PosY", data.Position.Y);
            PlayerPrefs.SetFloat("PosZ", data.Position.Z);
            PlayerPrefs.SetString("IsEnable", data.IsEnabled.ToString());
            for (int i = 0; i < data.KeyDictionary.Length; i++)
            {
                PlayerPrefs.SetInt($"KeyDictionary{i}", data.KeyDictionary[i]);
            }

            for (int i = 0; i < data.Bonus.Length; i++)
            {
                PlayerPrefs.SetString($"Bonus{i}", data.Bonus[i]);
            }

            PlayerPrefs.Save();
        }

        public SavedData Load(string path = null)
        {
            var result = new SavedData();

            var key = "Name";
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }

            key = "PosX";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }

            key = "PosY";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Y= PlayerPrefs.GetFloat(key);
            }

            key = "PosZ";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Z = PlayerPrefs.GetFloat(key);
            }

            key = "IsEnable";
            if (PlayerPrefs.HasKey(key))
            {
                 bool.TryParse(PlayerPrefs.GetString(key), out result.IsEnabled);  //TryBool();
            }

            
            for (int i = 0; i < length.SpawnBonusSum; i++)
            {
                key = $"KeyDictionary{i}";
                if (PlayerPrefs.HasKey(key))
                {
                    result.KeyDictionary[i] = PlayerPrefs.GetInt(key);
                }
            }
            
            for (int i = 0; i < length.SpawnBonusSum; i++)
            {
                key = $"Bonus{i}";
                if (PlayerPrefs.HasKey(key))
                {
                    result.Bonus[i] = PlayerPrefs.GetString(key);
                }
            }
            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.DeleteKey("IsEnable");
        }
    }
}