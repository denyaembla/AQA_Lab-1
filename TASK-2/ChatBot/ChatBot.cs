namespace ChatBot;

public class ChatBot
{
   public static void ChatBotImitation()
   {
      var dateNow = DateTime.Now;
      Console.Write("Hello, enter your lastname ");
      var lastname = Console.ReadLine();
      var lastnameArray = lastname.Where(char.IsLetter).ToArray();
      lastnameArray[0] = char.ToUpper(lastnameArray[0]);
      
      Console.Write("Hello, enter your name ");
      var name = Console.ReadLine();
      var nameArray = name.Where(char.IsLetter).ToArray();
      nameArray[0] = char.ToUpper(nameArray[0]);
      
      Console.WriteLine($"Enter desired date and time of the appointment \"yyyy mm dd\": ");
      var dateString = Console.ReadLine();
      var appointmentDate = Convert.ToDateTime(dateString);
      
      while (dateNow.AddHours(1) > appointmentDate || String.IsNullOrWhiteSpace(dateString))
      {
         Console.WriteLine("Enter correct date");
         dateString = Console.ReadLine();
         appointmentDate = Convert.ToDateTime(dateString);
      }
      
      Console.WriteLine(new string(lastnameArray)+ " " + new string(nameArray)
                        + " You are booked in for an appointment:");
      Console.WriteLine($"{appointmentDate:d}");

   }

}
