using System.Collections;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    // number of time you can hit the block
    // negative means can hit infinite
    public int maxHits = -1;
    private bool collectedItem = false;
    public Sprite emptyBox;
    private bool animating;
    public Animator blockAnimator;
    public GameObject item;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player"))
        {
            // collision.transform is mario
            // transform is the block
            // if mario collides with the box while moving up
            // then hit the right direction
            if (collision.transform.DotTest(transform, Vector2.up))
            {
                Hits();
            }
        }
    }

    private void Hits()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        maxHits--;

        if (maxHits == 0)
        {
            // switch to empty box sprite
            spriteRenderer.sprite = emptyBox;
            blockAnimator.SetTrigger("boxEmpty");
        }

        if (item != null && !collectedItem)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            collectedItem = true;
        }

        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    public IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elasped = 0f;
        float duration = 0.125f;

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
