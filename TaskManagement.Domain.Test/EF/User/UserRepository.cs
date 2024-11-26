using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Domain.User;
using TaskManagement.Infrastructure.Test.Helper;
using TaskManagement.Infrasturcture.EF;
using Xunit.Abstractions;

namespace TaskManagement.Infrastructure.Test.EF.User
{
    public class UserRepositoryTests
    {
        private readonly DbContextOptions<TaskManagementDbContext> _dbContextOptions;
        private readonly Infrasturcture.EF.User.UserRepository _userRepository;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IMapper _mapper;

        public UserRepositoryTests(
            ITestOutputHelper testOutputHelper)
        {
            _dbContextOptions = new DbContextOptionsBuilder<TaskManagementDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _userRepository = new Infrasturcture.EF.User.UserRepository(
                new TaskManagementDbContext(_dbContextOptions),
                _mapper);

            _testOutputHelper = testOutputHelper;
        }

        public static IEnumerable<object[]> GetUserWithUserIdTestData()
        {
            yield return new object[]
            {
                new Domain.User.User
                {
                    Name = "saeed",
                    LastName = "rezaie",
                    Email = "saeedrezaie28@gmail.com",
                    Password = "123",
                    Mobile = "09376721396",
                    UserName = "saeed",
                    Roles = new List<Role>
                    {
                        new Role { ID = 1, Title = "admin" },
                        new Role { ID = 2, Title = "employee" }
                    }
                },
                new SelectUserDto
                {
                    ID = 1,
                    Name = "saeed",
                    LastName = "rezaie",
                    Email = "saeedrezaie28@gmail.com",
                    Password = "123",
                    Mobile = "09376721396",
                    UserName = "saeed",
                    Roles = new List<Role>
                    {
                        new Role { ID = 1, Title = "admin" },
                        new Role { ID = 2, Title = "employee" }
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetUserWithUserIdTestData))]
        public async Task CreateUser_And_GetUser_ShouldReturnCorrectUser(
            Domain.User.User user,
            SelectUserDto expectedUserDto)
        {
            // Arrange
            await using var context = new TaskManagementDbContext(_dbContextOptions);
            context.Users.Add(user);
            await context.SaveChangesAsync();

            // Act
            var result = await _userRepository.GetUserAsync(user.ID);

            // Assert
            Assert.True(result.IsSuccess, "Expected operation to succeed.");
            Assert.NotNull(result.Data);
            Assert.True(expectedUserDto.CehckEqualTo(result.Data), "Expected user data to match.");
        }
    }
}
