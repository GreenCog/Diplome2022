
using Antitriche_diplome.models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.projet_eleve
{
    public class SequenceurDonnees
    {
        
        
        public SequenceurDonnees()
        {

        }

        public void Sequence(FormateurDonnees formateur, DateTime heureDebut, DateTime heureFin, Resultat resultat)
        {
            
            foreach (ResultatAFK ra in formateur.ResultatAFKs)
            {
                if (ra.TimeStamp > heureDebut)
                {
                    resultat.ResultatAFKs.Add(ra);
                }
                else if (ra.TimeStamp > heureFin)
                {
                    break;
                }
            }

            foreach (ResultatWindow rw in formateur.ResultatWindows)
            {
                if (rw.TimeStamp > heureDebut)
                {
                    resultat.ResultatWindows.Add(rw);
                }
                else if (rw.TimeStamp > heureFin)
                {
                    break;
                }
            }

            foreach (ResultatWeb rw in formateur.ResultatWebs)
            {
                if (rw.TimeStamp > heureDebut)
                {
                    resultat.ResultatWebs.Add(rw);
                }
                else if (rw.TimeStamp > heureFin)
                {
                    break;
                }
            }
        }

       



    }
}
