using System;
using System.Data;
using UnityEngine;

namespace Code.BonusCode
{
    [Serializable]
    public class BonusSingleClass
    {
        public GameObject BasicForm = null;
        public Transform Position = null;
        public Material Material = null;
        public bool Interecteble = true;
        public bool Good;
        public string BonusDo = "";
        public GameObject ComplitBonus = null;

        public GameObject ConstructBonus()
        {
            if (BasicForm != null)
            {
                ComplitBonus = BasicForm;
                if (ComplitBonus.TryGetComponent<MeshRenderer>(out var m))
                {
                    m.material = Material;
                }
                else
                {
                    ComplitBonus.AddComponent<MeshRenderer>().material = Material;
                }
                ComplitBonus.transform.position = Position.position;
                ComplitBonus.transform.rotation = Position.rotation;
            }
            else
            {
                throw new DataException($"Gameobject in {BasicForm} is not found");
            }

            return ComplitBonus;
        }

        public GameObject ConstructBonus(Material mat)
        {
            if (BasicForm != null)
            {
                ComplitBonus = BasicForm;
                if (ComplitBonus.TryGetComponent<MeshRenderer>(out var m))
                {
                    m.material = mat;
                }
                else
                {
                    ComplitBonus.AddComponent<MeshRenderer>().material = mat;
                }
                ComplitBonus.transform.position = Position.position;
                ComplitBonus.transform.rotation = Position.rotation;
            }
            else
            {
                throw new DataException($"Gameobject in {BasicForm} is not found");
            }

            return ComplitBonus;
        }

        public GameObject ConstructBonus(Material mat, Transform pos)
        {
            if (BasicForm != null)
            {
                ComplitBonus = BasicForm;
                if (ComplitBonus.TryGetComponent<MeshRenderer>(out var m))
                {
                    m.material = mat;
                }
                else
                {
                    ComplitBonus.AddComponent<MeshRenderer>().material = mat;
                }
                ComplitBonus.transform.position = pos.position;
                ComplitBonus.transform.rotation = pos.rotation;
            }
            else
            {
                throw new DataException($"Gameobject in {BasicForm} is not found");
            }

            return ComplitBonus;
        }
    }
}