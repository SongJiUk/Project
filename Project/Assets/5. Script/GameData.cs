using UnityEngine;
public enum EquipmentType
{
    Sword,
    Shield,
}

[CreateAssetMenu(fileName = "NewGameData", menuName = "Custom/Game Data", order = 1)]
public class GameData : ScriptableObject
{
    public EquipmentType equipmentType;


    public string equipmentName;
    public int equipmentLevel;
    public int damage;
    public int defense;

}