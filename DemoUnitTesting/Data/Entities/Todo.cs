using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoUnitTesting.Data.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string IsCompleted { get; set; }
    }
}
