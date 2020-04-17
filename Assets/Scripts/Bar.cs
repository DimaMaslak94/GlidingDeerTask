using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Bar : MonoBehaviour
{

    [System.Serializable] public class BarStrengthSender : UnityEvent<float> { }
    [SerializeField]private BarStrengthSender barStrengthSender;



    [SerializeField] private GameObject dot;
    [SerializeField] private float startPos = 0.0275f;
    [SerializeField] private float endPos = -0.0275f;
    private Animation dotAnim;
    private float distance;
    



    // Start is called before the first frame update
    void Start()
    {
        dotAnim = dot.GetComponent<Animation>();
        distance = Mathf.Abs(endPos - startPos);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBar()
    {
        dot.transform.localPosition = new Vector3(startPos, 0.0f, 0.0f);
        dotAnim.Play();
    }

    public void ResetBar ()
    {
        float strength = Mathf.Abs((dot.transform.localPosition.x + endPos) / distance * 100);
        barStrengthSender?.Invoke(strength);
        dotAnim.Stop();
        dot.transform.localPosition = new Vector3(startPos, 0.0f, 0.0f);
    }

}
