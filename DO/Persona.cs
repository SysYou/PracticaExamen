using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Persona
    {
        #region Atributos

        private int iId;
        private string vNombre;
        private string iGenero;
        private string vCategoria;
        private int iValor;
        private bool bDisponible;

        #endregion

        #region Propiedades

        public int IId
        {
            get { return iId; }
            set { iId = value; }
        }

        public string VNombre
        {
            get { return vNombre; }
            set { vNombre = value; }
        }

        public string IGenero
        {
            get { return iGenero; }
            set { iGenero = value; }
        }

        public string VCategoria
        {
            get { return vCategoria; }
            set { vCategoria = value; }
        }

        public int IValor
        {
            get { return iValor; }
            set { iValor = value; }
        }

        public bool BDisponible
        {
            get { return bDisponible; }
            set { bDisponible = value; }
        }
        #endregion


    }



}
