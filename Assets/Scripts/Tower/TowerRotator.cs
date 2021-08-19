using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * -_rotateSpeed;

                _rb.MoveRotation(transform.rotation * Quaternion.Euler(transform.rotation.x, torque, transform.rotation.z));
                //_rb.AddTorque(Vector3.up * torque);
            }
        }
    }
}
