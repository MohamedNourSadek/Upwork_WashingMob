using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Test_Script : MonoBehaviour
{
    [SerializeField] Text ts;

    public void ChangeText()
    {
        ts.text = Random.Range(0f, 1f).ToString();
    }
}
