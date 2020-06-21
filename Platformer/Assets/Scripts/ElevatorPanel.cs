using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;
    [SerializeField]
    private int _coinsRequired = 8;

    private bool _elevatorCalled = false;

    private Elevator _elevator;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        if(_elevator == null)
        {
            Debug.LogError("Elevator is NULL");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(Input.GetKeyDown(KeyCode.E) && player.CoinCount() >= _coinsRequired)
            {
                if (_elevatorCalled == true)
                {
                    _callButton.material.color = Color.red;
                    _elevatorCalled = false;                   
                }
                
                else
                {
                    _callButton.material.color = Color.green;
                    _elevatorCalled = true;
                   
                }

                
                _elevator.CallElevator();
            }
        }
    }
}
