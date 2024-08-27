using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaycastBase : MonoBehaviour
{
    [Header("Raycast Properties")]
    [SerializeField] protected LayerMask LayerTargets;
    [SerializeField] protected float RayDistance;
    [SerializeField] protected Vector3 OriginPoint;

    [Header("Pivot Points")]
    [SerializeField] protected Transform OriginPivot;

    [Header("Draw Raw Properties")]
    [SerializeField] protected Color IsCollisionColor;
    [SerializeField] protected Color NoCollisionColor;
    [SerializeField] protected Vector3 CollisionPoint;
    [SerializeField] protected bool HasCollide = false;

    protected virtual void Start()
    {
        HasCollide = false;
        Debug.Log("From Father");

        if (OriginPivot == null)
        {
            OriginPivot = transform;
        }
    }
    protected virtual void Update()
    {
        OriginPoint = OriginPivot.position;
    }
    protected void DrawRayPoint()
    {
        if (HasCollide)
            Debug.DrawRay(OriginPoint, CollisionPoint, IsCollisionColor);
        else Debug.DrawRay(OriginPoint, CollisionPoint, NoCollisionColor);
    }
}
