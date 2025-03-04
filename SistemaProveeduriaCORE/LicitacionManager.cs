﻿using DTOs;
using SistemaProveeduriaDataAcccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProveeduriaCORE
{
    public class LicitacionManager
    {
        private LicitacionCrudFactory _licitacionCrudFactory = new LicitacionCrudFactory();

        public void Create(Licitacion licitacion)
        {
            if(licitacion.FechaCierreOfertas >= licitacion.FechaCierreLicitacion && licitacion.FechaEntrega > licitacion.FechaCierreLicitacion)
            {
                throw new Exception("Fecha de cierre de ofertas es igual o mayor que la fecha de cierre de la licitacion/Fecha de entrega mayor a la fecha de cierre de la licitacion");
            }

            Licitacion newlicitacion = _licitacionCrudFactory.CreateWithReturn(licitacion);

            foreach (Producto producto in licitacion.Producto)
            {
                _licitacionCrudFactory.AddProducts(newlicitacion.Id, producto.Id, producto.Cantidad);
            }
        }

        public Licitacion RetrieveById(int id)
        {
            Licitacion licitacion = _licitacionCrudFactory.Retrieve<Licitacion>(id);
            if (licitacion == default)
            {
                throw new Exception("La licitacion no existe");
            }
            return licitacion;
        }
        public List<Licitacion> RetrieveAll()
        {
            List<Licitacion> lstLicitacion = _licitacionCrudFactory.RetrieveAll<Licitacion>();

            return lstLicitacion;
        }

        public void Update(BaseEntity dto)
        {
            var licitacion = (Licitacion)dto;
            if (RetrieveById(licitacion.Id) == default)
            {
                throw new Exception("La licitacion no existe");
            }
            else
            {
                _licitacionCrudFactory.Update(dto);
            }
        }

        public void Delete(BaseEntity dto)
        {
            var licitacion = (Licitacion)dto;
            if (RetrieveById(licitacion.Id) == default)
            {
                throw new Exception("La licitacion no existe");
            }
            else
            {
                _licitacionCrudFactory.Delete(licitacion);
            }
        }
    }
}
