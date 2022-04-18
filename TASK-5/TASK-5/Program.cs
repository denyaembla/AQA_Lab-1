using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using Task_5;
using Task_5.Generators;
using Task_5.Models;

const int usersAmount = 5;
var result = Menu.GenerateUsers(usersAmount);
Menu.MainMenu(result);
