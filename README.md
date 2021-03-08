# CommandLineArgumentsHandler
A simple command line argument handler written in C# using .NET 5.0. For those unsure, command line arguments are basically options specified for a certain application, either upon launching from another application or from specifying them in an application shortcut's properties. For example, "Application1.exe -L C:\Users\User1\Desktop"

# How to implement this in a program of yours

First, you'll want to either download the .DLL located in the tags option, or you can even download the source code for this and then compile it yourself - which should output a .DLL. Keep in mind that you only need the .DLL itself - no .json runtime files or whatever. Also keep in mind that this uses .NET 5.0. Once you are done, create a new C# project and then reference the .DLL that you have either compiled or downloaded.

Now, with your C# project, you will want to type in "using CommandLineArgumentsHandler;" at the top of your code. If you would to interact with command-line arguments, your Main() method will require its one argument to be an array of string type in order to catch all command line arguments. 

Now, this is the part where you can pretty much use CommandLineArgumentsHandler. But first, before using that, you might want to specify any arguments that can be used to ask for help. CommandLineArgumentsHandler.CommandLine has a list of string type called HelpArguments, which you can append all sorts of help arguments to. For example, you can do "CommandLine.HelpArguments.Add("-?");".

At this point, you can finally interpret all arguments! You will want to call the CommandLineArgumentsHandler.CommandLine.SimplifyArgs() method (CommandLine.SimplifyArgs() if "using CommandLineArgumentsHandler;" is mentioned) in order to do this. This will return either a string or list (not array - list, which is part of System.Collections.Generic), so if you are to collect the value returned by SimplifyArgs(), it is best that you specify "var VARIABLENAME = CommandLineArgumentsHandler.CommandLine.SimplifyArgs();", rather than specify "string" or "List<T>" or whatever. When using SimplifyArgs, there is one primary argument that you have to specify, and that is a string array containing all of the command line arguments. There are two additional options - AllowRawArguments (allow arguments without a flag specifying its value, however raw arguments cannot be specified after any argument that DOES use a flag) and AllowDuplicateFlags (basically allow more than one flag being specified at one time) - both of which have their values set to false. Keep in mind that they are both boolean values as well. You can specify whatever to them by specifying VARIABLENAME: BOOL as an argument when calling the SimplifyArgs method. For example, "SimplifyArgs(new string[] { "hello", "-there", "world" }, AllowRawArguments: true)"
  
List of values that are returned when using SimplifyArgs():

String - "No command-line arguments have been specified."

String - "One or more flags have been specified incorrectly."

String - "Duplicate flags found although duplicate flags are disallowed."

String - "You can not specify raw arguments without a flag after arguments specified with both a flag and its value."

String - "You can not specify raw arguments without a flag, due to the option being disabled."

String - "A specified flag is missing its value."

List<dynamic> - AllArguments
  
Wait, why does it "List<dynamic>" and not "List<WhateverType>"? Well, the list actually can contain both lists of string type or just simply a string. Raw arguments will be placed into the list as a string, while arguments with specified flags will be a List of string type. The first argument of this sub-list will be the flag specified WITHOUT the dash at the start, while the second argument of this sub-list will be value of the argument specified.
  
Leave a comment if you have any suggestions, and have fun!
