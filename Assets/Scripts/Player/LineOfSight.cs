using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
        public LineRenderer lineRenderer;
        public Transform start, end; 
        public Player player;
    
        private Camera cam; 
        private LayerMask layerMask = ~(1 << 2);
        private InteractableObject currentHoveredObject;

        public void Awake()
        {
            cam = Camera.main; 
        } 
        public void Look()
        {
            if(Input.GetMouseButton(2))
            {
                lineRenderer.SetPosition(1, end.transform.localPosition);
            }
            else
            {
                lineRenderer.SetPosition(1, Vector3.zero);
            }
            InteractableObjectHighlight(); 
        }

        private void HoverObject(Transform obj)
        {
            InteractableObject interactableObject = obj.GetComponent<InteractableObject>();
            if(!interactableObject) return;

            currentHoveredObject = interactableObject;  
            // interactableObject.Hover();
        }
        private void UnhoverObject()
        {
            if(!currentHoveredObject) return;
            // currentHoveredObject.Unhover();
            currentHoveredObject = null;
        }

        private void InteractableObjectHighlight()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
            {
                if(UIManager.Instance.WordUICheck()) return; 
                if(currentHoveredObject && currentHoveredObject.transform != hit.transform)
                {
                    UnhoverObject();
                }
                if(hit.transform.CompareTag(Consts.TAG_INTERACTABLE_OBJECT))
                {
                    HoverObject(hit.transform);
                    return;
                }
            }
        }
}
