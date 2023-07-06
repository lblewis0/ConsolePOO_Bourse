using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePOO_Bourse.Models
{
    public class Entreprise : Proprietaire
    {
        //ATTRIBUTS--------------------------------------------------------------------------------
        #region Attributs

        #endregion
        //CONSTRUCTEURS----------------------------------------------------------------------------
        #region Constructeurs
        public Entreprise(string nomEntreprise) : base()
        {
            NomEntreprise = nomEntreprise;
        }
        #endregion
        //PROPRIETES-------------------------------------------------------------------------------
        #region Proprietes
        public string NomEntreprise { get; set; }

        #endregion
        //METHODES---------------------------------------------------------------------------------
        #region Methodes

        #endregion
        //METHODES QUI DECLENCHE UN EVENEMENT------------------------------------------------------
        #region Methodes evenements

        #endregion
        //SURCHARGE OPERATEUR----------------------------------------------------------------------
        #region Surcharges operateurs

        #endregion
    }
}
