using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform  _targetA, _targetB;
    [SerializeField]
    private float _speed = 1f;

    private bool _isElevatorCalledDown = false;
    public void CallElevator()
    {
        _isElevatorCalledDown = !_isElevatorCalledDown;
       
    }

    private void FixedUpdate()
    {
        if(_isElevatorCalledDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }

        if(_isElevatorCalledDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
