using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CientificoScript : MonoBehaviour
{
    public NavMeshAgent cientifico;
    public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("CientificoCorre").transform;;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
