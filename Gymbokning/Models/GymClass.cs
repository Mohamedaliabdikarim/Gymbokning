using System.ComponentModel.DataAnnotations;

namespace Gymbokning.Models
{
    public class GymClass : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime EndTime => StartTime + Duration;

        [StringLength(500)]
        public string? Description { get; set; }

        public ICollection<ApplicationUser> AttendingMembers { get; set; } = new List<ApplicationUser>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Duration <= TimeSpan.Zero)
            {
                yield return new ValidationResult(
                    "Längden måste vara större än noll.",
                    new[] { nameof(Duration) });
            }
        }
    }
}