using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UseShoot : MonoBehaviour
{

    [SerializeField] private LayerMask _layersToShoot = -1;
    [SerializeField] private float _shootDistance = 30;
    [SerializeField] private Camera _camera;

    [SerializeField] private ParticleSystem _impactParticle;
    [SerializeField] private ParticleSystem _damageParticle;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private AudioSource _damageSound;

    private int _damageAmount = 1;

    public void OnShoot(InputValue value)
    {
        if(value.isPressed)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 rayStartPos = _camera.transform.position;
        Vector3 rayDirection = _camera.transform.forward;
        Debug.DrawRay(rayStartPos, rayDirection * _shootDistance,
            Color.cyan, 1);
        RaycastHit hitInfo;
        if(Physics.Raycast(rayStartPos, rayDirection, out hitInfo,
            _shootDistance, _layersToShoot))
        {
            Health enemyHealth =
                    hitInfo.transform.GetComponent<Health>();
            if(enemyHealth != null)
            {
                if(_damageParticle != null)
                {
                    Instantiate(_damageParticle,
                        hitInfo.point, Quaternion.identity);
                }
                if (_shootSound != null && _damageSound != null)
                {
                    AudioSource newSound = Instantiate(_shootSound,
                        transform.position, Quaternion.identity);
                    AudioSource secondSound = Instantiate(_damageSound,
                        transform.position, Quaternion.identity);
                    Destroy(newSound.gameObject, newSound.clip.length);
                    Destroy(secondSound.gameObject, secondSound.clip.length);
                }
            }
            else
            {
                if (_impactParticle != null)
                {
                    Instantiate(_impactParticle,
                        hitInfo.point, Quaternion.identity);
                }
                if (_shootSound != null)
                {
                    AudioSource newSound = Instantiate(_shootSound,
                        transform.position, Quaternion.identity);
                    Destroy(newSound.gameObject, newSound.clip.length);
                }
            }
            Shootable shootableObject =
                hitInfo.transform.GetComponent<Shootable>();
            if(shootableObject != null)
            {
                shootableObject.Shoot(_damageAmount);
            }
        }
    }
}
