
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
public class Settings : ScriptableObject, IComplexity, IBallSettings
{
    [SerializeField] private float _ballSpeed;
    [SerializeField] private Complexity _complexity;

    public float BallSpeed => _ballSpeed;
    public Complexity Complexity => _complexity;
}
