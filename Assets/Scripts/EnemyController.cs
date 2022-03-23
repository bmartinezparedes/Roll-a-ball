using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target; 
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(target.position);
        Debug.Log(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = new Vector3(10, 1, 0);
            other.transform.position = new Vector3(0, 1, 0);
        }
        
        
    }
}
