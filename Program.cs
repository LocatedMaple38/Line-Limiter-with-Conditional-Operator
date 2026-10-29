using Avalonia.Controls;
using System.Diagnostics;
using CrossPlatformDrawer;
using System.Net;
using Avalonia.OpenGL;

namespace Calculator_with_Switch_Statement
{
    class Program
    {
        static void Beep()
        {
            //OperatingSystem.IsWindows() ? Console.Beep(1000, 500) : Debug.WriteLine("Beep sound is not supported on this platform.");
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(1000, 500);
            }
            else if (OperatingSystem.IsLinux())
            {
                FileInfo fileInfo = new FileInfo("/usr/bin/beep");
                if (fileInfo.Exists)
                {
                    Process.Start("/usr/bin/beep", "1000 500");
                }
                else
                {
                    Debug.WriteLine("Beep sound is not supported on Linux.");
                }
            }
            else if (OperatingSystem.IsMacOS())
            {
                Debug.WriteLine("Beep sound is not supported on macOS.");
            }
        }
        static void Main()
        {
            
            CPD(Items());
            end();
        }
        static void end(){
            Console.WriteLine("\nDo you want to exit? [Y/n]:");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.N:
                    Console.Clear();
                    Main();
                    break;
                case ConsoleKey.Y:
                case ConsoleKey.Enter:
                    Console.WriteLine("\nExiting program...");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid input. Please enter 'y' or 'n'.");
                    Beep();
                    end();
                    break;
            }
        }

        static int[] Items()
        {

            int[] numbers = { StartX(), StartY(), EndX(), EndY() };
            return numbers;

            int StartX()
            {
                Console.Write("Enter X start position: ");
                if (!int.TryParse(Console.ReadLine(), out int startX))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Beep();
                    StartX();
                }
                return startX;
            }

            int StartY()
            {
                Console.Write("Enter Y start position: ");
                if (!int.TryParse(Console.ReadLine(), out int startY))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Beep();
                    StartY();
                }
                return startY;
            }

            int EndX()
            {
                Console.Write("Enter X end position: ");
                if (!int.TryParse(Console.ReadLine(), out int endX))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Beep();
                    EndX();
                }
                return endX;
            }

            int EndY()
            {
                Console.Write("Enter Y end position: ");
                if (!int.TryParse(Console.ReadLine(), out int endY))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Beep();
                    EndY();
                }
                return endY;
            }
        }

        
        
        static void CPD(int[] positions)
        {
            CPDrawer drawer;
            drawer = new CPDrawer(500, 300, false, default);
            
            drawer.BackgroundColor = SkiaSharp.SKColors.White;
            drawer.AddLine(Math.Min(drawer.Width, Math.Max(positions[0], 0)), Math.Min(drawer.Height, Math.Max(positions[1], 0)), Math.Max(drawer.Width, Math.Min(positions[2], drawer.Width)), Math.Max(drawer.Height, Math.Min(positions[3], drawer.Height)), SkiaSharp.SKColors.Pink, 5);
            Console.Write("Original values: ");
            Console.WriteLine($"Start({positions[0]}, {positions[1]})  End({positions[2]}, {positions[3]})");
            Console.Write("Adjusted values: ");
            Console.WriteLine($"Start({Math.Min(drawer.Width, Math.Max(positions[0], 0))}, {Math.Min(drawer.Height, Math.Max(positions[1], 0))}) End({Math.Max(drawer.Width, Math.Min(positions[2], drawer.Width))}, {Math.Max(drawer.Height, Math.Min(positions[3], drawer.Height))})");
            Console.WriteLine("\nLine drawn in CPDrawer window.");
            Console.WriteLine("Press any ENTER to exit...");

            
           
        }
    }
}