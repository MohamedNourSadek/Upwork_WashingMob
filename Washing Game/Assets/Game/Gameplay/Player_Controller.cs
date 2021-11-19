using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX; 

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float Depth = 6;

    [Header("References")]
    [SerializeField] GameObject testobject;
    [SerializeField] GameObject WaterHoes;
    [SerializeField] ParticleSystem waterVfx;
    [SerializeField] GameObject waterOjbect;
    Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }


    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            waterOjbect.SetActive(true);
            waterVfx.Play();


            Touch t = Input.GetTouch(0);
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, Depth));
            testobject.transform.position = point;
            WaterHoes.transform.LookAt(point);
        }
        else
        {
            waterOjbect.SetActive(false);
            waterVfx.Stop();
        }
    }
}
