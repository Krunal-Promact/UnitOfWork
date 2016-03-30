using System.Data.Entity.Migrations;
using UnitOfWorkDemo.Migrations;

namespace UnitOfWorkDemo.App_Start
{
    public class DataBaseConfig
    {
        #region Public Methods

        /// <summary>
        /// Method which initialize database
        /// </summary>
        public static void InitializeDataBase()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }

        #endregion
    }
}