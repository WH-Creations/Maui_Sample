using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_App.Messages
{
    internal class InspectionDeletedMessage
    {
        public Guid InspectionId { get; }

        public InspectionDeletedMessage(Guid id)
        {
            InspectionId = id;
        }
    }
}
