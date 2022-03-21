using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rb;

    private Vector3 startPosition;
    private Vector3 EndPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            EndPosition = Input.mousePosition;

            float torque = EndPosition.x * Time.deltaTime * -_rotateSpeed;

            _rb.MoveRotation(transform.rotation * Quaternion.Euler(transform.rotation.x, transform.rotation.y + torque, transform.rotation.z));
        }
    }

    private void RBMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            print(touch);

            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * -_rotateSpeed;

                _rb.MoveRotation(transform.rotation * Quaternion.Euler(transform.rotation.x, torque, transform.rotation.z));
                //_rb.AddTorque(Vector3.up * torque);
            }
        }
    }
}
