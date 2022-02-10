void CurrencyExchanger()
{
    var USD_rate = 2.5712;  // currency rates 
    var EURO_rate = 2.9314;
    var RUB_rate = 3.4155 / 100;
    
    var temporaryBYNs = 0.0; // for processing
    var result = 0.0;
    const double cashFee = 0.03;
    
    Console.WriteLine("Enter amount and currency you need to convert FROM");
    var usersInput = Console.ReadLine();
    
    var splitArray = usersInput.Split(new char[] {' '},2);   
    var amount = double.Parse(splitArray[0]);                                      
    var parsedCurrencyFrom = splitArray[1];
    
    Console.WriteLine("Enter currency you need to convert INTO");
    var currencyInto = Console.ReadLine();
    
    switch (parsedCurrencyFrom)
    {
        case "USD" :
            temporaryBYNs = amount * USD_rate;
            break;
        case "EURO" :
            temporaryBYNs = amount * EURO_rate;
            break;
        case "RUB" :
            temporaryBYNs = amount * RUB_rate;
            break;
    }
    
    switch (currencyInto)
    {
        case "USD" :
            result = temporaryBYNs / USD_rate;
            break;
        case "EURO" :
            result = temporaryBYNs / EURO_rate;
            break;
        case "RUB" :
            result = temporaryBYNs / RUB_rate;
            break;
    }
        
    Console.Write($"Exchange's result is {result*(1-cashFee):F} {currencyInto} ");
}

    CurrencyExchanger();