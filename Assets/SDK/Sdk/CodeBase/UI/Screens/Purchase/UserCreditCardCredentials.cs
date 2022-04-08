using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SDK.Sdk.CodeBase.UI.Screens.Purchase
{
    public class UserCreditCardCredentials : MonoBehaviour, IEnumerable
    {
        [SerializeField] private InputField _email;
        [SerializeField] private InputField _creditCard;
        [SerializeField] private InputField _expirationDate;

        private InputField[] _fields;

        public InputField Email => _email;
        public InputField CreditCard => _creditCard;
        public InputField ExpirationDate => _expirationDate;

        public void Initialize()
        {
            InitializeInputFields();
        }

        public IEnumerator GetEnumerator()
        {
            if (_fields == null)
            {
                InitializeInputFields();
            }
            
            return _fields.GetEnumerator();
        }

        private void InitializeInputFields()
        {
            _fields = new[]
            {
                _email,
                _creditCard,
                _expirationDate
            };
        }
    }
}