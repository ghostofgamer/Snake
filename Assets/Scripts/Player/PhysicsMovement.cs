using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlide _surfaceSlide;
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSlide.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    public void Rotation(Vector3 rotation)
    {
        transform.rotation = Quaternion.LookRotation(rotation);
    }
}
