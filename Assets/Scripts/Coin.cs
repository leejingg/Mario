using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityEvent<int> increaseScore;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);
        increaseScore.Invoke(1);
        Destroy(gameObject);
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
