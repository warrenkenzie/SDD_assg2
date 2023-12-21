// main menu
// MenuOption is the option the user decides
int MenuOption;
while (true)
{
    // exception handling
    try
    {
        // MenuOption is the option the user decides
        MenuOption = DisplayMenu();
           
        // exception handling for integer out of range
        if(MenuOption < 4 & MenuOption > 0)
        {
            break;
        }
        else
        {
            // when person inputs an integer out of range
            Console.WriteLine("\nWrong Input\n");
            continue;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("\n" + ex.Message + "\n");
    }
}

// start of game loop
// The game field is a list which contains lists and represents the field. For now it only accepts strings but can later be changed to objects
List<List<string>> game_field = new List<List<string>>();

// Initialises the field currently with string ""
InitializeField();

while (true)
{
    if(MenuOption == 1) // Start New Game
    {
        // displays the game_field on a console
        DisplayField(game_field);
        break;      //added break as it is a while loop  
        //TODO game logic :

    }
    else if(MenuOption == 2) // Display High Scores
    {


    }
    else if(MenuOption == 3) // Load Saved Game
    { 
        
    
    }
    else if(MenuOption == 4) // Exit Game
    {

    }
}

// displays the main menu and returns the which option the user chooses
int DisplayMenu()
{
    // diplay the menu
    Console.WriteLine("Main Menu");
    Console.WriteLine("1. Start New Game");
    Console.WriteLine("2. Display High Scores");
    Console.WriteLine("3. Load Saved Game");
    Console.WriteLine("4. Exit Game");
    Console.Write("Choose an option: ");

    // the option the user chooses will be stored in this variable
    int MenuOption = Convert.ToInt32(Console.ReadLine());

    return MenuOption;
}

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

