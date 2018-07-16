using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class VievEntity
    {
        public static Candidate VievCandidate (CandidatesContext context, int id)
        {
            var candidate = context.Candidates.Find(id);
            if (candidate != null)
                return candidate;
            else
                return null;
        }
    }
}
