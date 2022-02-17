void ChatBotImitation()
{
    DateTime dateNow;
    dateNow = DateTime.Now;

    Console.Write("Hello, enter your lastname ");
    var lastname = Console.ReadLine();
    while (!lastname.All(Char.IsLetter) || string.IsNullOrWhiteSpace(lastname))
    {
        Console.Write("Please, enter correct lastname ");
        lastname = Console.ReadLine();
    }


    Console.Write("Hello, enter your name ");
    var name = Console.ReadLine();
    while (!name.All(Char.IsLetter) || string.IsNullOrWhiteSpace(name))
    {
        Console.Write("Please, enter correct name ");
        name = Console.ReadLine();
    }

    Console.Write("Enter desired date and time of the appointment \"yyyy mm dd hh:mm\": ");
    var dateString = Console.ReadLine();
    var appointmentDate = DateTime.Parse(dateString);
    
    while (dateNow.AddHours(1) > appointmentDate || String.IsNullOrWhiteSpace(dateString))
    {
        Console.WriteLine("Enter correct date");
        dateString = Console.ReadLine();
        appointmentDate = DateTime.Parse(dateString);
    }

    Console.WriteLine($"{lastname} {name}, You are booked in for an appointment:");
    Console.WriteLine($"{appointmentDate:f}");
    
}
    
    ChatBotImitation();

