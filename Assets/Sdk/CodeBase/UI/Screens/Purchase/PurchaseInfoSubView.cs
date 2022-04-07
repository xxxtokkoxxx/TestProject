using Sdk.CodeBase.Data.RunTime;
using Sdk.CodeBase.Network;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseInfoSubView : MonoBehaviour
    {
        [SerializeField] private RawImage _purchaseItemImage;
        [SerializeField] private Text _title;
        [SerializeField] private Text _currency;
        [SerializeField] private Text _currencySign;
        [SerializeField] private Text _infoText;
        [SerializeField] private InputField[] _inputFields;

        private INetworkService _networkService;
        
        public InputField[] InputFields => _inputFields;
        public Text InfoText => _infoText;

        [Inject]
        public void Construct(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public void Initialize(PurchaseInfoDto data)
        {
            _title.text = data.Title;
            _currency.text = data.Currency;
            _currencySign.text = data.CurrencySign;
            LoadImage(data.ItemImage);
        }

        private void LoadImage(string url)
        {
            StartCoroutine(_networkService.GetRequest(url, ReturnedTexture));
        }

        private void ReturnedTexture(Texture texture)
        {
            _purchaseItemImage.texture = texture;
        }
    }
}