using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    public float tankStartingSpeed = 12f;
    public float tankStartingHealth = 100f;
    public float level1TotalStars = 3;
    public float level2TotalStars = 5;
    public float level3TotalStars = 7;
}