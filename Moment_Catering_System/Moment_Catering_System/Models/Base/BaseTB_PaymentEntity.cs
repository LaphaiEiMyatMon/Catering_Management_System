using System;

namespace Moment_Catering_System.Models.Base
{
    public class BaseTB_PaymentEntity
    {
        private int _paymentID;
        private int _orderID;
        private int _customerID;
        private int _paymentMethodID;
        private decimal _paymentAmount;
        private string _status;
        private string _notes;
        private string _cardNumber;
        private string _cardHolderName;
        private string _expirationDate;
        private int _cVV;
        private string _accountNumber;
        private string _mobileWalletAcc;
        private string _billingAddress;
        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;

        public int PaymentID { get => _paymentID; set => _paymentID = value; }
        public int OrderID { get => _orderID; set => _orderID = value; }
        public int CustomerID { get => _customerID; set => _customerID = value; }
        public int PaymentMethodID { get => _paymentMethodID; set => _paymentMethodID = value; }
        public decimal PaymentAmount { get => _paymentAmount; set => _paymentAmount = value; }
        public string Status { get => _status; set => _status = value; }
        public string Notes { get => _notes; set => _notes = value; }
        public string CardNumber { get => _cardNumber; set => _cardNumber = value; }
        public string CardHolderName { get => _cardHolderName; set => _cardHolderName = value; }
        public string ExpirationDate { get => _expirationDate; set => _expirationDate = value; }
        public int CVV { get => _cVV; set => _cVV = value; }
        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string BillingAddress { get => _billingAddress; set => _billingAddress = value; }
        public DateTime? CreatedAt { get => _createdAt; set => _createdAt = value; }
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
        public DateTime? UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
        public string UpdatedBy { get => _updatedBy; set => _updatedBy = value; }
        public string MobileWalletAcc { get => _mobileWalletAcc; set => _mobileWalletAcc = value; }


        #region "IsNull"

        public bool IsPaymentIDNull() { return this._paymentID == 0; }

        public bool IsOrderIDNull() { return this._orderID == 0; }

        public bool IsCustomerIDNull() { return this._customerID == 0; }

        public bool IsPaymentMethodIDNull() { return this._paymentMethodID == 0; }

        public bool IsPaymentAmountNull() { return this._paymentAmount == 0; }

        public bool IsStatusNull() { return this._status == null; }

        public bool IsNotesNull() { return this._notes == null; }

        public bool IsCardNumberNull() { return this._cardNumber == null; }

        public bool IsCardHolderNameNull() { return this._cardHolderName == null; }

        public bool IsExpirationDateNull() { return this._expirationDate == null; }

        public bool IsCVVNull() { return this._cVV == 0; }

        public bool IsAccountNumberNull() { return this._accountNumber == null; }

        public bool IsBillingAddressNull() { return this._billingAddress == null; }

        public bool IsMobileWalletAccNull() { return this._mobileWalletAcc == null; }

        public bool IsCreatedAtNull() { return this._createdAt == null; }

        public bool IsCreatedByNull() { return this._createdBy == null; }

        public bool IsUpdatedAtNull() { return this._updatedAt == null; }

        public bool IsUpdatedByNull() { return this._updatedBy == null; }

        #endregion
    }
}