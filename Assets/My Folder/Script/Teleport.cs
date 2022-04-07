using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] private static bool _isOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _isOpen)
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }

    public static void OpenTeleport()
    {
        _isOpen = true;
    }
}
