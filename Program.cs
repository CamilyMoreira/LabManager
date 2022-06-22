//Connection
using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig(); //objeto; n precisa ficar criando nas classes 

var databaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

var labRepository = new LabRepository(databaseConfig);

//Routing
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")

{
    if (modelAction == "List")
    {
        Console.WriteLine("List Computer");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }
    }

    if (modelAction == "New")
    {
        Console.WriteLine("New Computer");
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

        var computer = new Computer(id, ram, processor);

        computerRepository.Save(computer);
    }

    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
        else
        {
            Console.WriteLine($"O computador {id} não existe");
        }
    }

    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            var ram = args[3];
            var processor = args[4];

            var computer = new Computer(id, ram, processor);

            computer = computerRepository.Update(computer);
        }
        else
        {
            Console.WriteLine($"O computador {id} não existe");
        }

    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            computerRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O computador {id} não existe");
        }
        
    }
}

if(modelName == "Lab")
{
    if (modelAction == "List")
    {
        Console.WriteLine("List Lab");
        foreach (var lab in labRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", lab.Id, lab.Number, lab.Name, lab.Block);
        }
    }

    if (modelAction == "New")
    {
        Console.WriteLine("New Lab");
        var id = Convert.ToInt32(args[2]);
        var number = Convert.ToInt32(args[3]);
        var name = args[4];
        var block = Convert.ToChar(args[5]);

        var lab = new Lab(id, number, name, block);

        labRepository.Save(lab);
    }

    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var lab = labRepository.GetById(id);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
        else
        {
            Console.WriteLine($"O laboratorio {id} não existe");
        }
    }

    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var number = Convert.ToInt32(args[3]);
            var name = args[4];
            var block = Convert.ToChar(args[5]);

            var lab = new Lab(id, number, name, block);

            lab = labRepository.Update(lab);
        }
        else
        {
            Console.WriteLine($"O laboratorio {id} não existe");
        }

    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            labRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O laboratorio {id} não existe");
        }
        
    }
}