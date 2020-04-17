using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{



    // Start is called before the first frame update
    [SerializeField] private UnityEvent onGameStart;
    [SerializeField] private UnityEvent onShoot;
    [SerializeField] private TextMeshPro btnText;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject target;
    [SerializeField] private List <AnimationClip> arrowAnims;

    private bool isStarted = false;
    private Vector3 originArrowPos;
    private Animation arrowAnimation;
    private Animation targetAnimation;
    private int score;


    void Start()
    {
        originArrowPos = arrow.transform.localPosition;
        arrowAnimation = arrow.GetComponent<Animation>();
        targetAnimation = target.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnThrowStrengthRecived(float strength)
    {
        int throwZone = -1;

        if (strength >= 0 && strength < 17)
        {
            throwZone = 0;
        }
        if (strength > 83 && strength <= 100)
        {
            throwZone = 0;
        }

        if (strength >= 17 && strength < 32)
        {
            throwZone = 1;
        }
        if (strength > 68 && strength <= 83)
        {
            throwZone = 1;
        }

        if (strength >= 32 && strength < 45)
        {
            throwZone = 2;
        }
        if (strength > 55 && strength <= 68)
        {
            throwZone = 2;
        }

        if (strength >= 45 && strength <= 55)
        {
            throwZone = 3;
        }

        ThrowDart(throwZone);
    }


    public void OnButtonPressed()
    {
        isStarted = !isStarted;
        if (isStarted)
        {
            StartGame();
            btnText.text = "SHOOT";
        }
        else
        {
            Shoot();
        }

    }

    private void StartGame()
    {
        onGameStart?.Invoke();
    }

    private void Shoot()
    {
        onShoot?.Invoke();
    }
    
    private void ThrowDart (int throwZone)
    {
        arrow.SetActive(true);
        arrowAnimation.clip = arrowAnims[throwZone];
        arrowAnimation.Play();
        score += throwZone;
    }

    public void OnArrowAnimComplete()
    {
        arrow.transform.localPosition = originArrowPos;
        arrow.SetActive(false);
        btnText.text = "START";
    }

    public void OnScore()
    {
        scoreText.text = "SCORE: " + score;
        targetAnimation.Play();
    }



}
