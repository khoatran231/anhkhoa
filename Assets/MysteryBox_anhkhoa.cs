using System.Collections;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [Header("Nội dung của hộp")]
    [SerializeField] private GameObject itemPrefab; 

    [Header("Trạng thái của hộp")]
    [SerializeField] private Sprite emptyBoxSprite; 
    [SerializeField] private float bounceHeight = 0.3f; 
    [SerializeField] private float bounceSpeed = 4f; 

    private bool canBeUsed = true;
    private Vector3 originalPosition;

    void Awake()
    {
        originalPosition = transform.position;
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (!canBeUsed || !collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        
        if (collision.contacts[0].normal.y < -0.5f)
        {
          
            canBeUsed = false;

          
            StartCoroutine(HitBoxSequence());
        }
    }

    private IEnumerator HitBoxSequence()
    {
     
        if (itemPrefab != null)
        {
            Instantiate(itemPrefab, transform.position + Vector3.up, Quaternion.identity);
        }

        Vector3 targetPosition = originalPosition + Vector3.up * bounceHeight;

       
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, bounceSpeed * Time.deltaTime);
            yield return null; 
        }

        
        while (transform.position != originalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, bounceSpeed * Time.deltaTime);
            yield return null; 
        }

      
        GetComponent<SpriteRenderer>().sprite = emptyBoxSprite;
    }
}