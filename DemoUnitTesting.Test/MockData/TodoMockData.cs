using DemoUnitTesting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTesting.Test.MockData
{
    public class TodoMockData
    {
        public static List<Todo> GetTodos()
        {
            return new List<Todo>{

                 new Todo{
                     Id = 1,
                     ItemName = "Need To Go Shopping",
                     IsCompleted = "Falso"
                 },
                 new Todo{
                     Id = 2,
                     ItemName = "Cook Food",
                     IsCompleted = "Verdadero"
                 },
                 new Todo{
                     Id = 3,
                     ItemName = "Play Games",
                     IsCompleted = "Falso"
                 }
             };

        }

        public static List<Todo> GetEmptyTodos()
        {
            return new List<Todo>();
        }

        public static Todo NewTodo()
        {
            return new Todo
            {
                Id = 0,
                ItemName = "wash cloths",
                IsCompleted = "Verdadero"
            };
        }
    }
}
