using System;

namespace BridgePattern
{
    public abstract class MovieLicense
    {
        public string Movie { get; }//use Movie class instead of string in realworld
        public DateTime PurchaseTime { get; }

        protected MovieLicense(string movie, DateTime purchaseTime)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
        }

        public abstract decimal GetPrice();
        public abstract DateTime? GetExpirationDate();
    }

    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime)
            : base(movie, purchaseTime)
        {
        }

        public override decimal GetPrice()
        {
            return 4;//4$ for 2day License
        }

        public override DateTime? GetExpirationDate()
        {
            return PurchaseTime.AddDays(2);
        }
    }

    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime)
            : base(movie, purchaseTime)
        {
        }

        public override decimal GetPrice()
        {
            return 8;//8$
        }

        public override DateTime? GetExpirationDate()
        {
            return null;
        }
    }


    //new requirent for discount needs one more hierarchy like below// to avoid this use bridge pattern
    public class MilitaryTwoDaysLicense: TwoDaysLicense{
        public MilitaryTwoDaysLicense(string movie, DateTime purchaseTime): base(movie, purchaseTime)
        {
        }

        public override decimal GetPrice{
            return base.GetPrice()*0.9m;
        }
    }

    public class SeniorTwoDaysLicense: LifeLongLicense{
        public SeniorTwoDaysLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        {
        }
        public override decimal GetPrice{
            return base.GetPrice()*0.8m;//20% discount
        }
    }

    //one more feature
    public class SpecialOfferForSeniorTwoDaysLicense:SeniorTwoDaysLicense{
         public SpecialOfferForSeniorTwoDaysLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        {
        }

        public override DateTime? GetExpirationDate  {
            DateTime? rxpirationDate=base.GetExpirationDate();
            return expirationDate?.AddDays(2);
        }
    }
}
