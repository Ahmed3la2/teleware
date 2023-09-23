using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleWareAssessment.Data;

namespace TeleWare.Inferastructure
{
    public class DatabaseInitializer
    {
        public static void Initialize(TeleWareContext context)
        {
            context.Database.EnsureCreated();
            
        }
    }
}
