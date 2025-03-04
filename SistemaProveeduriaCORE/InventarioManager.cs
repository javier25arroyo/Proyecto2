using DTOs;
using DTOs.ProyectoDTOs;
using SistemaProveeduriaDataAcccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProveeduriaCORE
{
    public class InventarioManager
    {
        private InventarioCrudFactory _inventoryCrudFactory = new InventarioCrudFactory();
        public void Create(Inventario inventory, List<Producto> lstProducts)
        {
            var newInventory = _inventoryCrudFactory.CreateWithReturn(inventory);

            foreach (Producto newProduct in lstProducts)
            {
                _inventoryCrudFactory.AssignProducts(newInventory.Id, newProduct.Id, newProduct.Cantidad);
            }

        }
        public Inventario RetrieveById(int id)
        {
            if (_inventoryCrudFactory.Retrieve<Inventario>(id) == default)
                throw new Exception("Error:Inventory was not found");

            return _inventoryCrudFactory.Retrieve<Inventario>(id);
        }
        public List<Inventario> RetrieveAll()
        {
            return _inventoryCrudFactory.RetrieveAll<Inventario>();
        }
        public void Update(Inventario inventory)
        {
            if (_inventoryCrudFactory.Retrieve<Inventario>(inventory.Id) == default)
                throw new Exception("Error:Inventory was not found");

            _inventoryCrudFactory.Update(inventory);
        }
        public void Delete(Inventario inventory)
        {
            if (_inventoryCrudFactory.Retrieve<Inventario>(inventory.Id) == default)
                throw new Exception("Error:Inventory was not found");

            _inventoryCrudFactory.Delete(inventory);
        }
    }
}
