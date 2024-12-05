using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    [Header("Question Settings")]
    public string questionText = "What is 2 + 2?"; // The question to ask
    public string correctAnswer = "4"; // The correct answer

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            // Log a message when the player touches the question object
            Debug.Log("Player touched the question mark!");

            // Trigger the question prompt
            AskQuestion();

            // Destroy the question object
            Destroy(gameObject);
        }
    }

    private void AskQuestion()
    {
        // Display the question in the Console or trigger UI functionality
        Debug.Log("Question: " + questionText);

        // Optional: Add UI logic here to show the question to the player
        // Example: Trigger a canvas or UI panel with the question and accept input
    }
}
