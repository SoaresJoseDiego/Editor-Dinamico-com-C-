using System;
using System.Text;
using System.Xml.Linq;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("---------------------");
            Start();


            
        }
        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);


            Console.WriteLine("---------------------");
            Console.WriteLine("Deseja salvar o arquvio?");
            // Viewer.Show(file.ToString());

            Console.WriteLine("S = Sim");
            Console.WriteLine("N = Não");

            string response = Console.ReadLine();

            AgreeOrNot(response.ToLower(), file.ToString());
            Console.WriteLine(response);

        }


        public static void AgreeOrNot(string response, string text)
        {
            if (response == "s")
            {
                Console.WriteLine("Qual caminho para salvar o arquvio?");
                var path = Console.ReadLine();

                Save(path, text);

                Console.WriteLine($"Arquvio salvo com sucesso em: {path}");
                Console.ReadKey();
                Menu.Show();
            }
            else if (response == "n")
            {
                Menu.Show();
            }
            else
            {
                Console.WriteLine("Opção inválida");
                AgreeOrNot(Console.ReadLine().ToLower(), text);
            }

        }

        public static void Save(string path, string text)
        {
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
        }
        
     
    }
}