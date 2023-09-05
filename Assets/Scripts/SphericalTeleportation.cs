using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphericalTeleportation : TeleportationArea
{
    protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
    {
        if (raycastHit.collider == null)
            return false;
        
        Vector3 handPos = interactor.transform.position;
        Vector3 hitPos = raycastHit.point;
        Vector3 up = raycastHit.normal;
        Vector3 right = Vector3.Cross(handPos - hitPos, up);
        Vector3 forward = Vector3.Cross(up, right);
        
        teleportRequest.destinationPosition = raycastHit.point;
        teleportRequest.destinationRotation = Quaternion.LookRotation(forward, up);
        teleportRequest.matchOrientation = MatchOrientation.TargetUp;
        matchOrientation = MatchOrientation.TargetUpAndForward;
        return true;
    }
}