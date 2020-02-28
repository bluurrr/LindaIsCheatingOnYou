using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class MapManager : MonoBehaviour
{
   public NavMeshSurface navMeshSurface; 
   public List<InteractableObject> interactables;

   void Awake()
   {
      Init();
   }

   public void Init()
   {
      navMeshSurface.BuildNavMesh();
      interactables = GameObject.FindObjectsOfType<InteractableObject>().ToList();
   }

}
