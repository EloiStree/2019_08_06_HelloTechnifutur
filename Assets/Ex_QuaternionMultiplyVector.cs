using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_QuaternionMultiplyVector : MonoBehaviour
{

    public Vector3 m_direction;
    public Vector3 m_euleurAngle;
    public Quaternion m_rotation;
    public Vector3 m_newDirection;
    public Transform m_affected;

    void OnValidate()
    {
        m_rotation = Quaternion.Euler(m_euleurAngle);
        m_newDirection = m_rotation * m_direction;


        m_affected.forward = m_newDirection;


    }
}
