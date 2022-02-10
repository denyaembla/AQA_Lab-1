void CurrencyExchanger()
{
    const double usdRate = 2.5712;  // currency rates 
    const double euroRate = 2.9314;
    const double rubRate = 3.4155 / 100;
    
    var temporaryByn = 0.0; // for processing
    var result = 0.0;
    const double cashFee = 0.03;
    
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
            break;
        case "EURO" :
            temporaryByn = amount * euroRate;
            break;
        case "RUB" :
            temporaryByn = amount * rubRate;
            break;
    }
    
    switch (currencyInto)
    {
        case "USD" :
            result = temporaryByn / usdRate;
            break;
        case "EURO" :
            result = temporaryByn / euroRate;
            break;
        case "RUB" :
            result = temporaryByn / rubRate;
            break;
    }
        
    Console.Write($"Exchange's result is {result*(1-cashFee):F} {currencyInto} ");
}

CurrencyExchanger();
