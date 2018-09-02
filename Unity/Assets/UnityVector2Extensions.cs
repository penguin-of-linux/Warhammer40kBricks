public static class UnityVector2Extensions
{
    public static Geometry.Vector2 ToGeometryVector2(this UnityEngine.Vector2 v)
    {
        return new Geometry.Vector2(v.x, v.y);
    }
}