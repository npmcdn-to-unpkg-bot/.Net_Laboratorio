using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Interfaces;
using SharedEntities.Entities;
using System.Data.Entity.Validation;

namespace DALayer.Handlers
{
    class UnidadHandlerEF : IUnidadHandler
    {
        TenantContext ctx;

        public UnidadHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createDestacamento(Destacamento destacamento)
        {
            Entities.Destacamento desE = new Entities.Destacamento();

            desE.descripcion = destacamento.descripcion;
            desE.foto = destacamento.foto;
            desE.capacidadInicial = destacamento.capacidadInicial;
            desE.ataque = destacamento.ataque;
            desE.escudo = destacamento.escudo;
            desE.efectividadAtaque = destacamento.efectividadAtaque;
            desE.vida = destacamento.vida;
            desE.velocidad = destacamento.velocidad;
            desE.enMision = destacamento.enMision;
            desE.nombre = destacamento.nombre;

            try
            {
                ctx.Destacamento.Add(desE);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void createEdificio(Edificio edificio)
        {
            Entities.Edificio EdificioE = new Entities.Edificio();

            EdificioE.descripcion = edificio.descripcion;
            EdificioE.foto = edificio.foto;
            EdificioE.capacidadInicial = edificio.capacidadInicial;
            EdificioE.ataque = edificio.ataque;
            EdificioE.escudo = edificio.escudo;
            EdificioE.efectividadAtaque = edificio.efectividadAtaque;
            EdificioE.vida = edificio.vida;
            EdificioE.nivel = edificio.nivel;
            EdificioE.factorCostoNivel = edificio.factorCostoNivel;
            EdificioE.factorCapacidad = edificio.factorCapacidad;
            EdificioE.nombre = edificio.nombre;

            try
            {
                ctx.Edificio.Add(EdificioE);
                ctx.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteDestacamento(int id)
        {
            var dest = (from c in ctx.Destacamento
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.Destacamento.Remove(dest);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEdificio(int id)
        {
            var edi = (from c in ctx.Edificio
                        where c.id == id
                        select c).SingleOrDefault();
            try
            {
                ctx.Edificio.Remove(edi);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Destacamento> getAllDestacamentos()
        {
            List<Destacamento> destacamentos = new List<Destacamento>();
            try
            {
                List<Entities.Destacamento> destE = ctx.Destacamento.ToList();
                foreach (Entities.Destacamento item in destE)
                {
                    Destacamento dest = new Destacamento(item.id, item.descripcion, item.foto, item.capacidadInicial, item.ataque,
                        item.escudo, item.efectividadAtaque, item.vida, item.velocidad, item.enMision, item.nombre);
                    destacamentos.Add(dest);
                }

                return destacamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Edificio> getAllEdificios()
        {
            List<Edificio> edificios = new List<Edificio>();
            try
            {
                List<Entities.Edificio> ediE = ctx.Edificio.ToList();
                foreach (Entities.Edificio item in ediE)
                {
                    Edificio edi = new Edificio(item.id,item.descripcion, item.foto, item.capacidadInicial, item.ataque,
                        item.escudo, item.efectividadAtaque, item.vida, item.nivel, item.factorCostoNivel, item.factorCapacidad, item.nombre);
                    edificios.Add(edi);
                }

                return edificios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Destacamento getDestacamento(int id)
        {
            try
            {
                var destE = (from c in ctx.Destacamento
                           where c.id == id
                           select c).SingleOrDefault();

                Destacamento dest = new Destacamento(destE.id, destE.descripcion, destE.foto, destE.capacidadInicial, destE.ataque,
                        destE.escudo, destE.efectividadAtaque, destE.vida, destE.velocidad, destE.enMision, destE.nombre);
                return dest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Edificio getEdificio(int id)
        {
            try
            {
                var ediE = (from c in ctx.Edificio
                           where c.id == id
                           select c).SingleOrDefault();

                Edificio edi = new Edificio(ediE.id, ediE.descripcion, ediE.foto, ediE.capacidadInicial, ediE.ataque,
                        ediE.escudo, ediE.efectividadAtaque, ediE.vida, ediE.nivel, ediE.factorCostoNivel, ediE.factorCapacidad, ediE.nombre);
                return edi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateDestacamento(Destacamento destacamento)
        {
            try
            {
                var destE = ctx.Destacamento
                    .Where(w => w.id == destacamento.id)
                    .SingleOrDefault();

                if (destE != null)
                {
                    destE.id = destacamento.id;
                    destE.descripcion = destacamento.descripcion;
                    destE.foto = destacamento.foto;
                    destE.capacidadInicial = destacamento.capacidadInicial;
                    destE.ataque = destacamento.ataque;
                    destE.escudo = destacamento.escudo;
                    destE.efectividadAtaque = destacamento.efectividadAtaque;
                    destE.vida = destacamento.vida;
                    destE.velocidad = destacamento.velocidad;
                    destE.enMision = destacamento.enMision;
                    destE.nombre = destacamento.nombre;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateEdificio(Edificio edificio)
        {
            try
            {
                var ediE = ctx.Edificio
                    .Where(w => w.id == edificio.id)
                    .SingleOrDefault();

                if (ediE != null)
                {
                    ediE.id = edificio.id;
                    ediE.descripcion = edificio.descripcion;
                    ediE.foto = edificio.foto;
                    ediE.capacidadInicial = edificio.capacidadInicial;
                    ediE.ataque = edificio.ataque;
                    ediE.escudo = edificio.escudo;
                    ediE.efectividadAtaque = edificio.efectividadAtaque;
                    ediE.vida = edificio.vida;
                    ediE.nivel = edificio.nivel;
                    ediE.factorCostoNivel = edificio.factorCostoNivel;
                    ediE.factorCapacidad = edificio.factorCapacidad;
                    ediE.nombre = edificio.nombre;

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
