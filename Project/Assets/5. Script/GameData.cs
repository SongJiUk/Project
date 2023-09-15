using UnityEngine;
public enum EquipmentType
{
    Hand,
    Dagger,
    OneHandMace,
    TwoHandSword,
    Axe,
    Spear,
    Shield,
    Bow,
    Staff
}

public enum WeaponType
{

}

[CreateAssetMenu(fileName = "NewGameData", menuName = "Custom/Game Data", order = 1)]
public class GameData : ScriptableObject
{ 
    public EquipmentType equipmentType;
    public int equipmentNum;
    public string equipmentName;
    public int equipmentLevel;
    public float damage;
    public float defense;

}