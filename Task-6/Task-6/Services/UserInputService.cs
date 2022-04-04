namespace Task_6.Services;

public class UserInputService
{
    public static string UserInput()
    {
        var userInput = Console.ReadLine();

        while (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
        {
            Messages.WrongInput();
            userInput = Console.ReadLine();
        }

        return userInput;
    }
}
