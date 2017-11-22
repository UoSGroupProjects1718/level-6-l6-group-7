using UnityEngine;

public class Subject
{
    private string Name { get; set; }
    private int Id { get; set; }
    private int DifficultiesUnlocked { get; set; }
    public Color Colour { get; set; }

    public Subject(string name, int id, int difficultiesUnlocked, Color colour)
    {
        Name = name;
        id = Id;
        DifficultiesUnlocked = difficultiesUnlocked;
        Colour = colour;
    }
}
