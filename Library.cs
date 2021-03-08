// Made by Quevidia.
// 2021

using System.Collections.Generic;

namespace CommandLineArgumentsHandler
{
    public class CommandLine
    {
        public static List<string> HelpArguments = new List<string>(); // Define a variable of type string list that will contain any strings used for if a user requires assistance with the command line arguments.

        public static dynamic SimplifyArgs(string[] Args, bool AllowRawArguments = false, bool AllowDuplicateFlags = false) // Make a method called SimplifyArgs that will return any type of possible object. The one argument necessary will be a string array called Args, which will be all of the necessary command-line arguments. The rest of the arguments provided are optional and have default values set to them.
        {
            if (Args.Length == 0) return "No command-line arguments have been specified."; // If the length of the arguments array is 0, then return a string saying that no command-line args have been specified.
            if (!HelpArguments.Contains(Args[0])) // Check if the first argument is not in the HelpArguments property.
            {
                // Set up all base values.
                List<List<string>> AllArguments = new List<List<string>>(); // Create a list of type list of type string that will contain all arguments to return back. By default, this list will contain an empty list of type string.
                List<string> SpecifiedFlags = new List<string>(); // Create a list of type string that will contain all specified flags. This will be used to look for duplicated flags if AllowDuplicateFlags is false.
                bool GoingThroughSubList = false; bool FinishedNoFlagArguments = false; // Create a bool variable called GoingThroughSubList which will depict whether the 2nd entry of a sub-list in the AllArguments list is being gone through. Then, create another bool variable called FinishedNoFlagArguments, which will depict whether no-flag arguments are allowed or not after a certain point.
                int CurrentPlacement = 0; // Create an integer variable called CurrentPlacement which will depict the current placement in an array.

                // Sort out all arguments.
                foreach (string Argument in Args) // Go through all of the arguments specified in the Args array.
                {
                    if (GoingThroughSubList) // Check if GoingThroughSubList is true.
                    {
                        string ArgToUse = Argument; // Create a new string that will originally contain the same info as Argument. This will be modified in the try/catch statement if there are no exceptions.
                        AllArguments[CurrentPlacement].Add(ArgToUse); // Add ArgToUse onto the AllArguments[CurrentPlacement] sub-list.
                        CurrentPlacement++; GoingThroughSubList = false; // Increment CurrentPlacement, then set GoingThroughSubList to false.
                    }
                    else // If GoingThroughSubList is false instead, the code in this scope will run instead.
                    {
                        if (Argument[0] == '-') // Check if the first character of Argument is a dash.
                        {
                            if (Argument.Length <= 1) return "One or more flags have been specified incorrectly."; // Check if Argument's length is equal to or smaller than 1. If so, return a string saying that the flag was specified incorrectly.
                            if (!AllowDuplicateFlags && SpecifiedFlags.Contains(Argument)) return "Duplicate flags found although duplicate flags are disallowed."; // If SpecifiedFlags contains Argument and AllowDuplicateFlags is false, return a string telling the user that a duplicated flag has been found although they are disallowed.
                            AllArguments.Add(new List<string>()); // Add a new list of type string to the AllArguments list.
                            AllArguments[CurrentPlacement].Add(Argument.Substring(1)); SpecifiedFlags.Add(Argument); // Add Argument with its first character trimmed off onto the AllArguments[CurrentPlacement] sub-list, then add Argument to the SpecifiedFlags list.
                            GoingThroughSubList = true; FinishedNoFlagArguments = true; // Set both GoingThroughSubList and FinishedNoFlagArguments to true.
                        }
                        else // If the first character of Argument is not a dash, the code in this scope will run.
                        {
                            if (FinishedNoFlagArguments) return "You can not specify raw arguments without a flag after arguments specified with both a flag and its value."; // If FinishedNoFlagArguments is true, return a string telling the user that there is a raw argument in the wrong place.
                            if (!AllowRawArguments) return "You can not specify raw arguments without a flag, due to the option being disabled."; // If AllowRawArguments is false, return a string telling the user that raw arguments are disallowed.
                            AllArguments.Add(new List<string> { Argument }); CurrentPlacement++; // Add a new list of type string holding only the value of Argument onto the AllArguments list, then increment CurrentPlacement.
                        }
                    }
                }
                if (GoingThroughSubList) return "A specified flag is missing its value."; // if GoingThroughSubList is true, return a string telling the user that there is a flag without any value.
                return AllArguments; // Return the final list!
            }
            else return "User asked for help."; // Return a string saying that the user requires assistance, if the first argument is in the HelpArguments property.
        }
    }
}