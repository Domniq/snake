class Program
{
    static void Main()
    {
        Console.SetWindowSize(1, 1);
        Console.WindowHeight = 16;
        Console.WindowWidth = 32;

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;
        Random random = new Random();
        string movement = "RIGHT";

        int score = 0;
        //Pixel pixel = new Pixel();

        //pixel.xPos = screenWidth / 2;
        //pixel.yPos = screenHeight / 2;
        //pixel.screenColor = ConsoleColor.Red;




        //List<int> snakeHeadPosition = new List<int>();
        //List<int> snakeTail = new List<int>();
        //snakeHeadPosition.Add(pixel.xPos);
        //snakeHeadPosition.Add(pixel.yPos);




        Pixel headPixel = new Pixel();
        headPixel.xPos = screenWidth / 2;
        headPixel.yPos = screenHeight / 2;
        headPixel.character = "o";
        headPixel.screenColor = ConsoleColor.Magenta;

        List<Pixel> snakeTailPos = new List<Pixel>();
        for (int i = 1; i <= 3; i++)
        {
            Pixel tailPixel = new Pixel();
            tailPixel.xPos = screenWidth / 2 - i;
            tailPixel.yPos = screenHeight / 2;
            tailPixel.character = "■";
            tailPixel.screenColor = ConsoleColor.White;

            snakeTailPos.Add(tailPixel);
        }




        string obstacle = "*";

        int obstacleXpos = random.Next(1, screenWidth - 1);
        int obstacleYpos = random.Next(1, screenHeight - 1);

        Console.WriteLine("Press enter to start");
        Console.ReadKey();

        while (true)
        {
            Console.Clear();

            //Draw Obstacle
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            //Console.Write("■");

            Console.ForegroundColor = ConsoleColor.White;

            // Generowanie ściany górnej
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }

            // Generowanie ściany dolnej
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("■");
            }

            // Generowanie ściany lewej
            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
            }

            // Generowanie ściany prawej
            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(screenWidth - 1, i);
                Console.Write("■");
            }

            Console.ForegroundColor =  ConsoleColor.Green;
            Console.WriteLine("Score: " + score);
            Console.ForegroundColor = ConsoleColor.White;

            //for (int i = 0; i < snakeTail.Count(); i++)
            //{
            //    Console.SetCursorPosition(snakeTail[i], snakeTail[i + 1]);
            //    Console.Write("■");
            //}

            //Draw Snake
            //Console.SetCursorPosition(pixel.xPos - 3, pixel.yPos);
            //Console.Write("■");
            //Console.SetCursorPosition(pixel.xPos - 2, pixel.yPos);
            //Console.Write("■");
            //Console.SetCursorPosition(pixel.xPos - 1, pixel.yPos);
            //Console.Write("■");
            //Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            //Console.Write("■");

            Console.SetCursorPosition(headPixel.xPos, headPixel.yPos);
            Console.ForegroundColor = headPixel.screenColor;
            Console.Write(headPixel.character);

            foreach (Pixel px in snakeTailPos)
            {
                Console.SetCursorPosition(px.xPos, px.yPos);
                Console.ForegroundColor = px.screenColor;
                Console.Write(px.character);
            }

            //Game Logic
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);

                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        movement = "UP";
                        break;

                    case ConsoleKey.DownArrow:
                        movement = "DOWN";
                        break;

                    case ConsoleKey.LeftArrow:
                        movement = "LEFT";
                        break;

                    case ConsoleKey.RightArrow:
                        movement = "RIGHT";
                        break;
                }
            }

            if (movement == "UP")
                headPixel.yPos--;

            if (movement == "DOWN")
                headPixel.yPos++;

            if (movement == "LEFT")
                headPixel.xPos--;

            if (movement == "RIGHT")
            {
                headPixel.xPos++;

                foreach (Pixel px in snakeTailPos)
                {
                    px.xPos++;
                }
            }


            //Generowanie jedzenia
            if (headPixel.xPos == obstacleXpos && headPixel.yPos == obstacleYpos)
            {
                score++;
                obstacleXpos = random.Next(1, screenWidth);
                obstacleYpos = random.Next(1, screenHeight);
            }

            //snakeHeadPosition.Insert(0, pixel.xPos);
            //snakeHeadPosition.Insert(1, pixel.yPos);
            //snakeHeadPosition.RemoveAt(snakeHeadPosition.Count - 1);
            //snakeHeadPosition.RemoveAt(snakeHeadPosition.Count - 1);

            //Kolizja z ścianą lub samym sobą
            if (headPixel.xPos == 0 || headPixel.xPos == screenWidth - 1 || headPixel.yPos == 0 || headPixel.yPos == screenHeight - 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                Console.WriteLine("Your score is: " + score);
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                Environment.Exit(0);
            }

            //for (int i = 0; i < snakeTail.Count(); i += 2)
            //{
            //    if (pixel.xPos == snakeTail[i] && pixel.yPos == snakeTail[i + 1])
            //    {
            //        Console.Clear();
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

            //        //???

            //        Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
            //        Console.WriteLine("Your score is: " + score);
            //        Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

            //        Environment.Exit(0);
            //    }
            //}

            Thread.Sleep(100);
        }
    }
}

public class Pixel
{
    public int xPos { get; set; }
    public int yPos { get; set; }
    public ConsoleColor screenColor { get; set; }
    public string character { get; set; }
}

public class Obstacle
{
    public int xPos { get; set; }
    public int yPos { get; set; }
    public ConsoleColor screenColor { get; set; }
    public string character { get; set; }
}

