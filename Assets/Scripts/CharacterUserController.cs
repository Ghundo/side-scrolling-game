using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Character))]
public class CharacterUserController : MonoBehaviour {

    private Character character;
    private Transform cam;
    private Vector3 camForward;
    private Vector3 move;
    private bool jump;

    private void Start() {
        if (Camera.main != null) {
            cam = Camera.main.transform;
        } else {
            Debug.LogWarning("Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", "
                           + "for camera-relative controls.", gameObject);
        }

        character = GetComponent<Character>();
    }

    private void Update() {
        if (!jump) {
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate() {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        bool crouch = Input.GetKey(KeyCode.C);

        // Calculate move direction to pass to character.
        if (cam != null) {
            // Calculate camera relative direction to move.
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = v * camForward + h * cam.right;
        } else {
            // Use world-relative directions in the case of no main camera.
            move = v * Vector3.forward + h * Vector3.right;
        }
#if !MOBILE_INPUT
        if (Input.GetKey(KeyCode.LeftShift)) move *= 0.5f;
#endif
        character.Move(move, crouch, jump);
        jump = false;
    }
}
