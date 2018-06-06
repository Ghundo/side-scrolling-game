using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GameObject target;
    [SerializeField] private float directionOffset = 2;
    private Vector3 initOffset;
    private Vector3 playerPosition;    

    private void Start() {
        initOffset = transform.position - target.transform.position;
    }

    private void Update() {
        Vector3 targetForward = target.transform.forward;
        targetForward.y = 0;
        float targetFacing = Quaternion.LookRotation(targetForward).eulerAngles.y;
        Vector3 offset;
        Debug.Log(targetFacing);
        if (targetFacing < 180) {
            offset = initOffset + Vector3.right * directionOffset * (90 - Mathf.Abs(90 - targetFacing)) / 90;            
        } else {
            offset = initOffset + Vector3.left * directionOffset * (270 - Mathf.Abs(270 - targetFacing)) / 270;
        }
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0) + offset;
    }
}
