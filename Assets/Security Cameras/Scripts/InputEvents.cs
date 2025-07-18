using UnityEngine;
using UnityEngine.Events;

namespace Security_Cameras.Scripts
{
    public class InputEvents : MonoBehaviour
    {
        public static InputEvents Instance;

        public UnityAction OnInteract;
        
        private void Awake()
        {
            Instance = this;
        }
    }
}