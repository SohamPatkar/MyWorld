using UnityEngine;

[CreateAssetMenu(menuName = "PlayerSO")]
public class PlayerScriptableObject : ScriptableObject
{
    public int WoodAmount;
    public int StoneAmount;
    public float MovementSpeed;
}
