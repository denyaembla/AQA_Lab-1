namespace CurrencyExchanger;

public class Data
{ 
   public const double usdRate = 2.5712;
   public const double euroRate = 2.9314;
   public const double rubRate = 3.4155 / 100;
   public const double cashFee = 0.03;

   public enum CurrencyTypes
   {
      Usd,
      Euro,
      Rub
   }

}
