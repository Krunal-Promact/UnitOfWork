using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkDemo.Models
{
    /// <summary>
    /// Student Entity
    /// </summary>
    public class Student : Base
    {
        /// <summary>
        /// Name of Student. Empty string is not allowed.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        /// <summary>
        /// Email Address of Student. Empty string is not allowed.
        /// </summary>
        [EmailAddress(ErrorMessage = "In Valid Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is Required")]
        public string Email { get; set; }

        /// <summary>
        /// Mobile Number of Student
        /// </summary>
        public string Number { get; set; }
    }
}