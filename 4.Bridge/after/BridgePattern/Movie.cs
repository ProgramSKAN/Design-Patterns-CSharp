using System;

namespace BridgePattern
{
    public class MovieLicense
    {
        private readonly Discount _discount;
        private readonly LicenceType _licenceType;
        private readonly SpecialOffer _specialOffer;

        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        public MovieLicense(
            string movie,
            DateTime purchaseTime,
            Discount discount,//instead of enum Discount can be abstract class with overrides of price for noDiscount,Military,senior discount.and pass instance as parameter
            LicenceType licenceType,
            SpecialOffer specialOffer = SpecialOffer.None)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
            _licenceType = licenceType;
            _specialOffer = specialOffer;
        }

        public decimal GetPrice()
        {
            int discount = GetDiscount();
            decimal multiplier = 1 - discount / 100m;
            return GetBasePrice() * multiplier;
        }

        private int GetDiscount()
        {
            return _discount switch
            {
                Discount.None => 0,
                Discount.Military => 10,
                Discount.Senior => 20,

                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private decimal GetBasePrice()
        {
            return _licenceType switch
            {
                LicenceType.TwoDays => 4,
                LicenceType.LifeLong => 8,

                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public DateTime? GetExpirationDate()
        {
            DateTime? expirationDate = GetBaseExpirationDate();
            TimeSpan extension = GetSpecialOfferExtension();

            return expirationDate?.Add(extension);
        }

        private TimeSpan GetSpecialOfferExtension()
        {
            return _specialOffer switch
            {
                SpecialOffer.None => TimeSpan.Zero,
                SpecialOffer.TwoDaysExtension => TimeSpan.FromDays(2),

                _ => throw new ArgumentOutOfRangeException()//exception if enum value is null
            };
        }

        private DateTime? GetBaseExpirationDate()
        {
            return _licenceType switch
            {
                LicenceType.TwoDays => PurchaseTime.AddDays(2) as DateTime?,
                LicenceType.LifeLong => null,

                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

//loosly coupled enums
    public enum LicenceType
    {
        TwoDays,
        LifeLong
    }

    public enum Discount
    {
        None,
        Military,
        Senior
    }

    //new requirement is easy to add
    public enum SpecialOffer
    {
        None,
        TwoDaysExtension
    }

    /*//enums or
    public abstract Discount{
        public abstract int GetDiscunt();
    }

    public class NoDiscount:Discount{
        public override int GetDiscount()=>0;
    }
    public class MilitaryDiscount:Discount{
        public override int GetDiscount()=>10;
    }
    public class SeniorDiscount:Discount{
        public override int GetDiscount()=>20;
    }
    */
}
