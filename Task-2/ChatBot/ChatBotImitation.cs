void ChatBotImitation()
{
    string dateString;
    var lastname = "";
    var name = "";
    DateTime date = default;
    DateTime dateNow;
    dateNow = DateTime.Now;

    Console.Write("Hello, enter your lastname ");
    lastname = Console.ReadLine();
    while (!lastname.All(Char.IsLetter))
    {
        Console.Write("Please, enter correct lastname ");
        lastname = Console.ReadLine();
    }


    Console.Write("Hello, enter your name ");
    name = Console.ReadLine();
    while (!name.All(Char.IsLetter))
    {
        Console.Write("Please, enter correct name ");
        name = Console.ReadLine();
    }

    Console.Write("Enter desired date and time of the appointment \"yyyy mm dd hh:mm\": ");
    dateString = Console.ReadLine();
    date = DateTime.Parse(dateString);
    while (dateNow.AddHours(1) > date)
    {
        Console.WriteLine("Enter correct date");
        dateString = Console.ReadLine();
        date = DateTime.Parse(dateString);
        break;
    }


    Console.WriteLine($"{lastname} {name}, You are booked in for an appointment:");
    Console.WriteLine($"{date:f}");
}

    ChatBotImitation();