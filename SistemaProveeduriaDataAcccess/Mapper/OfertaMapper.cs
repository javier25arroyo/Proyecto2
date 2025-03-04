using DTOs;
using SistemaProveeduriaDataAcccess.DAOs;

namespace SistemaProveeduriaDataAcccess.Mapper
{
    public class OfertaMapper : ISqlStatements, IObjectMapper
    {
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var oferta = new Oferta
            {
                Oferente = null,
                Licitacion = null,
                Estado = GetStringValue(row, "ESTADO"),
                Precio = GetDoubleValue(row, "PRECIO"),
                Producto = null
            };
            return oferta;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var oferta = BuildObject(row);
                lstResults.Add(oferta);
            }
            return lstResults;
        }

        public SqlOperations GetCreateStatement(BaseEntity entity)
        {
            var sqlOferta = new SqlOperations { ProcedureName = "CRE_OFERTA_PR" };
            var oferta = (Oferta)entity;

            sqlOferta.AddVarcharParam("P_ESTADO", oferta.Estado);
            sqlOferta.AddDoubleParam("P_PRECIO", oferta.Precio);
            sqlOferta.AddIntParam("P_ID_USUARIO", oferta.Oferente.Id);
            sqlOferta.AddIntParam("P_ID_LICITACION", oferta.Licitacion.Id);

            return sqlOferta;
        }

        public SqlOperations GetDeleteStatement(BaseEntity entity)
        {
            var sqlOferta = new SqlOperations { ProcedureName = "DEL_OFERTA_PR" };

            var oferta = (Oferta)entity;

            sqlOferta.AddIntParam("P_DOCUMENTO", oferta.Id);

            return sqlOferta;
        }

        public SqlOperations GetRetriveAllStatement()
        {
            var sqlOferta = new SqlOperations { ProcedureName = "RET_ALL_OFERTA_PR" };
            return sqlOferta;
        }
        public SqlOperations GetRetriveStatement(int id)
        {
            var sqlOferta = new SqlOperations { ProcedureName = "RET_OFERTA_BY_ID_PR" };
            sqlOferta.AddIntParam("P_ID_DOCUMENTO", id);

            return sqlOferta;
        }

        public SqlOperations GetUpdateStatement(BaseEntity entity)
        {
            var sqlOferta = new SqlOperations { ProcedureName = "UPDATE_OFERTA_PR" };

            var oferta = (Oferta)entity;
            sqlOferta.AddIntParam("P_ID_OFERTA", oferta.Id);
            sqlOferta.AddVarcharParam("P_ESTAOO", oferta.Estado);
            sqlOferta.AddDoubleParam("P_PRECIO", oferta.Precio);
            sqlOferta.AddIntParam("P_ID_USUARIO", oferta.Oferente.Id);
            sqlOferta.AddIntParam("P_ID_LICITACION", oferta.Licitacion.Id);

            return sqlOferta;
        }
        protected int GetIntValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is int || val is decimal))
                return (int)dic[attName];

            return -1;
        }

        protected double GetDoubleValue(Dictionary<string, object> dic, string attName)
        {
            if (dic.ContainsKey(attName) && (dic[attName] is double))
                return (double)dic[attName];

            return -1.0;
        }

        protected string GetStringValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is string))
                return (string)dic[attName];

            return null;
        }

        protected DateTime GetDateTimeValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is DateTime))
                return (DateTime)dic[attName];

            return DateTime.MinValue;
        }
    }
}