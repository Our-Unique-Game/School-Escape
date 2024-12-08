using UnityEngine;
using TMPro; // For TextMeshPro UI elements
using UnityEngine.UI; // For Button UI elements

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            // Show the question panel
            questionPanel.SetActive(true);

            // Set the question text
            questionTextUI.text = questionText;

            // Add the SubmitAnswer method to the button's OnClick event
            submitButton.onClick.AddListener(SubmitAnswer);
        }
    }

    private void SubmitAnswer()
    {
        // Get the player's answer and trim whitespace
        string playerAnswer = answerInputField.text.Trim();

        // Check if the answer is correct (case-sensitive comparison)
        if (playerAnswer.Equals(correctAnswer.Trim()))
        {
            feedbackText.text = "Correct!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Wrong! Try again.";
            feedbackText.color = Color.red;
        }

        // Clear the input field for the next question
        answerInputField.text = "";

        // Optionally, hide the panel after answering
        // questionPanel.SetActive(false);

        // Remove the listener to avoid duplicate calls
        submitButton.onClick.RemoveListener(SubmitAnswer);
}

}
