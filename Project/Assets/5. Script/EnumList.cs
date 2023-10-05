using System;

[Serializable]
public enum UnitCode
{
    WARRIOR,
    MAGE,
    ARCHER
}

[Serializable]
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
    CrossBow,
    Staff,
    Orb
}

[Serializable]
public enum PlayerJobs
{
    Warrior,
    Mage,
    Archer
}

[Serializable]
public enum EffectCastType
{
    None,
    Front,
    PreCast
}