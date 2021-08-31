﻿using System;
using System.Data;
using UnityEngine;

namespace Code.BonusCode
{
    [Serializable]
    public class BonusSingleClass
    {
        public GameObject BasicForm;
        public Transform Position;
        public Material Material;
        public bool Interecteble;
        public bool Good;
        public string BonusDo;
        public GameObject ComplitBonus;

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
                ComplitBonus.AddComponent<FlagInterection>();
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
                ComplitBonus.AddComponent<FlagInterection>();
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
                ComplitBonus.AddComponent<FlagInterection>();
            }
            else
            {
                throw new DataException($"Gameobject in {BasicForm} is not found");
            }

            return ComplitBonus;
        }
    }
}