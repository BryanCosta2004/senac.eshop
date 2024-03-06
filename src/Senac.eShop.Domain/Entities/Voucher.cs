﻿using Senac.eShop.Core.DomainObjects;
using Senac.eShop.Core.Enums;

namespace Senac.eShop.Domain.Entities
{
    public class Voucher : Entity
    {
        public Voucher(string code,
            DiscountTypeVoucher discountType,
            int amount,
            int amountUsed,
            DateTime expirationDate,
            bool active,
            decimal value)
        {
            Code = code;
            DiscountType = discountType;
            Amount = amount;
            AmountUsed = amountUsed;
            ExpirationDate = expirationDate;
            Active = active;
            Value = value;
        }

        protected Voucher() { }
        public string Code { get; private set; }
        public DiscountTypeVoucher DiscountType { get; private set; }
        public int Amount { get; private set; }
        public int AmountUsed { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }

        public void DebitAmount()
        {
            Amount -= 1;
            if(Amount == 0)
            {
                Active = false;
            }
        }
    }
}