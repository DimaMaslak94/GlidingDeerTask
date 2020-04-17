using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arrow : MonoBehaviour
{

    [SerializeField] private UnityEvent animComplete;
    [SerializeField] private UnityEvent targetHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetArrow()
    {
        animComplete?.Invoke();
    }

    public void OnTargetHit()
    {
        targetHit?.Invoke();
    }
}
