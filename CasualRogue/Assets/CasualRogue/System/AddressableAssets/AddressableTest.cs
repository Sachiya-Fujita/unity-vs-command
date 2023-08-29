using UnityEngine;
using UnityEngine.AddressableAssets;//Addressablesを使うのに必要
using UnityEngine.UI;

public class AddressableTest : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    async void Start()
    {
        // Local Test
        // Spriteをロードする
        var sprite = await Addressables.LoadAssetAsync<Sprite>("Spades.png").Task;

        //UIに反映
        _image.sprite = sprite;

        //使い終わったらメモリから開放する
        //Addressables.Release(sprite); <<今回は使わない
    }
}
