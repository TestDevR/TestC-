using System;
using System.Collections.Generic;

namespace MazeGame
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Game
    {
        private int[,] _grid;
        private Player _player;
        private Player _goal;

        public Game(int[,] grid, Player player, Player goal)
        {
            _grid = grid;
            _player = player;
            _goal = goal;
        }

        public int[,] GetGrid()
        {
            return _grid;
        }

        public void MovePlayerUp()
        {
            if (_player.Y > 0 && _grid[_player.Y - 1, _player.X] != 1)
            {
                _player.Y--;
            }
        }

        public void MovePlayerDown()
        {
            if (_player.Y < 4 && _grid[_player.Y + 1, _player.X] != 1)
            {
                _player.Y++;
            }
        }

        public void MovePlayerLeft()
        {
            if (_player.X > 0 && _grid[_player.Y, _player.X - 1] != 1)
            {
                _player.X--;
            }
        }

        public void MovePlayerRight()
        {
            if (_player.X < 4 && _grid[_player.Y, _player.X + 1] != 1)
            {
                _player.X++;
            }
        }

        public bool IsPlayerAtGoal()
        {
            return _player.X == _goal.X && _player.Y == _goal.Y;
        }

        public bool IsValidPath()
        {
            bool[,] visited = new bool[5, 5];
            return IsValidPathHelper(_player.X, _player.Y, visited);
        }

        private bool IsValidPathHelper(int x, int y, bool[,] visited)
        {
            if (x < 0 || x >= 5 || y < 0 || y >= 5 || _grid[y, x] == 1 || visited[y, x])
            {
                return false;
            }

            if (x == _goal.X && y == _goal.Y)
            {
                return true;
            }

            visited[y, x] = true;

            return IsValidPathHelper(x + 1, y, visited) || IsValidPathHelper(x - 1, y, visited) ||
                   IsValidPathHelper(x, y + 1, visited) || IsValidPathHelper(x, y - 1, visited);
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            test_initial_state();
            test_move_player_right();
            test_move_player_left();
            test_move_player_up();
            test_move_player_down();
            test_move_player_through_wall();
            test_move_player_off_grid();
            test_win_game();
            test_is_valid_path();
            test_is_valid_path_1();
            test_is_not_valid_path();
            test_is_not_valid_path_1();
            Console.WriteLine("{\"test\": \"all unit tests\", \"result\": \"passed\"}");
        }

        static void test_initial_state()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            if (game.IsPlayerAtGoal())
            {
                throw new Exception("Error: Player is at the goal initially");
            }
        }

        static void test_move_player_right()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            game.MovePlayerRight();
            if (player.X != 3 || player.Y != 2)
            {
                throw new Exception("Error: Player did not move right");
            }
        }

        static void test_move_player_left()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            game.MovePlayerRight();
            game.MovePlayerLeft();
            if (player.X != 2 || player.Y != 2)
            {
                throw new Exception("Error: Player did not move left");
            }
        }

        static void test_move_player_up()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            game.MovePlayerRight();
            game.MovePlayerRight();
            game.MovePlayerUp();
            if (player.X != 4 || player.Y != 1)
            {
                throw new Exception("Error: Player did not move up");
            }
        }

        static void test_move_player_down()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            game.MovePlayerRight();
            game.MovePlayerRight();
            game.MovePlayerDown();
            if (player.X != 4 || player.Y != 3)
            {
                throw new Exception("Error: Player did not move down");
            }
        }

        static void test_move_player_through_wall()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            game.MovePlayerLeft();
            if (player.X != 2 || player.Y != 2)
            {
                throw new Exception("Error: Player moved through a wall");
            }
        }

        static void test_move_player_off_grid()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            game.MovePlayerRight();
            game.MovePlayerRight();
            game.MovePlayerRight();
            if (player.X != 4 || player.Y != 2)
            {
                throw new Exception("Error: Player moved off the grid");
            }
        }

        static void test_win_game()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 3, Y = 4 };
            Game game = new Game(grid, player, goal);
            game.MovePlayerRight();
            game.MovePlayerRight();
            game.MovePlayerDown();
            game.MovePlayerDown();
            game.MovePlayerLeft();
            if (!game.IsPlayerAtGoal())
            {
                throw new Exception("Error: Player did not win the game");
            }
        }

        static void test_is_valid_path()
        {
            int[,] grid = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 2, 0},
            };
            Player player = new Player { X = 2, Y = 2 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            if (!game.IsValidPath())
            {
                throw new Exception("Error: Path is not valid");
            }
        }

        static void test_is_valid_path_1()
        {
            int[,] grid = {
                {0, 1, 0, 0, 0},
                {0, 1, 0, 1, 0},
                {0, 1, 0, 1, 0},
                {0, 1, 0, 1, 0},
                {0, 0, 0, 1, 2},
            };
            Player player = new Player { X = 0, Y = 0 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            if (!game.IsValidPath())
            {
                throw new Exception("Error: Path is valid, but isValidPath returned false");
            }
        }

        static void test_is_not_valid_path_1()
        {
            int[,] grid = {
                {0, 1, 0, 1, 0},
                {0, 1, 0, 1, 0},
                {0, 1, 0, 1, 0},
                {0, 1, 0, 1, 0},
                {0, 0, 0, 1, 2},
            };
            Player player = new Player { X = 0, Y = 0 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            if (game.IsValidPath())
            {
                throw new Exception("Error: Path is not valid, but isValidPath returned true");
            }
        }

        static void test_is_not_valid_path()
        {
            int[,] grid = {
                {0, 1, 0, 0, 0},
                {0, 1, 0, 1, 0},
                {0, 1, 0, 1, 0},
                {0, 1, 0, 1, 1},
                {0, 0, 0, 1, 2},
            };
            Player player = new Player { X = 0, Y = 0 };
            Player goal = new Player { X = 4, Y = 3 };
            Game game = new Game(grid, player, goal);
            if (game.IsValidPath())
            {
                throw new Exception("Error: Path is not valid, but isValidPath returned true");
            }
        }
    }
}
