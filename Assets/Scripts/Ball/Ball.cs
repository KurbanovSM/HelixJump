using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSegment platformSegment))
        {
           other.GetComponentInParent<Platform>().Break();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyPlatform enemyPlatform))
        {
            BallTracking.instance().RestartGame.SetActive(true);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("finish"))
        {
            BallTracking.instance().RestartGame.SetActive(true);
        }
    }
}
