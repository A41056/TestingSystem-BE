using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Entities.Course;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Infrastructure.Repositories.Implements.Course
{
    public class CourseTranslationRepository : BaseRepository<Data.Entities.Course.CourseTranslation>, ICourseTranslationRepository
    {
        public CourseTranslationRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteTranslationsByCourseIdAsync(Guid courseId)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.CourseId == courseId);

            if (course != null)
                await Delete(course);
        }

        public async Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetCourseTranslationsByCourseIdAsync(Guid courseId)
        {
            var result = new List<CourseInsertOrUpdateTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.CourseId == courseId).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseInsertOrUpdateTranslationDto()
                {
                    CourseId = item.CourseId,
                    Name = item.Name,
                    Description = item.Description,
                    NumberOfAssignment = item.NumberOfAssignment,
                    NumberOfStudent = item.NumberOfStudent,
                    NumberOfVideo = item.NumberOfVideo,
                });
            }

            return result;
        }

        public async Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByCourseId(Guid courseId, string languageCode)
        {
            var result = new List<CourseInsertOrUpdateTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.CourseId == courseId && ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseInsertOrUpdateTranslationDto()
                {
                    CourseId = item.CourseId,
                    Name = item.Name,
                    Description = item.Description,
                    NumberOfAssignment = item.NumberOfAssignment,
                    NumberOfStudent = item.NumberOfStudent,
                    NumberOfVideo = item.NumberOfVideo,
                });
            }

            return result;
        }

        public async Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByLanguageCode(string languageCode)
        {
            var result = new List<CourseInsertOrUpdateTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseInsertOrUpdateTranslationDto()
                {
                    CourseId = item.CourseId,
                    Name = item.Name,
                    Description = item.Description,
                    NumberOfAssignment = item.NumberOfAssignment,
                    NumberOfStudent = item.NumberOfStudent,
                    NumberOfVideo = item.NumberOfVideo,
                });
            }

            return result;
        }

        public async Task InsertTranslationAsync(Guid courseId, CourseInsertOrUpdateTranslationDto model)
        {
            var course = await DbSet.FirstOrDefaultAsync(lt => lt.CourseId == courseId && lt.LanguageCode == model.LanguageCode);

            if (course == null)
            {
                var courseTrans = new CourseTranslation()
                {
                    Id = Guid.NewGuid(),
                    LanguageCode = model.LanguageCode,
                    CourseId = courseId,
                    Name = model.Name,
                    Description = model.Description,
                    NumberOfAssignment = model.NumberOfAssignment,
                    NumberOfStudent = model.NumberOfStudent,
                    NumberOfVideo = model.NumberOfVideo
                };

                await DbSet.AddAsync(courseTrans);
            }
            else
            {
                course.Name = model.Name;
                course.Description = model.Description;
                course.NumberOfAssignment = model.NumberOfAssignment;
                course.NumberOfStudent = model.NumberOfStudent;
                course.NumberOfVideo = model.NumberOfVideo;
            }

            await SaveChangeAsync();
        }
    }
}
