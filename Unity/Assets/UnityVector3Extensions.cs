using UnityEngine;
using Vector2 = Geometry.Vector2;

public static class UnityVector3Extensions
{
    public static Vector2 ToGeometryVector2(this Vector3 vec)
    {
        return new Vector2(vec.x, vec.z);
    }
}