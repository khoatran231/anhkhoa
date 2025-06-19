using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] private float moveUpSpeed = 3f;
    [SerializeField] private float lifeTime = 0.5f;
    [SerializeField] private int scoreValue = 1;

    void Start()
    {
        StartCoroutine(AnimateAndCollect());
    }

    private IEnumerator AnimateAndCollect()
    {
       
        Vector3 targetPosition = transform.position + Vector3.up * 1.5f;

        while (transform.position.y < targetPosition.y)
        {
            transform.position += Vector3.up * moveUpSpeed * Time.deltaTime;
            yield return null;
        }

       
        if (GameManager.instance != null)
        {
            GameManager.instance.AddScore(scoreValue);
        }
        else
        {
          
            Debug.LogError("Không tìm thấy GameManager trong Scene để cộng điểm!");
        }

        
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}