using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] private int healup = 50;
    private GameContoller gc;
    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            gc = go.GetComponent<GameContoller>();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            gc.UpdateHeal(+healup);
            gc.UpdateLive(0);
            Destroy(Box.gameObject);
            Debug.Log("HIT");
        }
    }
}
