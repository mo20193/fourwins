

namespace fourwins
{
    internal class Program
    {
        public static int[,] _fields = new int[6, 7];
        public static Random _random = new Random();
        public const int ZAHL = 5;
        public static int counter = 1;

        public static int roundPlayerOne = 1;
        public static int roundPlayerFive = 1;

        static void Main(string[] args)
        {

            InitializeArray();
            //Init Players
            var playerOne = new Player("Player One", 1);
            var playerFive = new Player("Player Five", 5);

            do
            {
                if (PlayingFieldConatinsEmptySpace())
                {
                    var success = false;

                    do
                    {
                        success = GetXYAndCheck(playerOne);

                        Console.WriteLine("Player One Turn: " + roundPlayerOne);

                    } while (!success);

                    InsertValue(playerOne);

                    IsWinning(playerOne);

                }
                else
                {
                    Console.WriteLine("We have a draw!");
                }

                ShowField(_fields);
                Console.ReadKey();

                roundPlayerOne++;

                //if (PlayingFieldConatinsEmptySpace())
                //{
                //    do
                //    {
                //        var column = GetColumn();
                //        playerFive.Y = column;

                //        //Console.WriteLine("Player Five Turn: " + roundPlayerFive);

                //    } while (!GetXYAndCheck(playerFive));
                //}
                //else
                //{
                //    Console.WriteLine("We have a draw!");
                //}

                //roundPlayerFive++;

                //if(IsWinning(playerOne))
                //{
                //    ShowWinner(playerOne);

                //    break;
                //}

            } while (!IsEndOfTheGame());
        }

        public static void IsWinning(Player player)
        {
            //CheckDown(player);
            //Console.WriteLine("Down: " + counter);
            //counter = 1;

            CheckRight(player);
            Console.WriteLine("Right: " + counter);
            //CheckLeft(player);
            //Console.WriteLine("Left: " + counter);
            counter = 1;

            //CheckDiagonalUpRight(player);
            ////Console.WriteLine("counterDiagonalUPRIGHT: " + counter);
            //CheckDiagonalDownLeft(player);
            ////Console.WriteLine("counterDiagonalDownLeft: " + counter);
            //counter = 1;

            //CheckDiagonalUpLeft(player);
            ////Console.WriteLine("counterDiagonalUPLeft: " + counter);
            //CheckDiagonalDownRight(player);
            ////Console.WriteLine("counterDiagonalDOWNRIGHT: " + counter);
            //counter = 1;
        }

        private static void CheckDiagonalUpLeft(Player player)
        {
            var x = player.X;
            var y = player.Y;

            do
            {
                x--;
                y--;

                if (IsFieldInArray(y, x))
                {
                    if (_fields[y, x] == player.Value)
                    {
                        counter++;
                    }
                }
                else
                {
                    break;
                }

            } while (_fields[y, x] == player.Value);
        }

        private static void CheckDiagonalDownRight(Player player)
        {
            var x = player.X;
            var y = player.Y;

            do
            {
                x++;
                y++;

                if (IsFieldInArray(y, x))
                {
                    if (_fields[y, x] == player.Value)
                    {
                        counter++;
                    }
                }
                else
                {
                    break;
                }

            } while (_fields[y, x] == player.Value);
        }

        private static void CheckDiagonalDownLeft(Player player)
        {

            var x = player.X;
            var y = player.Y;

            do
            {
                x--;
                y++;

                if (IsFieldInArray(y, x))
                {
                    if (_fields[y, x] == player.Value)
                    {
                        counter++;
                    }
                }
                else
                {
                    break;
                }

            } while (_fields[y, x] == player.Value);
        }

        private static void CheckDiagonalUpRight(Player player)
        {

            var x = player.X;
            var y = player.Y;

            do
            {
                x++;
                y--;

                if (IsFieldInArray(y, x))
                {
                    if (_fields[y, x] == player.Value)
                    {
                        counter++;
                    }
                }
                else
                {
                    break;
                }

            } while (_fields[y, x] == player.Value);
        }

