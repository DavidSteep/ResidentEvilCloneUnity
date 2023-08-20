using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitchScript : MonoBehaviour
{
    public CinemachineVirtualCamera activeCam;

    private void Awake()
    {
        activeCam.Priority = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(transform.name + " camera on enter triggered");
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Player entered");
            activeCam.Priority = 1;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(transform.name + " camera on exit triggered");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player exited");
            activeCam.Priority = 0;
        }

    }
}
