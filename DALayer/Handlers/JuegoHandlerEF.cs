using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;
using System.Data.Entity.Validation;

namespace DALayer.Handlers
{
    public class JuegoHandlerEF : IJuegoHandler
    {

            AdminContext ctx;
            public JuegoHandlerEF(AdminContext tc)
            {
                ctx = tc;
            }

            public void createJuego(Juego gameTmp)
            {

                Entities.Juego game = new Entities.Juego();
                game.id = gameTmp.id;
                game.nombreJuego = gameTmp.nombreJuego;
                game.descripcion = gameTmp.descripcion;
                game.estado = gameTmp.estado;
                game.dominio = gameTmp.dominio;

                ctx.Juego.Add(game);
                try
                {

                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }

            public void deleteJuego(Guid idTmp)
            {
                var game = (from c in ctx.Juego
                           where c.id == idTmp
                           select c).SingleOrDefault();
                try
                {
                    ctx.Juego.Remove(game);
                    ctx.SaveChangesAsync().Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public List<Juego> getAllJuegos()
            {
                List<Juego> juegos = new List<Juego>();
                try
                {
                    List<Entities.Juego> juegosTmp = ctx.Juego.ToList();
                    foreach (Entities.Juego item in juegosTmp)
                    {
                        Juego game = new Juego(item.nombreJuego, item.dominio, item.id, item.estado, item.descripcion );
                        juegos.Add(game);
                    }
                    return juegos;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void getJuegoByUser()
            {
                throw new NotImplementedException();
            }

            public void updateJuego(Juego game)
            {
                try
                {
                    var gameTmp = ctx.Juego
                        .Where(w => w.id == game.id)
                        .SingleOrDefault();

                    if (gameTmp != null)
                    {
                        gameTmp.nombreJuego = game.nombreJuego;
                        gameTmp.dominio = game.dominio;
                        gameTmp.estado = game.estado;
                        gameTmp.descripcion = game.descripcion;
                       
                        ctx.SaveChangesAsync().Wait();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void updateRecursoByUser()
            {
                throw new NotImplementedException();
            }
        }
}
