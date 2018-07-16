using Candidates.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class RemoveEntity
    {
        public static void DeleteCandidate(CandidatesContext context, int id)
        {
            var candidate = context.Candidates.Find(id);
            if(candidate != null)
            {
                context.Candidates.Remove(candidate);
                context.SaveChanges();
            }
        }
    }
}
