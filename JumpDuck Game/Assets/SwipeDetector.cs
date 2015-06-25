using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour
{
    public float minSwipeDistY = 100;
    public float minSwipeDistX = 100;
    public bool up, down, left, right;
    private Vector2 startPos;

    void Update()
	{
        up = false;
        down = false;
        left = false;
        right = false;

		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches[0];
			
			switch (touch.phase) 	
			{
			case TouchPhase.Began:
				startPos = touch.position;
				break;
				
			case TouchPhase.Ended:
					float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

					if (swipeDistVertical > minSwipeDistY) 
					{
						float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
						
						if (swipeValue > 0)//up swipe
                        {
                            up = true;
						}
						else if (swipeValue < 0)//down swipe
                        {
                            down = true;
                        }
					}
					
					float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
					
					if (swipeDistHorizontal > minSwipeDistX) 
					{
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
						
						if (swipeValue > 0)//right swipe
                        {
                            right = true;
						}
                        else if (swipeValue < 0)//left swipe
                        {
                            left = true;
                        }
					}
				break;
			}
		}
	}
}