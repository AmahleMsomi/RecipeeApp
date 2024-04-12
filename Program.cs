using System;
namespace POEPART_1
{
    // Create an ingredient class
    class Ingredient
    {
        public string IngredientName { get; set; } // Ingredient name
        public double Quantity { get; set; } // Ingredient Quantity
        public string Unit { get; set; } // Unit of measurement 
    }

    // class to represent steps for recipe
    class RecipeStep
    {
        public string Description { get; set; } // Description of the step
    }

    // Define Recipe class to represent a recipe
    class Recipe
    {
        public string Name { get; set; } // Name of the recipe
        public Ingredient[] Ingredients { get; set; } // Array to store number ingredients that are going to be used
        public RecipeStep[] Steps { get; set; } // Array to store number of steps in recipe

        // initialize recipe 
        public Recipe(string name, Ingredient[] ingredients, RecipeStep[] steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        // method to scale ingredients
        public void ScaleIngredients(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // method to clear the recipe data
        public void ClearRecipe()
        {
            Console.WriteLine("Do you want to clear the recipe? (yes/no)");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                Name = "";
                Ingredients = null;
                Steps = null;
                Console.WriteLine("Recipe cleared.");
            }
            else
            {
                Console.WriteLine("Recipe not cleared.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Prompt user to enter recipe details
                Console.WriteLine("Enter Recipe Details:");

                // Asks user for recipe name
                Console.Write("Recipe Name: ");
                string recipeName = Console.ReadLine();

                //asks user for number of ingredients they going to use
                Console.Write("Number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());

                // Array to store ingredients
                Ingredient[] ingredients = new Ingredient[numIngredients];

                // Loop to collect each Ingredient
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"\nEnter details for ingredient {i + 1}:");
                    Console.Write("Ingredient Name: ");
                    string name = Console.ReadLine();

                    Console.Write($"Quantity:  ");
                    double quantity = double.Parse(Console.ReadLine());
                    

                    Console.Write("Unit: ");
                    string unit = Console.ReadLine();

                    ingredients[i] = new Ingredient { IngredientName = name, Quantity = quantity, Unit = unit };
                }

                // Prompt user on how many steps are there going to be
                Console.Write("Enter number of steps in recipe: ");
                int numSteps = int.Parse(Console.ReadLine());

                // Array to store recipe steps
                RecipeStep[] steps = new RecipeStep[numSteps];

                // Loop to collect detail for each step
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"\nEnter details for step {i + 1}: ");
                    Console.Write("Description: ");
                    string description = Console.ReadLine();

                    steps[i] = new RecipeStep { Description = description };
                }

                // Recipe object 
                Recipe recipe = new Recipe(recipeName, ingredients, steps);

                // Display recipe details
                DisplayRecipe(recipe);

                // Prompt user to enter factor to scale by
                Console.WriteLine("Enter factor you wish to scale by:");
                double scale = Convert.ToDouble(Console.ReadLine());
                recipe.ScaleIngredients(scale);

                // Display updated recipe details after scaling
                DisplayRecipe(recipe);

                Console.WriteLine("Do you wish to enter another recipe? \n select (yes/no)");
                string response = Console.ReadLine();
                if (response.ToLower() != "yes")
                    break;
                else
                    recipe.ClearRecipe();
            }
        }

        // Method to display recipe details
        static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Recipe Details: ");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Recipe Name: {recipe.Name}");


            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.IngredientName}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Length; i++)
            {
                Console.WriteLine($"Step {i + 1}: {recipe.Steps[i].Description}");
            }
            Console.WriteLine("--------------------");
        }
    }
}

