using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float lookRadius;
    [SerializeField] private float speed;
    [SerializeField] private Transform[] patrolPoint;
    [SerializeField] private float waittime;
    private int currentPointIndex;
    private int destinationPoint = 0;
    private bool once;
    private void Update()
    {
        if (transform.position != patrolPoint[currentPointIndex].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoint[currentPointIndex].position,speed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
         
        }

        destinationPoint = (destinationPoint + 1) % patrolPoint.Length;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waittime);
        if (currentPointIndex + 1 < patrolPoint.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }

        once = false;
    }
}
