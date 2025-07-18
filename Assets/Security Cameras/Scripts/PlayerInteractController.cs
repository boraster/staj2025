using System;
using UnityEngine;

namespace Security_Cameras.Scripts
{
    public class PlayerInteractController : MonoBehaviour
    {
        [SerializeField] private float interactDistance = 3f;
        [SerializeField] private float sphereRadius = 3f;
        [SerializeField] private LayerMask interactionLayer;
        
        private BaseInteractObject _currentInteractable;

        private void OnEnable()
        {
            InputEvents.Instance.OnInteract += OnInteract;
        }

        private void OnInteract()
        {
            if (_currentInteractable)
            {
                _currentInteractable.Interact();
            }
        }

        private void OnDisable()
        {
            InputEvents.Instance.OnInteract -= OnInteract;
        }

        private void Start()
        {
            InvokeRepeating(nameof(CheckForInteractable), 0f, 0.2f);
        }

        private void CheckForInteractable()
        {
            Collider[] hits = 
                Physics.OverlapSphere(ConstUtilities.MainCamera.transform.position + 
                    ConstUtilities.MainCamera.transform.forward * interactDistance,
                    sphereRadius, interactionLayer);

            foreach (var hit in hits)
            {
                if (!hit.TryGetComponent(out BaseInteractObject interactable)) continue;
                
                _currentInteractable = interactable;
                _currentInteractable.SetInteractionIcon(true);
                return;
            }
            
            ClearCurrentInteractable();
        }

        private void ClearCurrentInteractable()
        {
            if (_currentInteractable)
                _currentInteractable.SetInteractionIcon(false);
            
            _currentInteractable = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(ConstUtilities.MainCamera.transform.position + ConstUtilities.MainCamera.transform.forward * interactDistance, sphereRadius);
        }
    }
}
