using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private FixedJoystick _joystick;

    private void Update()
    {
        Vector3 direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        _movement.Move(direction);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            _movement.Rotation(direction);
    }
}
