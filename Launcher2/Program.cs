using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace Launcher
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=== Лаунчер системы заметок ===");
                Console.WriteLine("1 - Запуск основной программы");
                Console.WriteLine("2 - Загрузка обновления");
                Console.WriteLine("3 - Запуск агента сбора статистики");
                Console.WriteLine("0 - Выход");
                Console.Write("\nВаш выбор: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StartMainApplication();
                        return;

                    case "2":
                        CheckAndDownloadUpdate();
                        break;

                    case "3":
                        StartAgent();
                        break;

                    case "0":
                        Console.WriteLine("Выход из лаунчера...");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }

        public static void StartMainApplication()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string mainAppPath = Path.Combine(basePath, "Coursework.exe");

                if (File.Exists(mainAppPath))
                {
                    Process.Start(mainAppPath);
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"\nОшибка: Не найден файл Coursework.exe по пути: {mainAppPath}");
                    Console.WriteLine("Нажмите любую клавишу для выхода...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка запуска основной программы: {ex.Message}");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }

        public static void CheckAndDownloadUpdate()
        {
            Console.WriteLine("\n=== ПРОВЕРКА ОБНОВЛЕНИЙ ===");

            bool hasUpdate = CheckForUpdates();

            if (hasUpdate)
            {
                Console.WriteLine("Доступно новое обновление!");
                Console.Write("Загрузить обновление? (y/n): ");
                string answer = Console.ReadLine()?.Trim().ToLower();

                if (answer == "y")
                {
                    Console.WriteLine("\n[Функция в разработке] Скачивание обновления будет доступно в следующей версии.");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nЗагрузка обновления отменена.");
                    Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nОбновлений не найдено.");
                Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }

            Console.Clear();
        }

        public static void StartAgent()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string agentPath = Path.Combine(basePath, "Agent.exe");

                if (File.Exists(agentPath))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = agentPath,
                        Arguments = "-stats",
                        UseShellExecute = true,
                        CreateNoWindow = false,
                        WindowStyle = ProcessWindowStyle.Normal
                    };

                    Process.Start(startInfo);
                    Console.WriteLine("Нажмите любую клавишу для возврата в меню лаунчера...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"\nОшибка: Не найден файл Agent.exe по пути: {agentPath}");
                    Console.WriteLine("Убедитесь, что проект Agent скомпилирован.");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка запуска агента: {ex.Message}");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static bool CheckForUpdates()
        {
            Console.WriteLine("Подключение к серверу обновлений...");
            Thread.Sleep(1000);
            return true;
        }
    }
}