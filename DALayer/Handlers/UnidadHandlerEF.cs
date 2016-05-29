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

        public void createDestacamento(Destacamento d)
        {
            //List<Entities.Costo> costos = new List<Entities.Costo>();
            //foreach (var item in d.costos)
            //{
            //    var c = new Entities.Costo(item.idRecurso, item.valor, item.incrementoNivel);
            //    costos.Add(c);
            //}
            //List<Entities.Capacidad> capacidad = new List<Entities.Capacidad>();
            //foreach (var item in d.capacidad)
            //{
            //    var c = new Entities.Capacidad(item.idRecurso, item.valor, item.incrementoNivel);
            //    capacidad.Add(c);
            //}

            Entities.Destacamento desE = new Entities.Destacamento(d.nombre, d.descripcion, d.foto,/* costos,
                capacidad,*/ d.ataque, d.escudo, d.efectividadAtaque, d.vida, d.velocidad, d.enMision);

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
            //List<Entities.Costo> cos = new List<Entities.Costo>();
            //foreach (var item in edificio.costos)
            //{
            //    var c = new Entities.Costo(item.idRecurso, item.valor, item.incrementoNivel);
            //    cos.Add(c);
            //}
            //List<Entities.Capacidad> cap = new List<Entities.Capacidad>();
            //foreach (var item in edificio.capacidad)
            //{
            //    var c = new Entities.Capacidad(item.idRecurso, item.valor, item.incrementoNivel);
            //    cap.Add(c);
            //}

            Entities.Edificio EdificioE = new Entities.Edificio(edificio.nombre, edificio.descripcion, edificio.foto,/* cos,
                cap,*/ edificio.ataque, edificio.escudo, edificio.efectividadAtaque, edificio.vida);

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
                    Destacamento dest = getDestacamento(item.id);
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
                    //List<Costo> cos = new List<Costo>();
                    //foreach (var item2 in item.costos)
                    //{
                    //    var c = new Costo(item2.idRecurso, item2.valor, item2.incrementoNivel);
                    //    cos.Add(c);
                    //}
                    Edificio edi = new Edificio(item.id,item.descripcion, item.foto, item.ataque,
                        item.escudo, item.efectividadAtaque, item.vida, item.nombre/*, cos*/);
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

                //List<Costo> cos = new List<Costo>();
                //foreach (var item in destE.costos)
                //{
                //    var c = new Costo(item.idRecurso, item.valor, item.incrementoNivel);
                //    cos.Add(c);
                //}
                //List<Capacidad> cap = new List<Capacidad>();
                //foreach (var item in destE.capacidad)
                //{
                //    var c = new Capacidad(item.idRecurso, item.valor, item.incrementoNivel);
                //    cap.Add(c);
                //}
                Destacamento dest = new Destacamento(destE.id, destE.descripcion, destE.foto, destE.ataque,
                        destE.escudo, destE.efectividadAtaque, destE.vida, destE.velocidad, destE.enMision, destE.nombre/*, cos, cap*/);
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

                //List<Costo> cos = new List<Costo>();
                //foreach (var item2 in ediE.costos)
                //{
                //    var c = new Costo(item2.idRecurso, item2.valor, item2.incrementoNivel);
                //    cos.Add(c);
                //}
                Edificio edi = new Edificio(ediE.id, ediE.descripcion, ediE.foto, ediE.ataque,
                        ediE.escudo, ediE.efectividadAtaque, ediE.vida,  ediE.nombre/*, cos*/);
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
                    destE.ataque = destacamento.ataque;
                    destE.escudo = destacamento.escudo;
                    destE.efectividadAtaque = destacamento.efectividadAtaque;
                    destE.vida = destacamento.vida;
                    destE.velocidad = destacamento.velocidad; 
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
                    ediE.ataque = edificio.ataque;
                    ediE.escudo = edificio.escudo;
                    ediE.efectividadAtaque = edificio.efectividadAtaque;
                    ediE.vida = edificio.vida; 
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
