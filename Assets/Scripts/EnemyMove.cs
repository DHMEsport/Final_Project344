using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{   
  [SerializeField] private float lookRadius;
  [SerializeField] private float speed;
  [SerializeField] private Transform target;
  [SerializeField] private float minimumdistance;
  private NavMeshAgent _navMeshAgent;

  private void Awake()
  {
    _navMeshAgent = GetComponent<NavMeshAgent>();

    _navMeshAgent.autoBraking = false;
  }

 

  private void Update()
  {
    
    float distance = Vector3.Distance(target.position, transform.position);
    if (Vector3.Distance(transform.position,target.position)>minimumdistance)
    {
      if (distance <= lookRadius)
      {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // _navMeshAgent.destination = target.position;
      }
    }
  }
  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position,lookRadius);
  }
}

