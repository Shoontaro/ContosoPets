using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPets
{
    public class View
    {
        public static void WriteLine(string text) 
        {
            Console.WriteLine(text);
        }

        public static void Correct(string text) {
            AnsiConsole.MarkupLine($"[green]✓ {text}[/]\n");
        }

        public static string ReadLine() {
            return Console.ReadLine()??string.Empty;
        }

        //public static void MooltySelector<T>(List<T> data) {

        //    var name = AnsiConsole.Ask<string>("What's your [green]name[/]?");

        //}
        public static void ViewTable<T>(List<T> data)
        {
            // 1. Создаем объект таблицы
            var table = new Table()
                .Border(TableBorder.Rounded) // Закругленные границы
                .Title("[yellow]Pet list[/]") // Заголовок таблицы
                .Caption($"[grey]Count: {data.Count}[/]"); // Подпись внизу
            
            Type type = typeof(T);

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties) {
               //Console.WriteLine(property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName);
                
                 table.AddColumn(
                     new TableColumn($"[bold yellow]{property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName}[/]").Centered()
                     );
            }
            foreach (T el in data) {

                var rowData = new List<string>();

                foreach (PropertyInfo property in properties) 
                { 
                    rowData.Add(property.GetValue(el)?.ToString()??string.Empty);
                }

                table.AddRow(rowData.ToArray());
            }

            AnsiConsole.Write(table);
        }
    }
}
