namespace LabManager.Models;

class Lab
{
    public int Id { get; set; }
    public int Number { get; set; }
    public String Name { get; set; }
    public Char Block { get; set; }

    public Lab() {}

    public Lab(int id, int number, String name, Char block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }
}