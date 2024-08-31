using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement {
    public string id;
    public string title;
    public string description;
    public AchievementTier tier; // New property
}

public enum AchievementTier {
    Bronze,
    Silver,
    Gold
}

