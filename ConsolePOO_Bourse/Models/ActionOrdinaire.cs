using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePOO_Bourse.Models
{
    public class ActionOrdinaire : ActionAbstraite
    {
        //ATTRIBUTS--------------------------------------------------------------------------------
        #region Attributs
        public int _id;

        #endregion
        //CONSTRUCTEURS----------------------------------------------------------------------------
        #region Constructeurs
        public ActionOrdinaire(Proprietaire proprietaire, int id, string nomAction, string symboleAction, int nbAction, decimal prixAction) : base(nomAction, symboleAction, nbAction, prixAction)
        {
            Proprietaire = proprietaire;
            Id = id;
        }

        #endregion
        //PROPRIETES-------------------------------------------------------------------------------
        #region Proprietes
        //public string NomAction { get; set; }

        //public string SymboleAction { get; set; }

        //public int NbAction { get; set; }

        //public decimal PrixAction { get; set; }

        public int Id { get; set; }

        public Proprietaire Proprietaire { get; set; }


        #endregion
        //METHODES---------------------------------------------------------------------------------
        #region Methodes
        public override string ToString()
        {
            return $"--------------- {NomAction} -------------\n" +
                   $"Id: {Id}\n" +
                   $"Symbole: {SymboleAction}\n" +
                   $"Valeur action: {PrixAction}\n";
        }

        #endregion
        //METHODES QUI DECLENCHE UN EVENEMENT------------------------------------------------------
        #region Methodes evenements

        #endregion
        //SURCHARGE OPERATEUR----------------------------------------------------------------------
        #region Surcharges operateurs

        #endregion
    }
}
