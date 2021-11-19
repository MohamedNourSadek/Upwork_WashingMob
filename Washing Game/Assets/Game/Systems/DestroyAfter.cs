using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{

    [SerializeField] float time = 5;

    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(this.gameObject);
    }
}
