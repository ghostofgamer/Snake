using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private FixedJoystick _joystick;

    private void Update()
    {
        _movement.Move(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Rotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));
        }
    }

    public void Rotation(Vector3 rotation)
    {
        transform.rotation = Quaternion.LookRotation(rotation);
    }
}
