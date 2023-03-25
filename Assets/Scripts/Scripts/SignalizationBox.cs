using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalizationBox : MonoBehaviour
{
    [SerializeField] private UnityEvent _signalizationAlert;
    [SerializeField] private UnityEvent _signalizationAlertOff;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enter. " + other.name + " " + other.gameObject.tag);

        if (other.gameObject.TryGetComponent<Car>(out Car component))
        {
            _signalizationAlert?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car component))
        {
            _signalizationAlertOff?.Invoke();
        }
    }
}
