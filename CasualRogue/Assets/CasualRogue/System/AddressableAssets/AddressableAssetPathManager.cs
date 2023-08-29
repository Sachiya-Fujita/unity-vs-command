using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AddressableAssetPathの管理クラス
/// </summary>
public static class AddressableAssetPathManager
{
    /// <summary>
    /// HogePathの取得
    /// </summary>
    public static string GetHogePath(long resourceId)
    {
        return $"Assets/Project/AddressableAssets/InternalAssets/OutGame/Title/Image/img_title_bg_internal_{resourceId}.jpeg";
    }
}
