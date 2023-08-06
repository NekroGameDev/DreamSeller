using System.Collections;
using UnityEngine;
using TMPro;

public class TextMeshProPrinter : MonoBehaviour
{
    public TextMeshProUGUI targetTextMeshPro;
    public string fullText;
    public float letterDelay = 0.05f;

    private Coroutine printingCoroutine;

    private void Start()
    {
        // Start the printing coroutine when the script is initialized
        StartPrinting();
    }

    private void OnEnable()
    {
        // Start the printing coroutine when the script is enabled
        StartPrinting();
    }

    private void OnDisable()
    {
        // Stop the printing coroutine when the script is disabled
        StopPrinting();
    }

    public void StartPrinting()
    {
        if (printingCoroutine == null)
        {
            printingCoroutine = StartCoroutine(PrintText());
        }
    }

    public void StopPrinting()
    {
        if (printingCoroutine != null)
        {
            StopCoroutine(printingCoroutine);
            printingCoroutine = null;
        }
    }

    private IEnumerator PrintText()
    {
        targetTextMeshPro.text = ""; // Clear the text initially

        for (int i = 0; i < fullText.Length; i++)
        {
            targetTextMeshPro.text += fullText[i]; // Add the next letter to the text
            yield return new WaitForSeconds(letterDelay); // Wait for a short delay
        }

        printingCoroutine = null; // Reset the coroutine reference
    }
}
