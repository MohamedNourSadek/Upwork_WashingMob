using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX; 

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float Depth = 6;
    [SerializeField] float VolumeMax = 0.7f;
    [SerializeField] float Volume_Change_Speed = 2f;

    [Header("References")]
    [SerializeField] GameObject testobject;
    [SerializeField] GameObject WaterHoes;
    [SerializeField] ParticleSystem waterVfx;
    [SerializeField] GameObject waterOjbect;
    Camera cam;
    AudioSource water_Audio;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        water_Audio = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            waterOjbect.SetActive(true);
            waterVfx.Play();
            water_Audio.volume = Mathf.Clamp((water_Audio.volume + Volume_Change_Speed * Time.fixedDeltaTime), 0f, VolumeMax);

            Touch t = Input.GetTouch(0);
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, Depth));
            testobject.transform.position = point;
            WaterHoes.transform.LookAt(point);


        }
        else
        {
            waterOjbect.SetActive(false);
            waterVfx.Stop();
            water_Audio.volume = Mathf.Clamp((water_Audio.volume - Volume_Change_Speed * Time.fixedDeltaTime), 0f, VolumeMax);
        }
    }
}
