class Program
{
    static void Main()
    {
        Console.WindowHeight = 16;
        Console.WindowWidth = 32;
        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;
        Random random = new Random();
        string movement = "RIGHT";
        List<int> telje = new List<int>();
        int score = 0;
        Pixel pixel = new Pixel();

        pixel.xPos = screenWidth / 2;
        pixel.yPos = screenHeight / 2;
        pixel.screenColor = ConsoleColor.Red;

        List<int> teljePositie = new List<int>();
        teljePositie.Add(pixel.xPos);
        teljePositie.Add(pixel.yPos);

        DateTime tijd = DateTime.Now;

        string obstacle = "*";

        int obstacleXpos = random.Next(1, screenWidth);
        int obstacleYpos = random.Next(1, screenHeight);

        while (true)
        {
            Console.Clear();

            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            Console.Write("■");

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }

            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("■");
            }

            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
            }

            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(screenWidth - 1, i);
                Console.Write("■");
            }

            Console.ForegroundColor =  ConsoleColor.Green/* ?? */;
            Console.WriteLine("Score: " + score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("H");

            for (int i = 0; i < telje.Count(); i++)

            {
                Console.SetCursorPosition(telje[i], telje[i + 1]);
                Console.Write("■");
            }

            //Draw Snake

            Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            Console.Write("■");
            Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            Console.Write("■");
            Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            Console.Write("■");
            Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            Console.Write("■");

            ConsoleKeyInfo info = Console.ReadKey();

            //Game Logic

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

            if (movement == "UP")
                pixel.yPos--;

            if (movement == "DOWN")
                pixel.yPos++;

            if (movement == "LEFT")
                pixel.xPos--;

            if (movement == "RIGHT")
                pixel.xPos++;

            //Hindernis treffen

            if (pixel.xPos == obstacleXpos && pixel.yPos /* ?? */ == obstacleYpos)
            {
                score++;
                obstacleXpos = random.Next(1, screenWidth);
                obstacleYpos = random.Next(1, screenHeight);
            }

            teljePositie.Insert(0, pixel.xPos);
            teljePositie.Insert(1, pixel.yPos);
            teljePositie.RemoveAt(teljePositie.Count - 1);
            teljePositie.RemoveAt(teljePositie.Count - 1);

            //Kollision mit Wände oder mit sich selbst

            if (pixel.xPos == 0 || pixel.xPos == screenWidth - 1 || pixel.yPos == 0 || pixel.yPos == screenHeight - 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                Console.WriteLine("Dein Score ist: " + score);
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                Environment.Exit(0);
            }

            for (int i = 0; i < telje.Count(); i += 2)
            {
                if (pixel.xPos == telje[i] && pixel.yPos == telje[i + 1])
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

                    //???

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                    Console.WriteLine("Dein Score ist: " + score);
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                    Environment.Exit(0);
                }
            }
            Thread.Sleep(50);
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

