using UnityEngine;

namespace Security_Cameras.Scripts
{
    public abstract class BaseInteractObject : MonoBehaviour
    {
        [SerializeField] private Canvas interactionIconCanvas;

        public abstract void Interact();

        public virtual void SetInteractionIcon(bool show) // Could be animate
        {
            interactionIconCanvas.enabled = show;
        }
    }
}