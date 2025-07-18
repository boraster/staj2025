using UnityEngine;
using UnityEngine.InputSystem;

namespace Security_Cameras.Scripts
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActions;
        
        private InputAction _interactAction;
        
        private void OnEnable()
        {
            _interactAction = inputActions.FindActionMap("Player").FindAction("Interact");
            
            _interactAction.Enable();
            _interactAction.performed += OnInteract;
        }

        private void OnInteract(InputAction.CallbackContext obj)
        {
            InputEvents.Instance.OnInteract?.Invoke();
        }

        private void OnDisable()
        {
            _interactAction.performed -= OnInteract;
            _interactAction.Disable();
        }
    }
}
