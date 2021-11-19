using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Object : MonoBehaviour
{
    [SerializeField] ParticleSystem Dirt_Death;
    [SerializeField] ParticleSystem Dirt_Score;
    [SerializeField] float add_Score = 10;

    [System.NonSerialized] public Level_Manager man;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Water")
        {
            Instantiate(Dirt_Death.gameObject, this.transform.position, Quaternion.identity);
            Instantiate(Dirt_Score.gameObject, this.transform.position, Dirt_Score.transform.rotation);
            man.Add_Score(add_Score);
            Destroy(this.gameObject);
        }
    }

}
