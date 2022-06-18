using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterTest : MonoBehaviour
{
    public float speed = 2f;
    public void OnTriggerEnter( Collider other )
    {
        Debug.LogFormat( $"OnTriggerEnter" );
    }

    public void OnTriggerEnter2D( Collider2D other )
    {
        Debug.LogFormat( $"OnTriggerEnter2D" );
    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}