using UnityEngine;
using UnityEngine.Events;

public class PipesManager : MonoBehaviour
{
    [SerializeField] private GameObject pipesHolder;
    [SerializeField] private int totalPipes;

    [Header("Events")]
    [SerializeField] private UnityEvent onWin;

    #region [PublicVars]

    public static PipesManager Instance;

    #endregion

    #region [PrivateVars]

    private int correctPipes;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        totalPipes = pipesHolder.transform.childCount;
    }

    public void CorrectMove()
    {
        correctPipes++;

        if (correctPipes == totalPipes)
        {
            onWin?.Invoke();
        }
    }

    public void WrongMove()
    {
        correctPipes--;
    }
}
