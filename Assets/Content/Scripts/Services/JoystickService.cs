using UnityEngine;
namespace Content.Scripts.Services
{
    public class JoystickService : MonoBehaviour
    {
        public Vector2 DirectionInput => joystickInput.Direction;
        public Vector2 DirectionLook => joystickLook.Direction;

        [SerializeField] private Joystick joystickInput;
        [SerializeField] private Joystick joystickLook;
       
    }
}
