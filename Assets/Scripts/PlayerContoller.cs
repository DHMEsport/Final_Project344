using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerContoller : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _walkSpeed = 10;
    [SerializeField] private float _TurnMove = 10;
    private Vector3 _input;
    private Vector3 move;

    [SerializeField] GameObject Player;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Look();
        GatherInput();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Player.transform.position = transform.position + Vector3.forward * _walkSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Player.transform.position = transform.position + Vector3.back * _walkSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.position = transform.position + Vector3.left * _walkSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Player.transform.position = transform.position + Vector3.right * _walkSpeed * Time.deltaTime;

        }
        
    }
    void Look()
    {
        if (_input != Vector3.zero)
        {
            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _TurnMove );
        }
    }
    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

}