using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fishing : MonoBehaviour
{
    [SerializeField] private UnityEvent onWin;
    [SerializeField] private UnityEvent onDelayWin;
    [SerializeField] private float delay;
    [SerializeField] private int totalScore;

    private int currentScore;

    public static Fishing Intance;

    private void Awake()
    {
        Intance = this;
    }

    public void AddScore()
    {
        currentScore++;

        if (totalScore == currentScore)
        {
            onWin?.Invoke();
            Invoke(nameof(DelayWin), delay);
        }
    }

    private void DelayWin()
    {
        onDelayWin?.Invoke();
    }
}
