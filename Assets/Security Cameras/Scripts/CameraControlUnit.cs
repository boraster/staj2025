using UnityEngine;

namespace Security_Cameras.Scripts
{
    public class CameraControlUnit : BaseInteractObject
    {
        [SerializeField] private MeshRenderer tvMeshRenderer;
        
        [SerializeField] private Material tvOnMaterial;
        
        public override void Interact()
        {
            tvMeshRenderer.material = tvOnMaterial;
        }
        
    }
}
