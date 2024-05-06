﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestingSystem.Data.Db;

#nullable disable

namespace TestingSystem.Data.Migrations
{
    [DbContext(typeof(TestingSystemDbContext))]
    partial class TestingSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestingSystem.Data.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Correct")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Category.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameNoneAscii")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Category.CategoryTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LanguageCode");

                    b.ToTable("CategoryTranslation", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FullTextSearch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsHot")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameNonAscii")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("ProductType")
                        .HasColumnType("smallint");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Id");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseDetails", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseDetailTranslation", b =>
                {
                    b.Property<Guid>("CourseDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("TabName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseDetailId");

                    b.HasIndex("CourseDetailId");

                    b.HasIndex("LanguageCode");

                    b.ToTable("CourseDetailTranslations", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseTeacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeachers", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseTeacherTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseTeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseTeacherId");

                    b.HasIndex("Id");

                    b.HasIndex("LanguageCode");

                    b.ToTable("CourseTeacherTranslations", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfAssignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfStudent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Id");

                    b.HasIndex("LanguageCode");

                    b.ToTable("CourseTranslations", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Exam", b =>
                {
                    b.Property<Guid>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAutoGrade")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ExamId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ExamId");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.LanguageTag", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("LanguageTags", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Lession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessions", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.LessionTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<Guid>("LessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("LessionId");

                    b.ToTable("LessionTranslations", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Explanation")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("IsSingleChoice")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("Id");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Submission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Score")
                        .HasColumnType("float");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("SubmittedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Submissions", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("AccessFailedCount")
                        .HasColumnType("smallint");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullTextSearch")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("PhoneNumber");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.UserHistory", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserHistories", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.WebUserChoose", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CorrectAnswer")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WebUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("WebUserId");

                    b.ToTable("WebUserChooses", (string)null);
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Answer", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Category.CategoryTranslation", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Category.Category", "Category")
                        .WithMany("CategoryTranslations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.LanguageTag", "Language")
                        .WithMany("CategoryTranslations")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.Course", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.User", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TestingSystem.Data.Entities.Category.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseDetail", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Course.Course", "Course")
                        .WithMany("CourseDetails")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseDetailTranslation", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Course.CourseDetail", "CourseDetail")
                        .WithMany("CourseDetailTranslations")
                        .HasForeignKey("CourseDetailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.LanguageTag", "Language")
                        .WithMany("CourseDetailTranslations")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CourseDetail");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseTeacher", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Course.Course", "Course")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.User", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseTeacherTranslation", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Course.CourseTeacher", "CourseTeacher")
                        .WithMany("CourseTeacherTranslations")
                        .HasForeignKey("CourseTeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.LanguageTag", "Language")
                        .WithMany("CourseTeacherTranslations")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CourseTeacher");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseTranslation", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Course.Course", "Course")
                        .WithMany("CourseTranslations")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.LanguageTag", "Language")
                        .WithMany("CourseTranslations")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Exam", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.User", "Teacher")
                        .WithMany("Exams")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Lession", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Course.Course", "Course")
                        .WithMany("Lessions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.LessionTranslation", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.LanguageTag", "Language")
                        .WithMany("LessionTranslations")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.Lession", "Lession")
                        .WithMany("LessionTranslations")
                        .HasForeignKey("LessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Lession");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Question", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Submission", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Exam", "Exam")
                        .WithMany("Submissions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.User", "Student")
                        .WithMany("Submissions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.User", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.UserHistory", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Course.Course", "Course")
                        .WithMany("UserHistories")
                        .HasForeignKey("CourseId");

                    b.HasOne("TestingSystem.Data.Entities.User", "User")
                        .WithMany("UserHistories")
                        .HasForeignKey("UserId");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.WebUserChoose", b =>
                {
                    b.HasOne("TestingSystem.Data.Entities.Answer", "Answer")
                        .WithMany("WebUserChooses")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.Question", "Question")
                        .WithMany("WebUserChooses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestingSystem.Data.Entities.User", "WebUser")
                        .WithMany()
                        .HasForeignKey("WebUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Question");

                    b.Navigation("WebUser");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Answer", b =>
                {
                    b.Navigation("WebUserChooses");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Category.Category", b =>
                {
                    b.Navigation("CategoryTranslations");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.Course", b =>
                {
                    b.Navigation("CourseDetails");

                    b.Navigation("CourseTeachers");

                    b.Navigation("CourseTranslations");

                    b.Navigation("Lessions");

                    b.Navigation("UserHistories");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseDetail", b =>
                {
                    b.Navigation("CourseDetailTranslations");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Course.CourseTeacher", b =>
                {
                    b.Navigation("CourseTeacherTranslations");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Exam", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.LanguageTag", b =>
                {
                    b.Navigation("CategoryTranslations");

                    b.Navigation("CourseDetailTranslations");

                    b.Navigation("CourseTeacherTranslations");

                    b.Navigation("CourseTranslations");

                    b.Navigation("LessionTranslations");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Lession", b =>
                {
                    b.Navigation("LessionTranslations");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("WebUserChooses");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.User", b =>
                {
                    b.Navigation("CourseTeachers");

                    b.Navigation("Courses");

                    b.Navigation("Exams");

                    b.Navigation("Submissions");

                    b.Navigation("UserHistories");
                });

            modelBuilder.Entity("TestingSystem.Data.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
