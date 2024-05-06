namespace TestingSystem.Data.Entities
{
    public class UserHistory
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CourseId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual User User { get; set; }
        public virtual Course.Course Course { get; set; }
    }
}
