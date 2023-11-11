using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _positionStrenght;
    [SerializeField] private Vector3 _rotationStrenght;


    private static event Action Shake;

    public static void Invoke()
    {
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShaker;
    private void OnDisable() => Shake -= CameraShaker;

    private void CameraShaker()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(0.3f, _positionStrenght);
        _camera.DOShakeRotation(0.3f, _rotationStrenght);
    }
}

