using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItemController : MonoBehaviour
{
    [SerializeField] Image bronzeIcon;
    [SerializeField] Image silverIcon;
    [SerializeField] Image goldIcon;

    [SerializeField] Image unlockedIcon;
    [SerializeField] Image lockedIcon;

    [SerializeField] Text titleLabel;
    [SerializeField] Text descriptionLabel;

    public bool unlocked;
    public Achievement achievement;

    public void RefreshView()
    {
        if (achievement == null) return;

        if (titleLabel != null) titleLabel.text = achievement.title;
        if (descriptionLabel != null) descriptionLabel.text = achievement.description;

        // Handle tiered icons
        if (bronzeIcon != null) bronzeIcon.enabled = achievement.tier == AchievementTier.Bronze && unlocked;
        if (silverIcon != null) silverIcon.enabled = achievement.tier == AchievementTier.Silver && unlocked;
        if (goldIcon != null) goldIcon.enabled = achievement.tier == AchievementTier.Gold && unlocked;

        // Handle unlocked/locked icons
        if (unlockedIcon != null)
        {
            unlockedIcon.enabled = unlocked;

            // Change unlocked icon color based on tier
            if (unlocked)
            {
                switch (achievement.tier)
                {
                    case AchievementTier.Bronze:
                        unlockedIcon.color = new Color32(139, 69, 19, 255); // Brown color
                        break;
                    case AchievementTier.Silver:
                        unlockedIcon.color = Color.gray; // Gray color
                        break;
                    case AchievementTier.Gold:
                        unlockedIcon.color = new Color32(255, 165, 0, 255); // Yellow-orange color
                        break;
                }
            }
            else
            {
                // Optionally set the color to a default or gray when locked
                unlockedIcon.color = Color.clear; // Hide or set a default color for locked state
            }
        }

        if (lockedIcon != null) lockedIcon.enabled = !unlocked;
    }

    private void OnValidate()
    {
        RefreshView();
    }
}
