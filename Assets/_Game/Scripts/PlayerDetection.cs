using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Collider[] _collider;
    [SerializeField] private float radius = 3f;
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioSource _detectionSound;
    private int _audioDetectionCounter = 0;

    private void Update()
    {
        _collider = Physics.OverlapSphere
            (gameObject.transform.position, radius);
        foreach(Collider collider in _collider)
        {
            Debug.Log(collider);
            if(collider.gameObject.GetComponent<UseShoot>())
            {
                Debug.Log("Player Detection");
                if(_audioDetectionCounter == 0)
                {
                    AudioSource newSound = Instantiate(_detectionSound,
                    transform.position, Quaternion.identity);
                    Destroy(newSound.gameObject, _detectionSound.clip.length);
                    Debug.Log("Destroy Detection Sound");
                    _audioDetectionCounter += 1;
                }
                transform.LookAt(_camera.transform.position);
            }
            if(collider == null)
            {
                Debug.Log("empty");
                _audioDetectionCounter = 0;
            }
        }

    }
}
