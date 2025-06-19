using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    private int scoreValue;

   
    private const string STUDENT_ID = "2331540050";

   
    private void Awake()
    {
        CalculateScoreValue();
    }

    
    private void CalculateScoreValue()
    {
       
        char lastChar = STUDENT_ID[STUDENT_ID.Length - 1];

       
        int lastDigit = int.Parse(lastChar.ToString());

       
        scoreValue = 1 + lastDigit;

        
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                
                GameManager.instance.AddScore(scoreValue);
            }
            else
            {
                Debug.LogError("Không tìm thấy GameManager trong Scene!");
            }

            Destroy(gameObject);
        }
    }
}