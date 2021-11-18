using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX; 

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float Depth = 6;
    [SerializeField] float Seconds_forWaterObject = 2f;

    [Header("References")]
    [SerializeField] GameObject testobject;
    [SerializeField] GameObject WaterHoes;
    [SerializeField] VisualEffect waterVfx;
    [SerializeField] GameObject waterOjbect;
    Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    float i;

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            i++; //waiting for 4 seconds
            if(i > (Seconds_forWaterObject/Time.fixedDeltaTime))
                waterOjbect.SetActive(true);
            waterVfx.SetBool("Working", true);


            Touch t = Input.GetTouch(0);
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, Depth));
            testobject.transform.position = point;
            WaterHoes.transform.LookAt(point);
        }
        else
        {
            waterOjbect.SetActive(false);
            waterVfx.SetBool("Working", false);
            i = 0;
        }
    }
}
