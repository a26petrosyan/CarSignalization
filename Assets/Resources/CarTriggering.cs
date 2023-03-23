using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTriggering : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _increaseVolumeSpeed = 0.1f;
    [SerializeField] float _decreaseVolumeSpeed = 0.2f;

    private bool isEntered = false;

    private void Update()
    {
        if (isEntered)
        {
            if(_audioSource.volume == 0)
                _audioSource.Play();

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, _increaseVolumeSpeed * Time.deltaTime);
        }
        else
        if (_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _decreaseVolumeSpeed * Time.deltaTime);
        }
        else
        {
            _audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter. " + other.name + " " + other.gameObject.tag);

        if (other.gameObject.tag == "Car")
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            isEntered = false;
        }
    }

}
