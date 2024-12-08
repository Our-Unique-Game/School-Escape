using UnityEngine;
using TMPro; // For TextMeshPro UI elements
using UnityEngine.UI; // For Button UI elements
using System.Collections; // For Coroutines

public class QuestionTrigger : MonoBehaviour
{
    [Header("Question Settings")]
    [SerializeField] private string questionText = "What is 2 + 2?"; // The question to ask
    [SerializeField] private string correctAnswer = "4"; // The correct answer

    [Header("UI Elements")]
    [SerializeField] private GameObject questionPanel; // Reference to the UI panel
    [SerializeField] private TMP_Text questionTextUI; // Reference to the TextMeshPro Text element
    [SerializeField] private TMP_InputField answerInputField; // Reference to the TMP InputField
    [SerializeField] private TMP_Text feedbackText; // Feedback text for correct or wrong answers
    [SerializeField] private Button submitButton; // Submit button for answers
    [SerializeField] private Button closeButton; // Close button for the panel

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            // Show the question panel
            questionPanel.SetActive(true);

            // Set the question text
            questionTextUI.text = questionText;

            // Add listeners for the buttons
            submitButton.onClick.AddListener(SubmitAnswer);
            closeButton.onClick.AddListener(ClosePanel);
        }
    }

    private void SubmitAnswer()
    {
        // Get the player's answer and normalize it
        string playerAnswer = NormalizeWhitespace(answerInputField.text);

        // Check if the answer is correct (case-insensitive comparison)
        if (string.Equals(playerAnswer, NormalizeWhitespace(correctAnswer), System.StringComparison.OrdinalIgnoreCase))
        {
            feedbackText.text = "Correct!";
            feedbackText.color = Color.green;

            // Start coroutine to hide panel after 3 seconds
            StartCoroutine(HidePanelAfterDelay(3f));
        }
        else
        {
            feedbackText.text = "Wrong! Try again.";
            feedbackText.color = Color.red;
        }

        // Clear the input field for the next question
        answerInputField.text = "";
    }

    private IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Hide the panel and cleanup
        ClosePanel();
    }

    private void ClosePanel()
    {
        // Hide the question panel
        questionPanel.SetActive(false);

        // Remove listeners to avoid duplicate calls
        submitButton.onClick.RemoveListener(SubmitAnswer);
        closeButton.onClick.RemoveListener(ClosePanel);
    }

    // Helper method to normalize whitespace
    private string NormalizeWhitespace(string input)
    {
        return System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ").Trim();
    }
}
