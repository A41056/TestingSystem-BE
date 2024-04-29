using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Entities.Course;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Infrastructure.Repositories.Implements.Course
{
    public class CourseTeacherTranslationRepository : BaseRepository<Data.Entities.Course.CourseTeacherTranslation>, ICourseTeacherTranslationRepository
    {
        public CourseTeacherTranslationRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteAsync(Guid courseTeacherId)
        {
            var ctt = await DbSet.FirstOrDefaultAsync(ctt => ctt.CourseTeacherId == courseTeacherId);

            if (ctt != null)
                await Delete(ctt);
        }

        public async Task<IEnumerable<CourseTeacherTranslationDto>> GetCourseTeacherTranslationByIdAsync(Guid courseTeacherId)
        {
            var result = new List<CourseTeacherTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.CourseTeacherId == courseTeacherId).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseTeacherTranslationDto()
                {
                    CourseTeacherId = item.CourseTeacherId,
                    LanguageCode = item.LanguageCode,
                    Name = item.Name,
                    University = item.University,
                    Description = item.Description
                });
            }
            return result;
        }

        public async Task<IEnumerable<CourseTeacherTranslationDto>> GetListByCourseTeacherId(Guid teacherId, string languageCode)
        {
            var result = new List<CourseTeacherTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.CourseTeacherId == teacherId && ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseTeacherTranslationDto()
                {
                    CourseTeacherId = item.CourseTeacherId,
                    LanguageCode = item.LanguageCode,
                    Name = item.Name,
                    University = item.University,
                    Description = item.Description
                });
            }
            return result;
        }

        public async Task<IEnumerable<CourseTeacherTranslationDto>> GetListByLanguageCode(string languageCode)
        {
            var result = new List<CourseTeacherTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseTeacherTranslationDto()
                {
                    CourseTeacherId = item.CourseTeacherId,
                    LanguageCode = item.LanguageCode,
                    Name = item.Name,
                    University = item.University,
                    Description = item.Description
                });
            }
            return result;
        }

        public async Task InsertTranslationAsync(Guid courseTeacherId, CourseTeacherTranslationDto model)
        {
            var teacher = await DbSet.FirstOrDefaultAsync(lt => lt.CourseTeacherId == courseTeacherId && lt.LanguageCode == model.LanguageCode);

            if (teacher == null)
            {

                var courseTeacherTrans = new CourseTeacherTranslation()
                {
                    LanguageCode = model.LanguageCode,
                    CourseTeacherId = model.CourseTeacherId,
                    Name = model.Name,
                    University = model.University,
                    Description = model.Description,
                };

                await DbSet.AddAsync(courseTeacherTrans);
            }
            else
            {
                teacher.Name = model.Name;
                teacher.University = model.University;
                teacher.Description = model.Description;
            }

            await SaveChangeAsync();
        }
    }
}
