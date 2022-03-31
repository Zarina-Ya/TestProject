using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{

    public void OnHit()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 500f);

    }
}


