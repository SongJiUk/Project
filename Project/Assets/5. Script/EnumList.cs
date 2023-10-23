using System;

[Serializable]
public enum UnitCode
{
    WARRIOR = 0,
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
public enum EffectCastType
{
    None,
    Front,
    PreCast
}

public enum DataType
{
    Quest,
    Enemy
}

[Serializable]
public enum EGender
{
    Female,
    male
}

[Serializable]
public enum EquipmmentGender
{
    Female = 0,
    male,
    Public
}