        private static void CheckLeft(Player player)
        {

            var x = player.X;
            var y = player.Y;

            do
            {
                x--;

                if (IsFieldInArray(y, x))
                {
                    if (_fields[y, x] == player.Value)
                    {
                        counter++;
                    }
                }
                else
                {
                    break;
                }

            } while (_fields[y, x] == player.Value);
        }

        public static void CheckRight(Player player)
        {
            var x = player.X;
            var y = player.Y;

            do
            {
                x++;
                
                if(IsFieldInArray(y, x))
                {
                    if (_fields[y, x] == player.Value)
                    {
                        counter++;
                    }
                }else
                {
                    break;
                }

            } while (_fields[y, x] == player.Value);

        }

        public static void CheckDown(Player player)
        {

            var x = player.X;
            var y = player.Y;

            do
            {
                y++;

                if (IsFieldInArray(y, x))
                {
                    if (_fields[y, x] == player.Value)
                    {
                        counter++;
                    }
                }
                else
                {
                    break;
                }

            } while (_fields[y, x] == player.Value);
        }

        public static bool IsFieldInArray(int y, int x)
        {
            return  x >=0 &&
                    x <=6 &&
                    y >=0 &&
                    y <=5;
        }

        public static void InsertValue(Player player)
        {
            _fields[player.Y, player.X] = player.Value;
        }

        public static bool PlayingFieldConatinsEmptySpace()
        {
            for (var i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var fieldValue = _fields[i, j];

                    if (fieldValue == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsEndOfTheGame()
        {
            if (PlayingFieldConatinsEmptySpace())
            {
                return false;
            }

            return true;
        }

        private static bool GetXYAndCheck(Player player)
        {
            var column = GetColumn();

            for (var row = ZAHL; row >= 0; row--)
            {
                if (_fields[row, column] == 0)
                {
                    player.X = column;
                    player.Y = row;

                    return true;
                }
            }

            return false;
        }

        private static int GetColumn()
        {
            var rnd = _random.Next(0, 7);

            return rnd;
        }

        private static void InitializeArray()
        {
            // x ---> | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
            _fields[0, 0] = 0;
            _fields[0, 1] = 0;
            _fields[0, 2] = 0;
            _fields[0, 3] = 0;
            _fields[0, 4] = 0;
            _fields[0, 5] = 0;
            _fields[0, 6] = 0;

            // row 1 --->
            _fields[1, 0] = 0;
            _fields[1, 1] = 0;
            _fields[1, 2] = 0;
            _fields[1, 3] = 0;
            _fields[1, 4] = 0;
            _fields[1, 5] = 0;
            _fields[1, 6] = 0;

            // row 2 --->
            _fields[2, 0] = 0;
            _fields[2, 1] = 0;
            _fields[2, 2] = 0;
            _fields[2, 3] = 0;
            _fields[2, 4] = 0;
            _fields[2, 5] = 0;
            _fields[2, 6] = 0;

            //row 3
            _fields[3, 0] = 0;
            _fields[3, 1] = 0;
            _fields[3, 2] = 0;
            _fields[3, 3] = 0;
            _fields[3, 4] = 0;
            _fields[3, 5] = 0;
            _fields[3, 6] = 0;

            //row 4
            _fields[4, 0] = 0;
            _fields[4, 1] = 0;
            _fields[4, 2] = 0;
            _fields[4, 3] = 0;
            _fields[4, 4] = 0;
            _fields[4, 5] = 0;
            _fields[4, 6] = 0;

            //row 5
            _fields[5, 0] = 0;
            _fields[5, 1] = 0;
            _fields[5, 2] = 0;
            _fields[5, 3] = 0;
            _fields[5, 4] = 0;
            _fields[5, 5] = 0;
            _fields[5, 6] = 0;

        }

        private static void ShowField(int[,] _field)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Write("| ");

                for (int j = 0; j < 7; j++)
                {
                    Console.Write(_field[i, j]);
                    Console.Write(" ");
                    Console.Write(" | ");

                }
                Console.WriteLine();
            }
        }
    }
}