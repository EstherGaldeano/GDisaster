using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSight : MonoBehaviour
{
    //en Unity se puede seleccionar la sensitivity
    public enum SightSensitivity
    {
        STRICT,
        LOOSE

    };

    public SightSensitivity sensitivity = SightSensitivity.STRICT;

    public bool canSeeTarget = false;

    public float fieldOfView = 45.0f;

    private Transform theTransform = null;

    public Transform eyePoint = null;

    private Transform target = null;

    private SphereCollider theCollider = null;

    public Vector3 lastKnownSight = Vector3.zero;

    void Awake()
    {
        theTransform = GetComponent<Transform>();
        theCollider = GetComponent<SphereCollider>();
        lastKnownSight = theTransform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    bool InFieldOfView()
    {
        Vector3 directionToTheTarget = target.position - eyePoint.position;

        float angle = Vector3.Angle(eyePoint.forward, directionToTheTarget);

        if (angle <= fieldOfView)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    bool ClearLineofSight()
    {
        RaycastHit raycastInfo;

        Vector3 directionToTheTargetNormalized = (target.position - eyePoint.position).normalized;

        if (Physics.Raycast(eyePoint.position, directionToTheTargetNormalized, out raycastInfo, theCollider.radius))
        {

            if (raycastInfo.transform.CompareTag("Player"))
            {

                return true;
            }
        }

        return false;
    }


    void UpdateSight()
    {

        switch (sensitivity)
        {
            case SightSensitivity.STRICT:
                canSeeTarget = InFieldOfView() && ClearLineofSight();
                break;
            case SightSensitivity.LOOSE:
                canSeeTarget = InFieldOfView() || ClearLineofSight();
                break;

        }

    }


    void OnTriggerStay(Collider collider)
    {

        if (!collider.CompareTag("Player"))
            return;

        UpdateSight();

        if (canSeeTarget)
        {
		 lastKnownSight = target.position;
        }
    }

    void OnTriggerExit(Collider collider)
    {

        if (!collider.CompareTag("Player"))
            return;

        canSeeTarget = false;
    }


}