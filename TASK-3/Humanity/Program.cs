    
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;
    using System.Text.Json;
    using Bogus;
    using Bogus.DataSets;
    using Humanity;

    var randomSalary = new Random();
    var count = new Random();
    
    var candidatesList = new List<Candidate>();
        
    for (var i = 0; i < count.Next(2,5); i++)
    {
        candidatesList.Add(new Faker<Candidate>().CustomInstantiator(fake => new Candidate(
            new Guid(),
            fake.Name.FirstName(),
            fake.Name.LastName(),
            fake.Name.JobTitle(),
            fake.Name.JobDescriptor(),
            randomSalary.Next(500, 2500))));
    }
    
    foreach (var value in candidatesList)
    {
        Console.WriteLine(JsonSerializer.Serialize(value));
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
/* var employee1 = new Employee("Dude", "Dudskii", "Engineer", 1000, "HornsAndHoofs",
        "Russia", "Zelenograd", "Krasnoarmeyskaya");

    var candidate1 = new Candidate(new Guid() ,"Travis", "Barker", "Drummer", "at pop-punk band Blink-182", 1400);
    
    employee1.Display();
    
    candidate1.Display(); */

    /* var userFaker = new Faker<Candidate>()
         .CustomInstantiator(fake => new Candidate(
             new Guid(),
             fake.Name.FirstName(),
             fake.Name.LastName(),
             fake.Name.JobTitle(),
             fake.Name.JobDescriptor(),
             randomSalary.Next(500, 2500)));
     var fakerino = userFaker.Generate(); */
