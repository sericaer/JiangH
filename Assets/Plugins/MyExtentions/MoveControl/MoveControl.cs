using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MoveControl : MonoBehaviour
{
    public UnityEvent<Vector3> moveEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveControlItem.isOn)
        {
            var pos = new Vector2((Input.mousePosition.x - Screen.width*0.5f) / Screen.width, (Input.mousePosition.y - Screen.height * 0.5f) / Screen.height);
            moveEvent?.Invoke(pos);

            Debug.Log($"move control {pos}");
        }
    }
}
