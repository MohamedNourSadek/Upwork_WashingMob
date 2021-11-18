using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    
    private void FixedUpdate()
    {
        this.transform.Rotate(Vector2.up * speed);
    }
}
