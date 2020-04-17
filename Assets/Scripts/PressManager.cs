using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressManager : MonoBehaviour
{
    public UnityEvent OnButtonPressed;

    [SerializeField] private string buttonTag = "GameBtn";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPress();
        }
    }

    private void OnPress()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var target = hit.transform;
            if(target.CompareTag(buttonTag))
            {
                OnButtonPressed?.Invoke();
            }
        }
    }
}
