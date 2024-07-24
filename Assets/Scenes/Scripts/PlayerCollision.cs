using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacles")
        {
            Debug.Log("Collided: Score minuses by 20!");
            FindObjectOfType<Score>().ChangeScore(20);
            StartCoroutine(DestroyObstacleAfterDelay(collision.collider.gameObject, 1f));
        }
    }

    private IEnumerator DestroyObstacleAfterDelay(GameObject obstacle, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obstacle);
    }
}
