using UnityEngine;

public class BlockHit : MonoBehaviour
{
    // number of time you can hit the block
    // negative means can hit infinite
    public int maxHits = -1;
    public Sprite emptyBox;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
        maxHits--;

        if (maxHits == 0)
        {
            // switch to empty box sprite
            spriteRenderer.sprite = emptyBox;
        }
    }
}
