using Shop;
using Shop.Models;

var result = UserFactory.GenerateRandomAmountOfUsers();
UserFactory.AddUserFromConsole();
UserFactory.DisplayEveryUser();
Filler.FillEveryUserBagRandomly(result);
Filler.AddOneItemToBagFromConsole();
Filler.DisplayPurchaseOfEveryUser(result);
Filler.DisplayUserAndHisBag();
