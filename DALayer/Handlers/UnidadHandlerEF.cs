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

        public int createDestacamento(Destacamento d)
        {
            Entities.Destacamento desE = new Entities.Destacamento(d.nombre, d.descripcion, d.foto, d.ataque, d.escudo,
                d.efectividadAtaque, d.vida, d.velocidad, d.enMision, d.tiempoInicial, d.incrementoTiempo);
            try
            {
                ctx.Destacamento.Add(desE);
                ctx.SaveChanges();

                Entities.Destacamento des = ctx.Destacamento.ToList().LastOrDefault();

                return des.id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int createEdificio(Edificio edificio)
        {
            Entities.Edificio EdificioE = new Entities.Edificio(edificio.nombre, edificio.descripcion, edificio.foto, edificio.ataque,
                edificio.escudo, edificio.efectividadAtaque, edificio.vida, edificio.tiempoInicial, edificio.incrementoTiempo);

            try
            {
                ctx.Edificio.Add(EdificioE);
                ctx.SaveChanges();
                
                Entities.Edificio edi = ctx.Edificio.ToList().LastOrDefault();

                return edi.id;
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
                    destacamentos.Add(item.getShared());
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
                    edificios.Add(item.getShared());
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

                return destE.getShared();
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
                
                return ediE.getShared();
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
                    destE.ataque = destacamento.ataque;
                    destE.escudo = destacamento.escudo;
                    destE.efectividadAtaque = destacamento.efectividadAtaque;
                    destE.vida = destacamento.vida;
                    destE.velocidad = destacamento.velocidad; 
                    destE.nombre = destacamento.nombre;
                    destE.tiempoInicial = destacamento.tiempoInicial;
                    destE.incrementoTiempo = destacamento.incrementoTiempo;
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
                    ediE.ataque = edificio.ataque;
                    ediE.escudo = edificio.escudo;
                    ediE.efectividadAtaque = edificio.efectividadAtaque;
                    ediE.vida = edificio.vida; 
                    ediE.nombre = edificio.nombre;
                    ediE.tiempoInicial = edificio.tiempoInicial;
                    ediE.incrementoTiempo = edificio.incrementoTiempo;

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
