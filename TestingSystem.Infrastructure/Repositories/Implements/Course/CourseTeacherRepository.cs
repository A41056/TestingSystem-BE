using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities.Course;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Infrastructure.Repositories.Implements.Course
{
    public class CourseTeacherRepository : BaseRepository<Data.Entities.Course.CourseTeacher>, ICourseTeacherRepository
    {
        private readonly ILanguageTagRepository _languageTagRepository;
        private readonly ICourseTeacherTranslationRepository _courseTeacherTranslationRepository;
        public CourseTeacherRepository(TestingSystemDbContext dbContext, 
            ILanguageTagRepository languageTagRepository, 
            ICourseTeacherTranslationRepository courseTeacherTranslationRepository) : base(dbContext)
        {
            _languageTagRepository = languageTagRepository;
            _courseTeacherTranslationRepository = courseTeacherTranslationRepository;
        }

        public async Task DeleteAsync(Guid teacherId)
        {
            var teacher = await DbSet.FirstOrDefaultAsync(ct => ct.Id == teacherId);

            if (teacher != null)
                await Delete(teacher);
        }

        public async Task<CourseTeacherSingleModel> GetCourseTeacherByIdAsync(Guid teacherId)
        {
            var teacherModel = new CourseTeacherSingleModel();

            var ct = await DbSet.FirstOrDefaultAsync(ct => ct.Id == teacherId);

            teacherModel.Id = ct.Id;
            teacherModel.CourseId = ct.CourseId;
            teacherModel.ImageUrl = ct.AvatarUrl;

            var translations = await _courseTeacherTranslationRepository.GetCourseTeacherTranslationByIdAsync(ct.Id);
            teacherModel.Translation = translations.ToList();

            return teacherModel;
        }

        public async Task<IEnumerable<CourseTeacherListModel>> GetListByCourseIdAsync(Guid courseId)
        {
            var defaultLanguageCode = await _languageTagRepository.GetDefault();

            var teachers = await DbSet
            .Where(ct => ct.CourseId == courseId)
            .OrderBy(ct => ct.SortOrder)
            .Select(ct => new CourseTeacherListModel
            {
                Id = ct.Id,
                Name = ct.CourseTeacherTranslations.FirstOrDefault(t => t.LanguageCode == defaultLanguageCode.Code)!.Name,
                University = ct.CourseTeacherTranslations.FirstOrDefault(t => t.LanguageCode == defaultLanguageCode.Code)!.University,
                SortOrder = ct.SortOrder.GetValueOrDefault(),
                Description = ct.CourseTeacherTranslations.FirstOrDefault(t => t.LanguageCode == defaultLanguageCode.Code)!.Description,
                AvatarUrl = ct.AvatarUrl
            })
            .ToListAsync();

            return teachers;
        }

        public async Task InsertAsync(Guid teacherId, CourseTeacherDto model)
        {
            var courseTeacher = new CourseTeacher()
            {
                Id = teacherId,
                CourseId = model.CourseId,
                SortOrder = model.SortOrder,
                AvatarUrl = model.AvatarUrl
            };

            await DbSet.AddAsync(courseTeacher);
            await SaveChangeAsync();
        }

        public async Task UpdateAsync(Guid teacherId, CourseTeacherUpdateModel model)
        {
            var courseTeacher = await DbSet.FirstOrDefaultAsync(ct => ct.Id == teacherId);

            if (courseTeacher != null) 
            {
                courseTeacher.CourseId = model.CourseId;
                courseTeacher.AvatarUrl = model.AvatarUrl;
                courseTeacher.Modified = DateTime.UtcNow;

                await SaveChangeAsync();
            }
        }
    }
}
