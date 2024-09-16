using System;
using UnityEngine;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerMovement 
    {
        [SerializeField] private float walkSpeed = 1f;
        [SerializeField] private float sprintSpeed = 1.5f;
        [SerializeField] private float mouseSensitivity = 2f;
        [SerializeField] private float upDownRange = 80f;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform cameraHandler;
        [SerializeField] private Transform transformPlayer;
        private float verticalRotation;
        
        public void Movement()
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            float vertical = Input.GetAxis("Vertical") * speed;
            float horizontal = Input.GetAxis("Horizontal") * speed;

            Vector3 dir = new Vector3(horizontal, 0f, vertical);
            dir = transformPlayer.rotation * dir;
            characterController.SimpleMove(dir);
        }

        public void Rotation()
        {
            float mouseXRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
            transformPlayer.Rotate(0f,mouseXRotation,0f);
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            cameraHandler.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);
        }
    }
}
