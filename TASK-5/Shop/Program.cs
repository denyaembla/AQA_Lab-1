using Shop;
using Shop.Models;

var result = UserFactory.GenerateFiveUsers();
UserFactory.DisplayEveryUser();
UserFactory.AddUserFromConsole();
UserFactory.DisplayEveryUser();
Filler.FillEveryUserBagRandomly(result);
Filler.DisplayUserAndHisBag();
Filler.AddOneItemToBagFromConsole();
Filler.DisplayPurchaseOfEveryUser(result);

