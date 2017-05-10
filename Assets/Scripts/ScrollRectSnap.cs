using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

//CaptainSchnittchen

public class ScrollRectSnap : ScrollRect {

    public float stepValue = 0.5f;

    public int steps = 5;

    public float velocityToSwipe = 500;

    private float actualPosition = 0.5f;

    private IEnumerator co;

    /// <summary>
    /// End drag event
    /// </summary>
    public override void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData) {
        //base.OnEndDrag(eventData);

        float stepNormalized = 1f / (steps - 1f);

        float nearestPosition = Mathf.Clamp(FindNearestPosition(horizontalNormalizedPosition), actualPosition - stepNormalized, actualPosition + stepNormalized);
        Debug.Log("horizontalNormalizedPosition position:" + horizontalNormalizedPosition);
        Debug.Log("actualPosition position:" + actualPosition);
        Debug.Log("nearest position:" + nearestPosition);
        Debug.Log("velocity:" + velocity);

        if(nearestPosition == actualPosition) {

            // Swipe to left
            if (actualPosition != 0 && velocity.x > velocityToSwipe) {

                nearestPosition = actualPosition - stepNormalized;
            
            // Swipe to right
            } else if (actualPosition != 1 && velocity.x < -velocityToSwipe) {

                nearestPosition = actualPosition + stepNormalized;
            }
        }

        Debug.Log("nearest position:" + nearestPosition);

        if (co != null)
            StopCoroutine(co);

        co = LerpToStep(nearestPosition);

        StartCoroutine(co);

        actualPosition = nearestPosition;

    }

    public void MoveTo(float newPosition) {

        if (co != null)
            StopCoroutine(co);

        co = LerpToStep(newPosition);

        StartCoroutine(co);

        actualPosition = newPosition;

        actualPosition = newPosition;
    }

    private float FindNearestPosition(float actualPostion) {
        float nearestPosition = 0;
        float stepNormalized = 1f / (steps - 1f);

        float targetPosition = actualPostion;
        int i = 0;
        while (targetPosition > 0 && i < steps) {
            nearestPosition += stepNormalized;
            targetPosition -= stepNormalized;
            i++;
        }

        if ( nearestPosition != 0) {
            if (targetPosition < -stepNormalized / 2) {
                nearestPosition -= stepNormalized;
            }
        }

        return nearestPosition;
    }

    IEnumerator LerpToStep(float targetStepPosition) {
        
        // If we are too close, we stop lerping
        while (Mathf.Abs(horizontalNormalizedPosition - targetStepPosition) > 0.001) {

            horizontalNormalizedPosition = Mathf.Lerp(horizontalNormalizedPosition, targetStepPosition, 10 * Time.deltaTime);

            yield return null;
        }

        // If we are too close, assign target position directly
        horizontalNormalizedPosition = targetStepPosition;
    }
}

