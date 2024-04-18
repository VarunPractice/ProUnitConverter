using Microsoft.Data.SqlClient;
using ProUnitConverter.Models;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace ProUnitConverter.DAL
{
    public class UnitDAL
    {
        private static string _connectionString { get; set; }
        private static UnitDAL _instance { get; set; }
        private static readonly object _instanceLock = new object();
        public static UnitDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        _instance = new UnitDAL();
                    }
                }
                return _instance;
            }
        }

        public UnitDAL()
        {
            _connectionString = Environment.GetEnvironmentVariable("PUCConnectionString"); ;
            UnitModel = new UnitModel();
        }
        UnitModel UnitModel { get; set; }
        public ObservableCollection<UnitModel> GetAllUnits()
        {
            var units = new ObservableCollection<UnitModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_GetAllUnits", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var unit = new UnitModel
                            {
                                UnitID = reader.GetInt32(reader.GetOrdinal("UnitId")),
                                Name = reader.GetString(reader.GetOrdinal("UnitName"))
                            };
                            
                            units.Add(unit);
                        }
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                var subunit = new SubunitModel
                                {
                                    SubunitId = reader.GetInt32(reader.GetOrdinal("SubunitId")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    UnitId = reader.GetInt32(reader.GetOrdinal("UnitId"))
                                };

                                var parentUnit = units.FirstOrDefault(u => u.UnitID == subunit.UnitId);
                                if (parentUnit != null)
                                {
                                    if (parentUnit.Subunits == null)
                                        parentUnit.Subunits = new ObservableCollection<SubunitModel>();

                                    parentUnit.Subunits.Add(subunit);
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    sharedResources.GlobalExceptionHandling.ExceptionHandler.Instance.RegisterGlobalExceptionHandler(ex);
                }
            }
            return units;
        }
    }
}