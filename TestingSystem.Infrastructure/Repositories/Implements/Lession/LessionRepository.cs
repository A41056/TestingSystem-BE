using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces.Lession;

namespace TestingSystem.Infrastructure.Repositories.Implements.Lession
{
    public class LessionRepository : BaseRepository<Data.Entities.Lession>, ILessionRepository
    {
        private readonly ILessionTranslationRepository _lessionTranslationRepository;
        public LessionRepository(TestingSystemDbContext dbContext, ILessionTranslationRepository lessionTranslationRepository) : base(dbContext)
        {
            _lessionTranslationRepository = lessionTranslationRepository;
        }

        public async Task DeleteAsync(Guid lessionId)
        {
            var l = await DbSet.FirstOrDefaultAsync(l => l.Id == lessionId);

            if (l != null)
            {
                l.Deleted = true;
                await SaveChangeAsync();
            }
        }

        public async Task<LessionDto> GetLessionByIdAsync(Guid lessionId)
        {
            var lession = await DbSet.FirstOrDefaultAsync(l => l.Id == lessionId && (!l.Deleted.HasValue || !l.Deleted.Value));

            return new LessionDto() 
            {
                Id = lession.Id,
                CourseId = lession.CourseId,
                Title = lession.Title,
                VideoUrl = lession.VideoUrl,
                SortOrder = lession.SortOrder
            };
        }

        public async Task<IEnumerable<LessionDto>> GetLessionListByCourseIdAsync(Guid courseId)
        {
            var result = new List<LessionDto>();

            var lessions = await DbSet
                .Where(l => l.CourseId == courseId && (!l.Deleted.HasValue || !l.Deleted.Value))
                .ToListAsync();

            foreach (var item in lessions)
            {
                result.Add(new LessionDto()
                {
                    Id = item.Id,
                    CourseId = item.CourseId,
                    Title = item.Title,
                    VideoUrl = item.VideoUrl,
                    SortOrder = item.SortOrder
                });
            }

            return result;
        }

        public async Task<IEnumerable<LessionDto>> GetLessionTransListByCourseIdAsync(Guid courseId, string languageCode)
        {
            var result = new List<LessionDto>();

            var lessions = await DbSet.Where(l => l.CourseId == courseId && (!l.Deleted.HasValue || !l.Deleted.Value)).ToListAsync();

            foreach (var item in lessions)
            {
                var trans = await _lessionTranslationRepository.GetListLessionByLessionId(item.Id, languageCode);

                if (trans != null && trans.FirstOrDefault() != null)
                {
                    var lessonTrans = trans.FirstOrDefault();

                    result.Add(new LessionDto()
                    {
                        Id = item.Id,
                        CourseId = item.CourseId,
                        Title = lessonTrans.Title,
                        VideoUrl = item.VideoUrl,
                        SortOrder = item.SortOrder
                    });
                }
                else
                {
                    result.Add(new LessionDto()
                    {
                        Id = item.Id,
                        CourseId = item.CourseId,
                        Title = item.Title,
                        VideoUrl = item.VideoUrl,
                        SortOrder = item.SortOrder
                    });
                }
            }

            return result;
        }

        public async Task InsertAsync(Guid lessionId, LessionDto model)
        {
            var lession = new Data.Entities.Lession()
            {
                Id = lessionId,
                CourseId = model.CourseId,
                Title = model.Title,
                VideoUrl = model.VideoUrl,
                SortOrder = model.SortOrder
            };

            await DbSet.AddAsync(lession);
            await SaveChangeAsync();
        }

        public async Task UpdateLessionAsync(Guid lessionId, LessionDto model)
        {
            var lession = await DbSet.FirstOrDefaultAsync(l => l.Id == lessionId);

            if (lession != null)
            {
                lession.Title = model.Title;
                lession.VideoUrl = model.VideoUrl;
                lession.SortOrder = model.SortOrder;
                lession.Modified = DateTime.UtcNow;

                await SaveChangeAsync();
            }
        }
    }
}
