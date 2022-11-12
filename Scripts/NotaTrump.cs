using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotaTrump : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            float range = Vector2.Distance(touchPos, transform.position);
            if (range < 1)
            {
                Destroy(this.gameObject);
            }

        }
        
    }
    
}
