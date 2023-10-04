using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        Destroy(gameObject);
        gameManager.IncreaseScore(1);
    }

    public IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elasped = 0f;
        float duration = 0.25f;

        while (elasped < duration)
        {
            float t = elasped / duration;
            transform.localPosition = Vector3.Lerp(from, to, t);
            elasped += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }
}
