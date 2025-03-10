using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

public class Garvity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.06674f;
    public static List<Garvity> garvityObjectList;
    [SerializeField] bool planet = false;
    [SerializeField] int orbitSpeed = 1000;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (garvityObjectList == null)
        {
            garvityObjectList = new List<Garvity>();
        }
        garvityObjectList.Add(this);
        if (!planet)
        { rb.AddForce(Vector3.left * orbitSpeed); }
    }
    private void FixedUpdate()
    {
        foreach (Garvity obj in garvityObjectList) 
        {
            Attract(obj);
        }
    }
    void Attract(Garvity other)
    {
        Rigidbody rbOther = other.rb;
        Vector3 direction = rb.position - rbOther.position;
        float distance = direction.magnitude;
        if (distance == 0) { return; }
        float forceMagnitude = G * ((rb.mass * rbOther.mass) / Mathf.Pow(distance, 2));
        Vector3 force = forceMagnitude * direction.normalized;
        rbOther.AddForce(force);
    }
}
    
