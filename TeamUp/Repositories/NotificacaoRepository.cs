using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Repositories
{
    public class NotificacaoRepository : BaseRepository<Notificacao>, INotificacaoRepository
    {
        public NotificacaoRepository(TeamUpContext context) : base(context)
        {
        }
    }
}