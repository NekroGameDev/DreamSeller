using UnityEngine;
using UnityEngine.EventSystems;

public class PipeController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float[] correctRotations;//Максимум 2

    #region [PrivateVars]

    private float[] avaiableRotations = { 0, 90, 180, 270 };
    private int possibleRotations = 1;
    private bool isPlaced = false;

    #endregion

    private void Start()
    {
        possibleRotations = correctRotations.Length;

        int randomValue = Random.Range(0, avaiableRotations.Length);
        transform.eulerAngles = new Vector3(0, 0, avaiableRotations[randomValue]);

        CheckCorrectRotation();
    }

    private void CheckCorrectRotation()
    {
        if (possibleRotations > 1)
        {
            if ((transform.eulerAngles.z == correctRotations[0]) || (transform.eulerAngles.z == correctRotations[1]) && (!isPlaced))
            {
                isPlaced = true;
                PipesManager.Instance.CorrectMove();
            }
            else
            {
                isPlaced = false;
                PipesManager.Instance.WrongMove();
            }
        }
        else
        {
            if ((transform.eulerAngles.z == correctRotations[0]) && (!isPlaced))
            {
                isPlaced = true;
                PipesManager.Instance.CorrectMove();
            }
            else if (isPlaced)
            {
                isPlaced = false;
                PipesManager.Instance.WrongMove();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.Rotate(new Vector3(0, 0, 90));
        CheckCorrectRotation();
    }
}
