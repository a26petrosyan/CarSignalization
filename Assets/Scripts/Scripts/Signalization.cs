using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signalization : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _increaseVolumeSpeed = 0.1f;
    [SerializeField] float _decreaseVolumeSpeed = 0.2f;

    private Coroutine _signalization;

    public void SetOn()
    {
        if (_audioSource.isPlaying)
            return;
        else
            if(_signalization != null)
                StopCoroutine(_signalization);

        _signalization = StartCoroutine(VolumeUpSignalization());
    }

    public void SetOff()
    {
        if (_audioSource.isPlaying == false)
            return;
        else
            if (_signalization != null)
                StopCoroutine(_signalization);

        _signalization = StartCoroutine(VolumeDownSignalization());
    }

    private IEnumerator VolumeUpSignalization()
    {
        _audioSource.volume = 0;
        _audioSource.Play();

        while (_audioSource.volume < 1)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, _increaseVolumeSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator VolumeDownSignalization()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _decreaseVolumeSpeed * Time.deltaTime);

            yield return null;
        }

        _audioSource.Stop();
    }
}
