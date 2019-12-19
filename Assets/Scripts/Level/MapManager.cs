using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapManager : MonoBehaviour
{
   public NavMeshSurface navMeshSurface; 

   void Awake()
   {
      Init();
   }

   public void Init()
   {
      navMeshSurface.BuildNavMesh();
   }

}
