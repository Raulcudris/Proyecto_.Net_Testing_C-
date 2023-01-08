using DemoUnitTesting.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUnitTesting.Test.MockData;
using Xunit;
using DemoUnitTesting.Services;
using FluentAssertions;

namespace DemoUnitTesting.Test.System.Services
{
    public class TestTodoService : IDisposable
    {

        protected readonly MyWorldDbContext _context;
        public TestTodoService()
        {
            var options = new DbContextOptionsBuilder<MyWorldDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).
                Options;

            _context = new MyWorldDbContext(options);
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllAsync_ReturnTodoCollection()
        {
            /// Arrange
            _context.Todo.AddRange(MockData.TodoMockData.GetTodos());
            _context.SaveChanges();

            var sut = new TodoService(_context);

            /// Act
            var result = await sut.GetAllAsync();

            /// Assert
            result.Should().HaveCount(TodoMockData.GetTodos().Count);
        }

        [Fact]
        public async Task SaveAsync_AddNewTodo()
        {
            /// Arrange
            var newTodo = TodoMockData.NewTodo();
            _context.Todo.AddRange(MockData.TodoMockData.GetTodos());
            _context.SaveChanges();

            var sut = new TodoService(_context);

            /// Act
            await sut.SaveAsync(newTodo);

            ///Assert
            int expectedRecordCount = (TodoMockData.GetTodos().Count() + 1);
            _context.Todo.Count().Should().Be(expectedRecordCount);
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
