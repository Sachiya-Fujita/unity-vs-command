using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

/// <summary>
/// AddressableAssetsの管理クラス
/// </summary>
public class AddressableManager : MonoBehaviour
{
    [SerializeField]
    private Image thumbnailImage = null;

    private AsyncOperationHandle<Sprite> handle = default;

    public async void Start()
    {
        // Addresables 初期化
        await Addressables.InitializeAsync().Task;

        // リモートカタログに変更があれば更新する
        var catalogs = await Addressables.CheckForCatalogUpdates(true).Task;
        if (catalogs != null && catalogs.Count > 0)
        {
            var locators = await Addressables.UpdateCatalogs(catalogs, true).Task;
        }

        // Addressables 経由で Sprite を読み込んで表示
        this.handle = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/cat.png");
        this.thumbnailImage.sprite = await this.handle.Task;
    }

    public void OnDestroy()
    {
        // いらなくなったら handle を Release する
        Addressables.Release(this.handle);
    }
}
