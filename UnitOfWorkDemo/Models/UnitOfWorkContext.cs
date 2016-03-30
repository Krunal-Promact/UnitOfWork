using System.Data.Entity;

namespace UnitOfWorkDemo.Models
{
    /// <summary>
    /// Context Class
    /// </summary>
    public class UnitOfWorkContext : DbContext
    {
        #region Constructors

        public UnitOfWorkContext() : base("UnitOfWorkContext")
        {

        }

        #endregion

        #region public Db Set Properties

        /// <summary>
        /// Student Context
        /// </summary>
        public DbSet<Student> Students { get; set; }

        #endregion
    }
}