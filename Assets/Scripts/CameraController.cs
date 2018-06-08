using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform target;
    private Vector3 initOffset;

    private void Start() {
        initOffset = transform.position - target.transform.position;
    }

    private void Update() {
        transform.position = target.position + initOffset;
    }
}
