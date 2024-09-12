using LearningPlatform.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories;

public class LessonRepository
{
    private readonly LearningDbContext _dbContext;

    public LessonRepository(LearningDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddLesson(Guid courseId, LessonEntity lesson)
    {
        var course = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId)
                     ?? throw new Exception();
        course.Lessons.Add(lesson);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddLesson2(Guid courseId, string title)
    {
        var lesson = new LessonEntity()
        {
            Title = title,
            CourseId = courseId,
        };
        await _dbContext.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();
    }
}