using UnityEngine;

public static class Utils
{
    // test how similar 2 vectors are
    // eg, detect direction mario is moving and compare to direction up
    // if 2 vectors are similar, then we know mario collided with the block while moving up
    // if mario land on the box from above, 2 different vector
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }
}