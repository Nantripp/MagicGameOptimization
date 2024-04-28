using System;
using UnityEngine;
[Serializable]

public class Card : MonoBehaviour
{
    public string CardName;

    [TextArea(2,6)]
    public string Description;

    public int Damage;

    public int Guard;


}
