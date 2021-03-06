using SDK.Sdk.CodeBase.Data.RunTime;
using SDK.Sdk.CodeBase.Network;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SDK.Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseInfoSubView : MonoBehaviour
    {
        [SerializeField] private RawImage _purchaseItemImage;
        [SerializeField] private Text _title;
        [SerializeField] private Text _currency;
        [SerializeField] private Text _currencySign;
        [SerializeField] private Text _infoText;
        [SerializeField] private UserCreditCardCredentials _credentials;

        private INetworkService _networkService;
        public UserCreditCardCredentials Credentials => _credentials;
        public Text InfoText => _infoText;

        [Inject]
        public void Construct(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public void Initialize(PurchaseInfoDto data)
        {
            _credentials.Initialize();
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