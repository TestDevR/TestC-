# The maze game

Below, you'll find the instructions for getting started with your task. Please read them carefully to avoid unexpected issues. Best of luck!

## Time estimate

About 3 hours, plus the time to set up the codebase.

## Mandatory steps before you get started

1. Learn [how to get help](https://help.alvalabs.io/en/articles/9028899-how-to-ask-for-help-with-coding-tests) if you run into an issue with your coding test.

## The task

<!--TASK_INSTRUCTIONS_START-->
Your task is to implement a simple game where the player controls a character that moves around a 2D grid. The player can move the character up, down, left, or right. The character cannot move through walls or off the grid. The player wins the game when the character reaches a certain goal position. The game should be implemented in C#.

### Details

Write a C# program that implements the following:

1. Inside [Program.cs](Program.cs) implement the class Game that represents the game state. The class should have the following public methods:

    - `void MovePlayerUp()`: Moves the player up by one cell on the grid.
    - `void MovePlayerDown()`: Moves the player down by one cell on the grid.
    - `void MovePlayerLeft()`: Moves the player left by one cell on the grid.
    - `void MovePlayerRight()`: Moves the player right by one cell on the grid.
    - `bool IsPlayerAtGoal()`: Returns true if the player is at the goal position, false otherwise.
    - `bool IsValidPath()`: Returns true if there is a valid path from the player to the goal, false otherwise.
2. The game should be played on a 2D grid of size 5x5. The grid should be represented as a 2D array of integers, where 0 represents an empty cell, 1 represents a wall, and 2 represents the goal position.
3. The player should be represented by a class Player with two integer fields x and y representing the player's position on the grid.
4. The game should be played by repeatedly calling the MovePlayerUp(), MovePlayerDown(), MovePlayerLeft(), or MovePlayerRight() methods of the Game class depending on the user's input. The game should continue until the player reaches the goal position.
5. If the player tries to move through a wall or off the grid, the movement should be ignored.

### Constraints

- The input should be read from the standard input (stdin) and the output should be written to the standard output (stdout).
- The program should be implemented using only standard C# libraries, and should not rely on any third-party libraries or packages.

### Unit tests

We have provided a suite of unit tests that **you must make pass for your submission to be considered successful**.

To run the tests:

1. Compile the C# file using a C# compiler of your choice. For example, if you have `dotnet` installed, you can use the following command: `dotnet run Program.cs` (To spin up a preconfigured in-browser VSCode-based environment prepend this repository's URL with `https://gitpod.io/#` in the address bar in your browser and navigate to that URL - will require creating a Gitpod account).
2. The tests will run and output the results to the terminal. If all tests pass, you will see the message `{"test": "all unit tests", "result": "passed"}` at the end. If any tests fail, you will see an assertion failure message indicating which test failed and why.

### Solution expectations

1. Make the provided unit tests pass.
<!--TASK_INSTRUCTIONS_END-->

## When you are done

[Create a new Pull Request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request) from the branch where you've committed your solution code to the default branch of this repository. **Please do not merge the created Pull Request**.

---

Authored by [Alva Labs](https://www.alvalabs.io/).
