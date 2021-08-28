
using UnityEngine;

/// <summary>
/// Create LineRender using Raycast checking IReflectable to change direction
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class RayReflector : MonoBehaviour
{
    [SerializeField,Range(0,50)] private float _reflect;
    [SerializeField,Range(0,50)] private float _maxLenght;

    private LineRenderer _line;
    private float _reflectable;
    private float _remainingLenght;
    private Ray _ray;
    private RaycastHit _rayCastHit;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();

    }

    private void Update()
    {
        _reflectable = _reflect;
        _remainingLenght = _maxLenght;
        _ray = new Ray(transform.position, transform.up);
        _line.positionCount = 1;
        _line.SetPosition(0, transform.position);

        while (_reflectable > 0)
        {
            if (Physics.Raycast(_ray.origin, _ray.direction, out _rayCastHit, _remainingLenght))
            {
                if (_rayCastHit.collider.TryGetComponent(out IReflectable mirror))
                {
                    _reflectable -= mirror.Reflection;
                    _line.positionCount += 1;
                    _line.SetPosition(_line.positionCount - 1, _rayCastHit.point);
                    _remainingLenght -= Vector3.Distance(_ray.origin, _rayCastHit.point);
                    _ray = new Ray(_rayCastHit.point, Vector3.Reflect(_ray.direction, _rayCastHit.normal));
                    Debug.Log(_reflectable);
                }
                else
                {
                    _line.positionCount += 1;
                    _line.SetPosition(_line.positionCount - 1, _rayCastHit.point);
                    break;
                }
            }
            else
            {
                _line.positionCount += 1;
                _line.SetPosition(_line.positionCount - 1, _ray.origin + _ray.direction * _remainingLenght);
                break;
            }
        }
    }
}
