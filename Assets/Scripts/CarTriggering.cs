using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarTriggering : MonoBehaviour
{
    [SerializeField] UnityEvent _signalizationAlert;
    [SerializeField] UnityEvent _signalizationAlertOff;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enter. " + other.name + " " + other.gameObject.tag);

        if (other.gameObject.GetComponent<Car>())
        {
            _signalizationAlert?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Car>())
        {
            _signalizationAlertOff?.Invoke();
        }
    }
}
