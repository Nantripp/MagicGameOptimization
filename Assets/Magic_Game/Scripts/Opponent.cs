using System;
using UnityEngine;
[Serializable]

public class Opponent : MonoBehaviour
{
    public string EnemyName;

    [TextArea(2,6)]
    public string Description;

    public int HP;
    public int Enemy_Armor;
}
