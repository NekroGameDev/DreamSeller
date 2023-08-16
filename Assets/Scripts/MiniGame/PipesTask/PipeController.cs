using UnityEngine;
using UnityEngine.EventSystems;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float[] correctRotations;//Максимум 2
    [SerializeField] private bool isWorkingPipe;

    #region [PrivateVars]

    private float[] avaiableRotations = { 0, 90, 180, 270 };
    private int possibleRotations = 1;
    private bool isPlaced = false;

    private int currentRotation = 0;

    #endregion

    private void Start()
    {
        possibleRotations = correctRotations.Length;

        int randomValue = Random.Range(0, avaiableRotations.Length);
        currentRotation = randomValue;
        transform.eulerAngles = new Vector3(0, 0, avaiableRotations[randomValue]);

        if (isWorkingPipe)
        {
            CheckCorrectRotation();
        }
    }

    private void CheckCorrectRotation()
    {
        if (possibleRotations > 1)
        {
            if (((transform.eulerAngles.z == correctRotations[0]) || (transform.eulerAngles.z == correctRotations[1])) && (!isPlaced))
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

    private void OnMouseDown()
    {
        currentRotation++;
        int rotation = (currentRotation + avaiableRotations.Length) % avaiableRotations.Length;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, avaiableRotations[rotation]);
        CheckCorrectRotation();
    }
}
