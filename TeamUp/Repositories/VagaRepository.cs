﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    public class VagaRepository : BaseRepository<Vaga>, IVagaRepository
    {
        public VagaRepository(TeamUpContext context) : base(context)
        {
        }

        public Vaga FindVagaByIdWithProjeto(int id)
        {
            return context.vaga.Where(v => v.Id == id).Include(v => v.Projeto).FirstOrDefault();
        }
    }
}