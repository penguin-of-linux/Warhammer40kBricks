public static class UnityVector3Extensions
{
    public static Geometry.Vector2 ToGeometryVector2(this UnityEngine.Vector3 vec)
    {
        return new Geometry.Vector2(vec.x, vec.z);
    }
}