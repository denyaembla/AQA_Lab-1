using System.ComponentModel.Design;
using Task_5;
using Task_5.Models;

const int usersAmount = 5;
var result = Menu.GenerateUsers(usersAmount);
Menu.MainMenu(result);
