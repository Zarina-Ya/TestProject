using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKey : MonoBehaviour
{
  
    [SerializeField] private int _countKey = 0;


    public void Add()
    {
       _countKey++;
        if (_countKey == 3)
        {
            Debug.Log("Teleport is open!");
            Teleport.OpenTeleport();
        }
    }
}
