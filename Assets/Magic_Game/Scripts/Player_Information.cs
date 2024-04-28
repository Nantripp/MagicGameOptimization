using System;
using UnityEngine;
[Serializable]
public class Player_Information : MonoBehaviour
{
    [TextArea(2,6)]
    public string Description;

    public int PlayerHealth = 50;
    public int PlayerArmor = 0;  

    
  
}
