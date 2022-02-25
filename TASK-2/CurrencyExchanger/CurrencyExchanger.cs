namespace CurrencyExchanger;
public class CurrencyExchanger
{
    public static void ExchangeCurrency()
    {

        var usdRate = Data.usdRate;
        var euroRate = Data.euroRate;
        var rubRate = Data.rubRate; // currency rates
        
        var cashFee = Data.cashFee;
        
        var temporaryByn = 0.0; // for processing
        var result = 0.0;
    
        Console.WriteLine("Enter amount and currency you need to convert FROM");
        var usersInput = Console.ReadLine();
    
        var splittedArray = usersInput.Split(new char[] {' '},2);   
        var amount = double.Parse(splittedArray[0]);                                      
        var parsedCurrencyFrom = splittedArray[1];
    
        Console.WriteLine("Enter currency you need to convert INTO");
        var currencyInto = Console.ReadLine();
    
        switch (parsedCurrencyFrom)
        {
            case "USD" :
                temporaryByn = amount * usdRate;
                result = currencyInto switch
                {
                    "USD" => temporaryByn / usdRate,
                    "EURO" => temporaryByn / euroRate,
                    "RUB" => temporaryByn / rubRate,
                    _ => result
                };
                break;
            case "EURO" :
                temporaryByn = amount * euroRate;
                result = currencyInto switch
                {
                    "USD" => temporaryByn / usdRate,
                    "EURO" => temporaryByn / euroRate,
                    "RUB" => temporaryByn / rubRate,
                    _ => result
                };
                break;
            case "RUB" :
                temporaryByn = amount * rubRate;
                result = currencyInto switch
                {
                    "USD" => temporaryByn / usdRate,
                    "EURO" => temporaryByn / euroRate,
                    "RUB" => temporaryByn / rubRate,
                    _ => result
                };
                break;
        }

        

        Console.Write($"Exchange result is {result*(1-cashFee):F} {currencyInto} ");
    }
}
