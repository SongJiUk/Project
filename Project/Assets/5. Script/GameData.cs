using UnityEngine;


[CreateAssetMenu(fileName = "NewGameData", menuName = "Custom/Game Data", order = 1)]
public class GameData : ScriptableObject
{
    public PlayerJobs playerjob;
    public EquipmentType equipmentType;
    public int equipmentNum;
    public string equipmentName;
    public int equipmentLevel;
    public float damage;
    public float defense;
}