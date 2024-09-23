using System;
using Content.Scripts.Services;
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

        private Vector2 dirInput;
        private Vector2 dirLook;
        
        private JoystickService joystickService;
        
        public void Init(JoystickService joystickService)
        {
            this.joystickService = joystickService;
        }

        public void UpdateInput()
        {
            dirInput = joystickService.DirectionInput;
            dirLook = joystickService.DirectionLook;
        }
        
        public void Movement()
        {
            Debug.Log(dirInput);
            //float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            Vector3 dir = new Vector3(dirInput.x*walkSpeed, 0f, dirInput.y*walkSpeed);
            dir = transformPlayer.rotation * dir;
            characterController.SimpleMove(dir);
        }

        public void Rotation()
        {
            float mouseXRotation = dirLook.x * mouseSensitivity;
            transformPlayer.Rotate(0f,mouseXRotation,0f);
            verticalRotation -= dirLook.y * mouseSensitivity;
            
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            cameraHandler.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);
        }
    }
}
