// The game field is a list which contains lists and represents the field. For now it only accepts strings but can later be changed to objects
using SDD_assg2;
using System.Text.RegularExpressions;

List<List<Building?>> game_field = new List<List<Building?>>();
List<Building> list_of_Buildings = new List<Building>(); // contains the list of buildings that can be selected
// turn counter
int turn;
int totalCoins;
bool gameContinue;

// MAIN MENU
int MenuOption; // MenuOption is the option the user decides

while (true)
{
    // exception handling
    try
    {
        // MenuOption is the option the user decides
        MenuOption = DisplayMenu();
           
        // exception handling for integer out of range
        if(MenuOption < 5 & MenuOption > 0)
        {
            // clear main menu after choosing an option
            Console.Clear();
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

if(MenuOption == 1) // Start New Game
{
    // START OF GAME LOOP
    turn = 0; 
    totalCoins = 1;
    gameContinue = true;
   
    // Initialises the field currently with null
    InitializeField();
    // Initialises the list of Buildings
    InitializeBuildingInformation();

    // randomly choose 2 buildings for user to select
    List<Building> list_of_2_random_buildings_selected = Generate_list_of_2_random_buildings_selected();

    // prompts user which building to choose and prompt user to designate where to place the building
    bool If_have_exceptions = true;
    do
    {
        try
        {
            // show the 2 random buildings selected
            Console.WriteLine("Choose your first building: ");
            for (int i = 0; i < list_of_2_random_buildings_selected.Count(); i++)
            {
                Console.WriteLine((i + 1) + ". " + list_of_2_random_buildings_selected[i].BuildingName +  "  " + list_of_2_random_buildings_selected[i].BuildingAcronym);
            }

            // prompt user to choose building
            Console.Write("Choose a building to select: ");
            int indexOf_random_buildings_selected = Convert.ToInt32(Console.ReadLine()) - 1;

            if(totalCoins == 0)
            {
                Console.WriteLine("Insufficient coins!");
                break;
            }

            // check if the number is not out of range
            if(indexOf_random_buildings_selected == 0 || indexOf_random_buildings_selected == 1)
            {
                // displays the game_field on a console
                DisplayField(game_field);

                //prompt user to designate where to place the building
                do
                {
                    try
                    {
                        Console.Write("Select where to place the building (e.g A1): "); 
                        string placement = Convert.ToString(Console.ReadLine());
                        // validate the user's input
                        bool placementSuccessful = PlaceBuilding(placement, list_of_2_random_buildings_selected[indexOf_random_buildings_selected]);
                        if (placementSuccessful)
                        {
                            Console.WriteLine("Place Successfully");
                            turn += 1;
                            If_have_exceptions = false; break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n" + ex.Message + "\n");
                    }
                } while (true);
            }
            else
            {
                // if index out of range
                Console.Clear();
                Console.WriteLine("\nWrong Input\n");
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("\n" + ex.Message + "\n");
        }
    } while (If_have_exceptions); // Continue the loop until no exception occur (which means chooses correct building)

    // THE REST OF THE GAME LOOP    
    while (gameContinue)
    {
        // displays the game_field on a console
        DisplayField(game_field);
        
        // prompt user what action they want to choose
        try
        {
            Console.WriteLine("Turn " + turn);
            Console.WriteLine("Total Coins: " + totalCoins + " (1 Building = 1 Coin)");
            Console.WriteLine("Choose your action: \n" +
                               "1. Build Building\n" +
                               "2. Next Turn");
            Console.Write("Choose: ");
            int userAction = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (userAction == 1) // Build a building
            {
                try
                {
                    do
                    {
                        if (totalCoins == 1)
                        {
                            string suicideOption;
                            Console.Write("Are you sure? The game will end when you run out of coins. (Y/N)? ");
                            suicideOption = Console.ReadLine().ToUpper();

                            if (suicideOption == "Y")
                            {
                                gameContinue = false;
                                break;
                                // TO DO END-GAME DISPLAY
                            }

                            else
                            {
                                break;
                            }
                        }

                        totalCoins--;

                        for (int i = 0; i < list_of_Buildings.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + list_of_Buildings[i].BuildingName + "  " + list_of_Buildings[i].BuildingAcronym);
                        }
                        Console.WriteLine("6. Exit Build Buidling");

                        // Choose a building
                        Console.Write("Choose a Building: ");
                        int chosenBuilding_index = Convert.ToInt32(Console.ReadLine());
                        // if the person decided to no longer choose a building, exit the Build a Buidling menu
                        if (chosenBuilding_index == 6)
                        {
                            break;
                        }

                        // if the person chose a buidling
                        Building chosenBuilding = list_of_Buildings[chosenBuilding_index - 1];

                        // choose a location
                        Console.Write("Choose location(e.g A1): ");
                        string chosenplacement = Convert.ToString(Console.ReadLine());

                        if (PlaceBuilding(chosenplacement, chosenBuilding))
                        {
                            break;
                        }
                    } while (true);
                }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n" + ex.Message + "\n");
                    }
                }
            
            else if (userAction == 2) // next turn
            {
                try
                {

                    Console.Write("Next turn?(y/n): ");
                    string y_n_nextTurn = Console.ReadLine();
                    Console.WriteLine();
                    if (y_n_nextTurn == "y")
                    {
                        NextTurn();
                        Console.Clear();
                    }
                    else if (y_n_nextTurn == "n")
                    {

                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message + "\n");
                }
            }
            else
            {
                Console.WriteLine("\n" + "No Option" + "\n");
            }
        }
        catch(Exception ex) 
        {
            Console.WriteLine("\n" + ex.Message + "\n");
        }      
    }
}
else if(MenuOption == 2) // Display High Scores
{


}
else if(MenuOption == 3) // Load Saved Game
{ 
        
    
}
else if(MenuOption == 4) // Exit Game
{
    Console.WriteLine("Exiting the game...");
    Environment.Exit(0);
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
        List<Building?> row_field = new List<Building?>();
        game_field.Add(row_field);
        for (int col = 0; col < 20; col++)
        {
            game_field[row].Add(null);
        }
    }
}

// Displays the field
void DisplayField(List<List<Building?>> game_field)
{
    List<string> list_of_alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    bool placeAlphabet = true; // boolean value that if the alphabets have been placed on the left side

    // prints out the numbers on the x axis of the field
    Console.Write(string.Format(" "));
    for (int i = 0; i < 5; i++)
    {
        Console.Write(string.Format("  {0}", i + 1));
    }
    Console.WriteLine();

    for (int row = 0; row < game_field.Count(); row++)
    {
        // Generate the row of the game_field
        Console.Write(string.Format("{0}+--", " "));
        Console.Write(string.Concat(Enumerable.Repeat("+--", game_field[row].Count - 1)));
        Console.WriteLine("+");

        placeAlphabet = true;

        // thickness is the thickness of a row
        for (int thickness = 0; thickness < 1; thickness++)
        {
            for (int col = 0; col < game_field[row].Count(); col++)
            {
                // if its the first col, print empty space
                if(placeAlphabet == true)
                {   
                    if(thickness == 0)
                    {
                        // print the alphabet at the first col
                        Console.Write(list_of_alphabets[row]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                if (thickness == 0)
                {
                    if (game_field[row][col] != null)
                    {
                        Console.Write(string.Format("|{0}", game_field[row][col].BuildingAcronym));
                    }
                    else
                    {
                        Console.Write("|  ");
                    }
                }

                // if col is 0, turn placeAlphabet so the subsequent columns dont have alphabet
                if (col == 0)
                {
                    placeAlphabet = false;
                }
                // if col is the last one, turn placeAlphabet to true so that the next col prints alphabet
                if (col == game_field[row].Count() - 1)
                {
                    placeAlphabet = true;
                }
            }
            Console.WriteLine("|");
           
        }
        
    }

    // Generate the last row of the game_field
    Console.Write(string.Format("{0}+--", " "));
    Console.Write(string.Concat(Enumerable.Repeat("+--", game_field[0].Count - 1)));
    Console.WriteLine("+");
}

void InitializeBuildingInformation()
{
    list_of_Buildings.Add(new Building("Industry", "IN"));
    list_of_Buildings.Add(new Building("Residential", "RE"));
    list_of_Buildings.Add(new Building("Commercial", "CC"));
    list_of_Buildings.Add(new Building("Park", "OO"));
    list_of_Buildings.Add(new Building("Road", "**"));
}

// choose 2 random different buildings from list_of_Buildings
List<Building> Generate_list_of_2_random_buildings_selected()
{
    // Create an instance of the Random class
    Random random = new Random();
    List<Building> list_of_2_random_buildings_selected = new List<Building>();

    // Generate the first random index
    int randomNumber1 = random.Next(0, list_of_Buildings.Count());

    int randomNumber2;
    // Generate the second random index and if its equal to first random index loop it until it is different
    do
    {
        randomNumber2 = random.Next(0, list_of_Buildings.Count());
    } while (randomNumber2 == randomNumber1);

    list_of_2_random_buildings_selected.Add(list_of_Buildings[randomNumber1]);
    list_of_2_random_buildings_selected.Add(list_of_Buildings[randomNumber2]);

    return list_of_2_random_buildings_selected;
}


// check placement inputted by user
// returns true if the placement is correct and there is nothing placed in the placement selected
// returns false if placement is not correct
bool CheckPlacement(string placement)
{
    List<string> list_of_alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    // Define the regular expression pattern 
    string pattern = @"^[A-Z](?!0\d)\d{1,2}$";
    // Use Regex.IsMatch to check if the input matches the pattern and if the placement is within the field, so just check if there is an alphabet and number 
    if (Regex.IsMatch(placement, pattern) == true)
    {
        // check if its within the game_field
        int placement_row_index = list_of_alphabets.IndexOf(Convert.ToString(placement[0])) + 1;
        int placement_col_index = int.Parse(placement.Substring(1));

        if (placement_col_index <= game_field[0].Count && placement_row_index <= game_field.Count) 
        {
            // if the designated place is not null
            if (game_field[placement_row_index - 1][placement_col_index - 1] != null)
            {
                return false;
            }
            else
            {
                if (turn == 0)
                {
                    // true if the space is empty
                    return true;
                }
                else
                {
                    // assuming start count from 0
                    int numRows = game_field.Count;
                    int numCols = game_field[0].Count;
                    int rowIndex = placement_row_index - 1;
                    int colIndex = placement_col_index - 1;

                    // Check additional positions for corners and sides
                    if (rowIndex == 0 && colIndex == 0) // Top-left corner
                    {
                        return (game_field[rowIndex][colIndex + 1] != null) ||  // Right
                               (game_field[rowIndex + 1][colIndex] != null);  // Below
                    }
                    else if (rowIndex == 0 && colIndex == numCols - 1) // Top-right corner
                    {
                        return (game_field[rowIndex][colIndex - 1] != null) ||  // Left
                               (game_field[rowIndex + 1][colIndex] != null);  // Below
                    }
                    else if (rowIndex == numRows - 1 && colIndex == 0) // Bottom-left corner
                    {
                        return (game_field[rowIndex][colIndex + 1] != null) ||  // Right
                               (game_field[rowIndex - 1][colIndex] != null);  // Above
                    }
                    else if (rowIndex == numRows - 1 && colIndex == numCols - 1) // Bottom-right corner
                    {
                        return (game_field[rowIndex][colIndex - 1] != null) ||  // Left
                               (game_field[rowIndex - 1][colIndex] != null);  // Above
                    }
                    else if (rowIndex == 0) // Top side (excluding corners)
                    {
                        return (game_field[rowIndex][colIndex - 1] != null) ||  // Left
                               (game_field[rowIndex][colIndex + 1] != null) ||  // Right
                               (game_field[rowIndex + 1][colIndex] != null);  // Below
                    }
                    else if (rowIndex == numRows - 1) // Bottom side (excluding corners)
                    {
                        return (game_field[rowIndex][colIndex - 1] != null) ||  // Left
                               (game_field[rowIndex][colIndex + 1] != null) ||  // Right
                               (game_field[rowIndex - 1][colIndex] != null);  // Above
                    }
                    else if (colIndex == 0) // Left side (excluding corners)
                    {
                        return (game_field[rowIndex - 1][colIndex] != null) ||  // Above
                               (game_field[rowIndex + 1][colIndex] != null) ||  // Below
                               (game_field[rowIndex][colIndex + 1] != null);  // Right
                    }
                    else if (colIndex == numCols - 1) // Right side (excluding corners)
                    {
                        return (game_field[rowIndex - 1][colIndex] != null) ||  // Above
                               (game_field[rowIndex + 1][colIndex] != null) ||  // Below
                               (game_field[rowIndex][colIndex - 1] != null);  // Left
                    }
                    else if((rowIndex > 0 && rowIndex < numRows) && (colIndex > 0 && colIndex < numCols)) // for checking all 4 sides
                    {
                        return (rowIndex > 0 && game_field[rowIndex - 1][colIndex] != null) ||  // Above
                                (rowIndex < numRows - 1 && game_field[rowIndex + 1][colIndex] != null) ||  // Below
                                (colIndex > 0 && game_field[rowIndex][colIndex - 1] != null) ||  // Left
                                (colIndex < numCols - 1 && game_field[rowIndex][colIndex + 1] != null); // right
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
}

// check placement inputted by user
// returns true if placed successfully
// returns false if placement is successful
bool PlaceBuilding(string placement,Building building)
{
    List<string> list_of_alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    if (CheckPlacement(placement))
    {
        int placement_row_index = list_of_alphabets.IndexOf(Convert.ToString(placement[0]));
        int placement_col_index = int.Parse(placement.Substring(1)) - 1;

        game_field[placement_row_index][placement_col_index] = building;
        return true;
    }
    else
    {
        return false;
    }
}

void NextTurn()
{
    turn += 1;
}