using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePOO_Bourse.Models
{
    public abstract class ActionAbstraite
    {
        //ATTRIBUTS--------------------------------------------------------------------------------
        #region Attributs
        public int _id;

        #endregion
        //CONSTRUCTEURS----------------------------------------------------------------------------
        #region Constructeurs
        public ActionAbstraite(string nomAction, string symboleAction, int nbAction, decimal prixAction)
        {
            NomAction = nomAction;
            SymboleAction = symboleAction;
            NbAction = nbAction;
            PrixAction = prixAction;
            VariationAction = 0;
        }

        #endregion
        //PROPRIETES-------------------------------------------------------------------------------
        #region Proprietes
        public string NomAction { get; set; }

        public string SymboleAction { get; set; }

        public int NbAction { get; set; }

        public decimal PrixAction { get; set; }

        public decimal VariationAction { get; set; }

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

        //public override string ToString()
        //{
        //    return $"--------------- {NomAction} -------------\n" +
        //           $"Id: {Id}\n" +
        //           $"Symbole: {SymboleAction}\n" +
        //           $"Valeur action: {PrixAction}\n";
        //}

        #endregion
        //METHODES QUI DECLENCHE UN EVENEMENT------------------------------------------------------
        #region Methodes evenements

        #endregion
        //SURCHARGE OPERATEUR----------------------------------------------------------------------
        #region Surcharges operateurs

        #endregion
    }
}
