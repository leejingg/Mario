
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomPowerup : BasePowerup
{
    // setup this object's type
    // instantiate variables
    protected override void Start()
    {
        base.Start(); // call base class Start()
        StartCoroutine(Animate());
        SpawnPowerup();
        this.type = PowerupType.MagicMushroom;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: do something when colliding with Player

            // then destroy powerup (optional)
            DestroyPowerup();

        }
        else if (col.gameObject.layer == 7) // else if hitting Pipe, flip travel direction
        {
            if (spawned)
            {
                goRight = !goRight;
                rigidBody.AddForce(Vector2.right * 3 * (goRight ? 1 : -1), ForceMode2D.Impulse);

            }
        }
    }

    public IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 1f;

        yield return Move(restingPosition, animatedPosition);
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

    // interface implementation
    public override void SpawnPowerup()
    {
        spawned = true;
        rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse); // move to the right
    }


    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object

    }
}