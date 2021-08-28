
using UnityEngine;

/// <summary>
/// Set fron inspector reflectionCoefficient
/// </summary>
public class Mirror : MonoBehaviour, IReflectable
{
    [SerializeField, Range(0, 10)] private float _reflectionCoefficient;
    public float Reflection => _reflectionCoefficient;
}
