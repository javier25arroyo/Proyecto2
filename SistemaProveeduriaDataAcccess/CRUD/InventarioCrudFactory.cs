using DTOs;
using DTOs.ProyectoDTOs;
using SistemaProveeduriaDataAcccess.DAOs;
using SistemaProveeduriaDataAcccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProveeduriaDataAcccess.CRUD
{
    public class InventarioCrudFactory : CrudFactory
    {
        InventarioMapper _mapper;

        public InventarioCrudFactory()
        {
            _mapper = new InventarioMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity dto)
        {
            var inventory = (Inventario)dto;
            var inventorySql = _mapper.GetCreateStatement(inventory);
            dao.ExecuteProcedure(inventorySql);
        }

        public override void Delete(BaseEntity dto)
        {
            var inventory = (Inventario)dto;
            var inventorySql = _mapper.GetDeleteStatement(inventory);
            dao.ExecuteProcedure(inventorySql);
        }

        public override T Retrieve<T>(int id)
        {
            var sqlInventory = _mapper.GetRetriveStatement(id);
            var results = dao.ExecuteQueryProcedure(sqlInventory);

            if (results.Count == 1)
            {
                var objUser = _mapper.BuildObject(results[0]);

                return ((T)Convert.ChangeType(objUser, typeof(T)));

            }
            return default;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstInventory = new List<T>();

            //Buscamos el statement para hacer un retrieve all
            var sqlInventory = _mapper.GetRetriveAllStatement();

            //Ejecutamos el retrieve all
            var lstResults = dao.ExecuteQueryProcedure(sqlInventory);

            if (lstResults.Count > 0)
            {
                var objsMathOperation = _mapper.BuildObjects(lstResults);

                foreach (var op in objsMathOperation)
                {
                    lstInventory.Add((T)Convert.ChangeType(op, typeof(T)));
                }
            }

            return lstInventory;
        }

        public override void Update(BaseEntity dto)
        {
            var inventory = (Inventario)dto;
            var inventorySql = _mapper.GetUpdateStatement(inventory);
            dao.ExecuteProcedure(inventorySql);
        }
        public void AssignProducts(int idInventory, int idProduct, int quantity)
        {
            var sqlInventory = _mapper.GetAssignProductStatement(idInventory, idProduct, quantity);

            dao.ExecuteProcedure(sqlInventory);
        }

        public void UpdateInventarioProductoStatement(int idInventory, int idProduct, int quantity)
        {
            var sqlInventory = _mapper.GetUpdateInventarioProductoStatement(idInventory, idProduct, quantity);

            dao.ExecuteProcedure(sqlInventory);
        }
        public Inventario CreateWithReturn(BaseEntity dto)
        {
            var newInventory = (Inventario)dto;

            var sqlInventory = _mapper.GetCreateWithReturnStatement(newInventory);

            var lstResults = dao.ExecuteQueryProcedure(sqlInventory);

            if (lstResults.Count == 1)
            {
                var obj = _mapper.BuildObject(lstResults[0]);

                return (Inventario)Convert.ChangeType(obj, typeof(Inventario));
            }
            else
            {
                return null;
            }
        }
    }
}
