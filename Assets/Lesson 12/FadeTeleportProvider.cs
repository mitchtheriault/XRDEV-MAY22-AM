using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public class FadeTeleportProvider : TeleportationProvider
{

    public Renderer cameraFade;

    public float pauseAmount = 0f;

    public float fadeSpeed = 1f;


    protected override void Update()
    {
        if (!validRequest || !BeginLocomotion())
            return;

        StartCoroutine(FadeTeleport());
    }

    private void PerformTeleport()
    {
        var xrOrigin = system.xrOrigin;
        if (xrOrigin != null)
        {
            switch (currentRequest.matchOrientation)
            {
                case MatchOrientation.WorldSpaceUp:
                    xrOrigin.MatchOriginUp(Vector3.up);
                    break;
                case MatchOrientation.TargetUp:
                    xrOrigin.MatchOriginUp(currentRequest.destinationRotation * Vector3.up);
                    break;
                case MatchOrientation.TargetUpAndForward:
                    xrOrigin.MatchOriginUpCameraForward(currentRequest.destinationRotation * Vector3.up, currentRequest.destinationRotation * Vector3.forward);
                    break;
                case MatchOrientation.None:
                    // Change nothing. Maintain current origin rotation.
                    break;
                default:
                    Assert.IsTrue(false, $"Unhandled {nameof(MatchOrientation)}={currentRequest.matchOrientation}.");
                    break;
            }

            var heightAdjustment = xrOrigin.Origin.transform.up * xrOrigin.CameraInOriginSpaceHeight;

            var cameraDestination = currentRequest.destinationPosition + heightAdjustment;

            xrOrigin.MoveCameraToWorldLocation(cameraDestination);
        }

        EndLocomotion();
        validRequest = false;
    }

    private IEnumerator FadeTeleport()
    {
        float timer = 0;

        while (timer < 1)
        {
            timer += Time.deltaTime * fadeSpeed;

            cameraFade.material.color = Color.Lerp(Color.clear, Color.black, timer);

            yield return new WaitForEndOfFrame();
        }

        //teleport
        yield return new WaitForSeconds(pauseAmount);
        PerformTeleport();

        while (timer > 0)
        {
            timer -= Time.deltaTime * fadeSpeed;

            cameraFade.material.color = Color.Lerp(Color.clear, Color.black, timer);

            yield return new WaitForEndOfFrame();
        }

    }

  
}
