﻿namespace TestingSystem.Data.Models.Course
{
    public class CourseDetailsDto
    {
        public Guid CourseId { get; set; }
        public string TabName { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public string Content { get; set; }
    }
}
