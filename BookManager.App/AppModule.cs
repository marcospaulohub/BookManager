using BookManager.App.Services.Authors;
using BookManager.App.Services.Books;
using BookManager.App.Services.Categories;
using BookManager.App.Services.Loans;
using BookManager.App.Services.Users;
using BookManager.App.Validators.Authors;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.App
{
    public static class AppModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoanService, LoanService>();

            return services;
        }
        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateAuthorInputModelValidator>();

            return services;
        }
    }
}
