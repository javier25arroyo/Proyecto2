using DTOs;
using DTOs.ProyectoDTOs;
using SistemaProveeduriaDataAcccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProveeduriaDataAcccess.Mapper
{
    public class InventarioMapper : ISqlStatements, IObjectMapper
    {
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var inventory = new Inventario
            {
                Id = GetIntValue(row, "ID_INVENTARIO"),
                Usuario = null,
                Productos = null
            };

            return inventory;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }
            return lstResults;
        }

        public SqlOperations GetCreateStatement(BaseEntity entity)
        {
            var inventorySql = new SqlOperations { ProcedureName = "CRE_INVENTARIO_PR" };

            var inventory = (Inventario)entity;

            inventorySql.AddIntParam("ID_USUARIO", inventory.Usuario.Id);


            return inventorySql;
        }

        public SqlOperations GetDeleteStatement(BaseEntity entity)
        {
            var inventorySql = new SqlOperations { ProcedureName = "DEL_INVENTARIO_PR" };

            var inventory = (Inventario)entity;

            inventorySql.AddIntParam("ID_INVENTARIO", inventory.Id);

            return inventorySql;
        }

        public SqlOperations GetRetriveAllStatement()
        {
            var inventorySql = new SqlOperations { ProcedureName = "RET_ALL_INVENTARIO_PR" };

            return inventorySql;
        }

        public SqlOperations GetRetriveStatement(int id)
        {
            var inventorySql = new SqlOperations { ProcedureName = "RET_MEMBRESIA_BY_ID_PR" };
            inventorySql.AddIntParam("P_ID_INVENTARIO", id);

            return inventorySql;
        }

        public SqlOperations GetUpdateStatement(BaseEntity entity)
        {
            var inventorySql = new SqlOperations { ProcedureName = "UPDATE_INVENTARIO_PR" };
            var inventory = (Inventario)(entity);

            inventorySql.AddIntParam("P_ID_INVENTARIO", inventory.Id);
            inventorySql.AddIntParam("P_ID_USUARIO", inventory.Usuario.Id);

            return inventorySql;
        }
        public SqlOperations GetAssignProductStatement(int idInventory, int idProduct, int quantity)
        {
            var sqlInventory = new SqlOperations { ProcedureName = "CRE_INVENTARIO_PRODUCTO_PR" };

            sqlInventory.AddIntParam("P_ID_INVENTARIO", idInventory);
            sqlInventory.AddIntParam("P_ID_PRODUCTO", idProduct);
            sqlInventory.AddIntParam("P_CANTIDAD", quantity);

            return sqlInventory;
        }
        public SqlOperations GetUpdateInventarioProductoStatement(int idInventory, int idProduct, int quantity)
        {
            var sqlInventory = new SqlOperations { ProcedureName = "UPD_INVENTARIO_PRODUCTO_PR" };

            sqlInventory.AddIntParam("P_ID_INVENTARIO", idInventory);
            sqlInventory.AddIntParam("P_ID_PRODUCTO", idProduct);
            sqlInventory.AddIntParam("P_CANTIDAD", quantity);

            return sqlInventory;
        }
        public SqlOperations GetRetrieveAllInventarioProductoStatement()
        {
            var sqlInventory = new SqlOperations { ProcedureName = "RET_ALL_INVENTARIO_PRODUCTO_PR" };

            return sqlInventory;
        }
        public SqlOperations GetProductsAlreadyAssignStatement(int idInventory, int idProduct)
        {
            var sqlInventory = new SqlOperations { ProcedureName = "RET_INVENTARIO_PRODUCTO_BY_ID_PR" };

            sqlInventory.AddIntParam("P_ID_INVENTARIO", idInventory);
            sqlInventory.AddIntParam("P_ID_PRODUCTO", idProduct);

            return sqlInventory;
        }

        public SqlOperations GetCreateWithReturnStatement(BaseEntity entity)
        {
            var sqlInventory = new SqlOperations { ProcedureName = "CRE_INVENTARIO_WITH_RETURN_PR" };
            var newInventory = (Inventario)entity;

            sqlInventory.AddIntParam("P_ID_USUARIO", newInventory.Usuario.Id);

            return sqlInventory;
        }
        protected int GetIntValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is int || val is decimal))
                return (int)dic[attName];

            return -1;
        }
    }
}
