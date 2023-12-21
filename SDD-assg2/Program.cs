// The game field is a list which contains lists and represents the field. For now it only accepts strings but can later be changed to objects
List<List<string>> game_field = new List<List<string>>();

// Initialises the field currently with string ""
InitializeField();

// displays the game_field on a console
DisplayField(game_field);

// initialises the variable game_field from being empty
void InitializeField()
{
    for (int row = 0; row < 20; row++)
    {
        List<string> row_field = new List<string>();
        game_field.Add(row_field);
        for (int col = 0; col < 20; col++)
        {
            game_field[row].Add("");
        }
    }
}

// Displays the field
void DisplayField(List<List<string>> game_field)
{
    for (int row = 0; row < game_field.Count(); row++)
    {
        // Generate the row of the game_field
        Console.Write(string.Concat(Enumerable.Repeat("+-----", game_field[row].Count)));
        Console.WriteLine("+");



        for (int thickness = 0; thickness < 3; thickness++)
        {
            for (int col = 0; col < game_field[row].Count(); col++)
            {
                Console.Write("|     ");
            }
            Console.WriteLine("|");
        }
    }

    Console.Write(string.Concat(Enumerable.Repeat("+-----", game_field[0].Count)));
    Console.WriteLine("+");
}
