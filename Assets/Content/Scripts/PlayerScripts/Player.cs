using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerSound playerSound;
        private void Update()
        {
            playerMovement.Movement();
            playerMovement.Rotation();
        }

       
    }
}