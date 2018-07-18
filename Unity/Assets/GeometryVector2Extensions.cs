using UnityEngine;

public static class GeometryVector2Extensions
{
    public static Vector3 ToUnityVector3(this Geometry.Vector2 vec)
    {
        return new Vector3((float)vec.X, 0, (float)vec.Y);
    }
}