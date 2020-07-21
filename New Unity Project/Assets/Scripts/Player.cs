using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 m_playerDirection = new Vector3();
    private int direction = 0;
    [SerializeField]
    private int m_speed = 0;
    [SerializeField]
    private Rigidbody m_playerRigidBody = null;

    private bool m_CanJump = true;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerMovement();
        Jump();
    }

    void PlayerMovement()
    {
        m_playerDirection.x = 0;
        m_playerDirection.z = 0;

        if (Input.GetKey(KeyCode.W))
        {
            direction = 1;
            m_playerDirection.z = direction;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = -1;
            m_playerDirection.z = direction;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            m_playerDirection.x = direction;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            m_playerDirection.x = direction;
        }

        m_playerDirection.x *= m_speed;
        m_playerDirection.z *= m_speed;
        m_playerDirection.y = m_playerRigidBody.velocity.y;
        m_playerRigidBody.velocity = m_playerDirection;

        UnityEngine.Debug.Log(m_playerRigidBody.velocity);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_CanJump)
        {
            m_playerRigidBody.AddForce(0f, 200f, 0f);
            m_CanJump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == ("Ground"))
        {
            m_CanJump = true;
        }
    }
}
