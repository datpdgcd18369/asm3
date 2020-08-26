using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace asm1.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

      
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Topic> Topics { get; set; }
      

        public DbSet<Course> Courses{ get; set; }
        public DbSet<CategoryCourse> CategoryCourses { get; set; }

        public DbSet<CourseTrainee> CourseTrainees { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerStaff> TrainerStaffs { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      
    }
}