using DemoUnitTesting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoUnitTesting.Services
{
    public interface ITodoService
    {
            Task<List<Todo>> GetAllAsync();
            Task SaveAsync(Todo newTodo);
    }
}
