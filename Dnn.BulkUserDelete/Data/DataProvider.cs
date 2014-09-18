using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DotNetNuke.Entities.Modules;

namespace Dnn.Modules.BulkUserDelete.Data
{
    internal abstract class DataProvider
    {
        #region Shared/Static Methods

        // singleton reference to the instantiated object 
        static DataProvider objProvider = null;

        // constructor
        static DataProvider()
        {
            CreateProvider();
        }

        // dynamically create provider
        private static void CreateProvider()
        {
            //don't need run-time instancing when using built-in sqlDataProvider class
            objProvider = new Data.SqlDataProvider();
        }

        // return the provider
        public static DataProvider Instance()
        {
            return objProvider;
        }

        #endregion

        #region abstract methods
        internal abstract IDataReader GetDeletedUsers(int portalId);
        internal abstract IDataReader FindNextUsersToDelete(int portalId, int numberOfUsers);
        #endregion

    }
}
