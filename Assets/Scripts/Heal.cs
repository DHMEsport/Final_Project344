using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Heal : MonoBehaviour
{
    [SerializeField] private GameObject heal;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(heal.gameObject);
            Debug.Log("HIT");
        }
    }
}
