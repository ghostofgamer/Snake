using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SurfaceSlide _surfaceSlide;

    private float _speed = 15;
    private Rigidbody _rigidbody;
    private Player _player;

    private List<Vector3> _positionHistory = new List<Vector3>();
    private int _gap = 15;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {

        Vector3 directionAlongSurface = _surfaceSlide.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
        TalesMovement();
    }

    public void Rotation(Vector3 rotation)
    {
        transform.rotation = Quaternion.LookRotation(rotation);
    }

    private void TalesMovement()
    {
        _positionHistory.Insert(0, transform.position);
        int index = 0;

        foreach (var tail in _player.Tails)
        {
            Vector3 point = _positionHistory[Mathf.Min(index * _gap, _positionHistory.Count - 1)];
            Vector3 moveDirection = point - tail.transform.position;
            tail.transform.position += moveDirection * 15 * Time.deltaTime;
            tail.transform.LookAt(point);
            index++;
        }
    }
}
