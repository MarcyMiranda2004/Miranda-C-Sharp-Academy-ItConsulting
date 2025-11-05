using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{

    [SerializeField] private int _score = 0;

    void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.GetComponent<Bullet>())
        // {
        //     if (GameManager.Instance.ScoreInc(1) >= 10)
        //     {
        //         Destroy(gameObject);
        //     }
        // }
        // print($"Punti: {_score}");

        if (other.gameObject.GetComponent<Bullet>())
        {
            if (_score >= 10)
            {
                Destroy(gameObject);
                print("oggetto distrutto!");
            }
        }
    }
}
