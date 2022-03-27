using static CurrencyExchanger.Data.CurrencyTypes;

namespace CurrencyExchanger;

public class CurrencyExchanger
{
    public static void ExchangeCurrency()
    {

        var usdRate = Data.usdRate;
        var euroRate = Data.euroRate;
        var rubRate = Data.rubRate; 
        
        var cashFee = Data.cashFee;
        var currencyTypeFrom = 0; 
        var currencyTypeInto = 0;
        var temporaryByn = 0.0;
        var result = 0.0;
    
        Console.WriteLine("Enter amount and currency you need to convert FROM");
        var usersInput = Console.ReadLine();
    
        var splittedArray = usersInput.Split(new char[] {' '},2);   
        var amount = double.Parse(splittedArray[0]);                                      
        var parsedCurrencyFrom = splittedArray[1];
    
        Console.WriteLine("Enter currency you need to convert INTO");
        var currencyInto = Console.ReadLine();

        if (parsedCurrencyFrom == "USD")
        {
            currencyTypeFrom = 0;
        }
        else
        {
            currencyTypeFrom = parsedCurrencyFrom == "EURO" ? 1 : 2;
        }
        
        if (currencyInto == "USD")
        {
            currencyTypeInto = 0;
        }
        else
        {
            currencyTypeInto = currencyInto == "EURO" ? 1 : 2;
        }
    
        switch (currencyTypeFrom)
        {
            case (int)Usd :
                temporaryByn = amount * usdRate;
                result = currencyTypeInto switch
                {
                    (int) Usd => temporaryByn / usdRate,
                    (int) Euro => temporaryByn / euroRate,
                    (int) Rub => temporaryByn / rubRate,
                    _ => result
                };
                break;
            case (int)Euro:
                temporaryByn = amount * euroRate;
                result = currencyTypeInto switch
                {
                    (int) Usd => temporaryByn / usdRate,
                    (int) Euro => temporaryByn / euroRate,
                    (int) Rub => temporaryByn / rubRate,
                    _ => result
                };
                break;
            case (int)Rub :
                temporaryByn = amount * rubRate;
                result = currencyTypeInto switch
                {
                    (int) Usd => temporaryByn / usdRate,
                    (int) Euro => temporaryByn / euroRate,
                    (int) Rub => temporaryByn / rubRate,
                    _ => result
                };
                break;
        }
      
        Console.Write($"Exchange result is {result*(1-cashFee):F} {currencyInto} ");
    }
}
