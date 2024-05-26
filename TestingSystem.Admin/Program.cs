using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using TestingSystem.Core.Services.Implements;
using TestingSystem.Core.Services.Implements.Category;
using TestingSystem.Core.Services.Implements.Course;
using TestingSystem.Core.Services.Implements.Language;
using TestingSystem.Core.Services.Implements.Lession;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Core.Services.Interfaces.Category;
using TestingSystem.Core.Services.Interfaces.Course;
using TestingSystem.Core.Services.Interfaces.Language;
using TestingSystem.Core.Services.Interfaces.Lession;
using TestingSystem.Data.Db;
using TestingSystem.Infrastructure.Repositories.Implements;
using TestingSystem.Infrastructure.Repositories.Implements.Category;
using TestingSystem.Infrastructure.Repositories.Implements.Course;
using TestingSystem.Infrastructure.Repositories.Implements.Lession;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Infrastructure.Repositories.Interfaces.Category;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces.Lession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<TestingSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestingSystemDb")));

// Add JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        // Configure role claim
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                if (claimsIdentity == null)
                {
                    return Task.CompletedTask;
                }

                // Set user's roles
                var roles = context.Principal.FindFirst(ClaimTypes.Role)?.Value?.Split(',');
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                    }
                }

                return Task.CompletedTask;
            }
        };
    });

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestingSystem", Version = "v1" });

    // Define the security scheme for JWT
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter JWT Bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    // Make sure Swagger UI requires a Bearer token
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<ICategoryService, CategorySerivce>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ILessionService, LessionService>();
builder.Services.AddScoped<IUserHistoryService, UserHistoryService>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<IWebUserChooseService, WebUserChooseService>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryTranslationRepository, CategoryTranslationRepository>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseTranslationRepository, CourseTranslationRepository>();
builder.Services.AddScoped<ICourseDetailRepository, CourseDetailRepository>();
builder.Services.AddScoped<ICourseDetailTranslationRepository, CourseDetailTranslationRepository>();
builder.Services.AddScoped<ICourseTeacherRepository, CourseTeacherRepository>();
builder.Services.AddScoped<ICourseTeacherTranslationRepository, CourseTeacherTranslationRepository>();

builder.Services.AddScoped<ILessionRepository, LessionRepository>();
builder.Services.AddScoped<ILessionTranslationRepository, LessionTranslationRepository>();

builder.Services.AddScoped<ILanguageTagRepository, LanguageTagRepository>();

builder.Services.AddScoped<IUserHistoryRepository, UserHistoryRepository>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<IWebUserChooseRepository, WebUserChooseRepository>();

builder.Services.AddScoped<IAnswerTranslationRepository, AnswerTranslationRepository>();
builder.Services.AddScoped<IQuestionTranslationRepository, QuestionTranslationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add this line to enable authentication
app.UseAuthorization();

// Enable CORS
app.UseCors("AllowAllOrigins");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestingSystem V1");  
    c.RoutePrefix = string.Empty; // Serve the Swagger UI at the app's root URL
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
