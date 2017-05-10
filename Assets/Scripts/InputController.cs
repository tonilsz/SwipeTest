using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    public float minSwipeDistY;

    public float minSwipeDistX;

    public Text Swipe;

    private Vector2 startPos;

    private Vector2 movedPos;

    private float distance = 0f;


    private enum movingDirection {
        mHorizontal,
        mVertical,
        mNone
    }

    private movingDirection direction;

    void Start() {

        Debug.Log("Starting");
    }

    // Update is called once per frame
    void Update() {

        if (Input.touchCount > 0) {

            Touch touch = Input.touches[0];

            switch (touch.phase) {

                case TouchPhase.Began:

                    Debug.Log("Init");

                    startPos = touch.position;

                    direction = movingDirection.mNone;

                    break;

                case TouchPhase.Moved:

                    Debug.Log("Moving " + distance);

                    movedPos = touch.position;

                    distance = startPos.y - movedPos.y;
                    /*
                    if (direction == movingDirection.mNone) {


                        if (Mathf.Abs(startPos.x - movedPos.x) > Mathf.Abs(startPos.y - movedPos.y))
                            direction = movingDirection.mHorizontal;
                        else
                            direction = movingDirection.mVertical;
                    }*/

                    Camera.main.transform.position -= new Vector3(0, distance, 0);

                    startPos = movedPos;

                    break;

                case TouchPhase.Ended:


                    Debug.Log("Ended " + distance);

                    StartCoroutine("SmoothSwipeEnd");

                    /*
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;


                    if (direction == movingDirection.mVertical && swipeDistVertical > minSwipeDistY) {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0) {

                            // Up Swipe
                            Swipe.text = "Up Swipe";

                        } else if (swipeValue < 0) {

                            // Down Swipe
                            Swipe.text = "Down Swipe";

                        }
                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.y, 0, 0) - new Vector3(startPos.y, 0, 0)).magnitude;

                    if (direction == movingDirection.mHorizontal &&  swipeDistHorizontal > minSwipeDistX) {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0) {

                            // Right Swipe
                            Swipe.text = "Right Swipe";

                        } else if (swipeValue < 0) {

                            // Left Swipe
                            Swipe.text = "Left Swipe";

                        }
                    }*/

                    break;
            }
        }
    }

    IEnumerator SmoothSwipeEnd() {
        Debug.Log("SmoothSwipeEnd " + distance);
        while (Input.touches[0].phase != TouchPhase.Began && Mathf.Abs(distance) > 0.001f) {
            Debug.Log("SmoothSwipeEnd " + distance);


            Camera.main.transform.position -= new Vector3(0, distance, 0);

            if (distance != 0)
                distance *= .9f;

        }
        yield return null;
    }

}
