using UnityEngine;

namespace Warhammer40kBricks
{
    public static class BundleLoader
    {
        public static AssetBundle Bundle;

        static BundleLoader()
        {
            Bundle = AssetBundle.LoadFromFile("Games/Warhammer40kBricks/AssetBundles/warhammerassetbundle");
        }
    }
}