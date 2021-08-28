
using UnityEngine;

/// <summary>
/// Rotate object axis.z
/// </summary>
public class RotateBase : MonoBehaviour,IRotatable<float>
{
    [SerializeField,Range(0,60)] private float _angleSpeed;
    private float _direction;

    /// <summary>
    /// Use 1 or -1 to set direction
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(float direction)
    {
        _direction = direction;
    }


    void Update()
    {
        if(_direction!=0)
            this.transform.Rotate(Vector3.up, _direction*_angleSpeed * Time.deltaTime);
    }
}
