namespace Gunter.Extensions.InfoSources.Specialized.Models
{

    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class AEMETData
    {

        private rootOrigen origenField;

        private DateTime elaboradoField;

        private string nombreField;

        private string provinciaField;

        private rootDia[] prediccionField;

        private ushort idField;

        private decimal versionField;

        private string noNamespaceSchemaLocationField;

        /// <remarks/>
        public rootOrigen origen
        {
            get
            {
                return origenField;
            }
            set
            {
                origenField = value;
            }
        }

        /// <remarks/>
        public DateTime elaborado
        {
            get
            {
                return elaboradoField;
            }
            set
            {
                elaboradoField = value;
            }
        }

        /// <remarks/>
        public string nombre
        {
            get
            {
                return nombreField;
            }
            set
            {
                nombreField = value;
            }
        }

        /// <remarks/>
        public string provincia
        {
            get
            {
                return provinciaField;
            }
            set
            {
                provinciaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("dia", IsNullable = false)]
        public rootDia[] prediccion
        {
            get
            {
                return prediccionField;
            }
            set
            {
                prediccionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public ushort id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public decimal version
        {
            get
            {
                return versionField;
            }
            set
            {
                versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "https://www.w3.org/2001/XMLSchema-instance")]
        public string noNamespaceSchemaLocation
        {
            get
            {
                return noNamespaceSchemaLocationField;
            }
            set
            {
                noNamespaceSchemaLocationField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootOrigen
    {

        private string productorField;

        private string webField;

        private string enlaceField;

        private string languageField;

        private string copyrightField;

        private string nota_legalField;

        /// <remarks/>
        public string productor
        {
            get
            {
                return productorField;
            }
            set
            {
                productorField = value;
            }
        }

        /// <remarks/>
        public string web
        {
            get
            {
                return webField;
            }
            set
            {
                webField = value;
            }
        }

        /// <remarks/>
        public string enlace
        {
            get
            {
                return enlaceField;
            }
            set
            {
                enlaceField = value;
            }
        }

        /// <remarks/>
        public string language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }

        /// <remarks/>
        public string copyright
        {
            get
            {
                return copyrightField;
            }
            set
            {
                copyrightField = value;
            }
        }

        /// <remarks/>
        public string nota_legal
        {
            get
            {
                return nota_legalField;
            }
            set
            {
                nota_legalField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDia
    {

        private rootDiaProb_precipitacion[] prob_precipitacionField;

        private rootDiaCota_nieve_prov[] cota_nieve_provField;

        private rootDiaEstado_cielo[] estado_cieloField;

        private rootDiaViento[] vientoField;

        private rootDiaRacha_max[] racha_maxField;

        private rootDiaTemperatura temperaturaField;

        private rootDiaSens_termica sens_termicaField;

        private rootDiaHumedad_relativa humedad_relativaField;

        private byte uv_maxField;

        private bool uv_maxFieldSpecified;

        private DateTime fechaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("prob_precipitacion")]
        public rootDiaProb_precipitacion[] prob_precipitacion
        {
            get
            {
                return prob_precipitacionField;
            }
            set
            {
                prob_precipitacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("cota_nieve_prov")]
        public rootDiaCota_nieve_prov[] cota_nieve_prov
        {
            get
            {
                return cota_nieve_provField;
            }
            set
            {
                cota_nieve_provField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("estado_cielo")]
        public rootDiaEstado_cielo[] estado_cielo
        {
            get
            {
                return estado_cieloField;
            }
            set
            {
                estado_cieloField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("viento")]
        public rootDiaViento[] viento
        {
            get
            {
                return vientoField;
            }
            set
            {
                vientoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("racha_max")]
        public rootDiaRacha_max[] racha_max
        {
            get
            {
                return racha_maxField;
            }
            set
            {
                racha_maxField = value;
            }
        }

        /// <remarks/>
        public rootDiaTemperatura temperatura
        {
            get
            {
                return temperaturaField;
            }
            set
            {
                temperaturaField = value;
            }
        }

        /// <remarks/>
        public rootDiaSens_termica sens_termica
        {
            get
            {
                return sens_termicaField;
            }
            set
            {
                sens_termicaField = value;
            }
        }

        /// <remarks/>
        public rootDiaHumedad_relativa humedad_relativa
        {
            get
            {
                return humedad_relativaField;
            }
            set
            {
                humedad_relativaField = value;
            }
        }

        /// <remarks/>
        public byte uv_max
        {
            get
            {
                return uv_maxField;
            }
            set
            {
                uv_maxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool uv_maxSpecified
        {
            get
            {
                return uv_maxFieldSpecified;
            }
            set
            {
                uv_maxFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(DataType = "date")]
        public DateTime fecha
        {
            get
            {
                return fechaField;
            }
            set
            {
                fechaField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaProb_precipitacion
    {

        private string periodoField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string periodo
        {
            get
            {
                return periodoField;
            }
            set
            {
                periodoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaCota_nieve_prov
    {

        private string periodoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string periodo
        {
            get
            {
                return periodoField;
            }
            set
            {
                periodoField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaEstado_cielo
    {

        private string periodoField;

        private string descripcionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string periodo
        {
            get
            {
                return periodoField;
            }
            set
            {
                periodoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string descripcion
        {
            get
            {
                return descripcionField;
            }
            set
            {
                descripcionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaViento
    {

        private string direccionField;

        private string velocidadField;

        private string periodoField;

        /// <remarks/>
        public string direccion
        {
            get
            {
                return direccionField;
            }
            set
            {
                direccionField = value;
            }
        }

        /// <remarks/>
        public string velocidad
        {
            get
            {
                return velocidadField;
            }
            set
            {
                velocidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string periodo
        {
            get
            {
                return periodoField;
            }
            set
            {
                periodoField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaRacha_max
    {

        private string periodoField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string periodo
        {
            get
            {
                return periodoField;
            }
            set
            {
                periodoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaTemperatura
    {

        private byte maximaField;

        private byte minimaField;

        private rootDiaTemperaturaDato[] datoField;

        /// <remarks/>
        public byte maxima
        {
            get
            {
                return maximaField;
            }
            set
            {
                maximaField = value;
            }
        }

        /// <remarks/>
        public byte minima
        {
            get
            {
                return minimaField;
            }
            set
            {
                minimaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dato")]
        public rootDiaTemperaturaDato[] dato
        {
            get
            {
                return datoField;
            }
            set
            {
                datoField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaTemperaturaDato
    {

        private byte horaField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public byte hora
        {
            get
            {
                return horaField;
            }
            set
            {
                horaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public byte Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaSens_termica
    {

        private byte maximaField;

        private byte minimaField;

        private rootDiaSens_termicaDato[] datoField;

        /// <remarks/>
        public byte maxima
        {
            get
            {
                return maximaField;
            }
            set
            {
                maximaField = value;
            }
        }

        /// <remarks/>
        public byte minima
        {
            get
            {
                return minimaField;
            }
            set
            {
                minimaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dato")]
        public rootDiaSens_termicaDato[] dato
        {
            get
            {
                return datoField;
            }
            set
            {
                datoField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaSens_termicaDato
    {

        private byte horaField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public byte hora
        {
            get
            {
                return horaField;
            }
            set
            {
                horaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public byte Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaHumedad_relativa
    {

        private byte maximaField;

        private byte minimaField;

        private rootDiaHumedad_relativaDato[] datoField;

        /// <remarks/>
        public byte maxima
        {
            get
            {
                return maximaField;
            }
            set
            {
                maximaField = value;
            }
        }

        /// <remarks/>
        public byte minima
        {
            get
            {
                return minimaField;
            }
            set
            {
                minimaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dato")]
        public rootDiaHumedad_relativaDato[] dato
        {
            get
            {
                return datoField;
            }
            set
            {
                datoField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class rootDiaHumedad_relativaDato
    {

        private byte horaField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public byte hora
        {
            get
            {
                return horaField;
            }
            set
            {
                horaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public byte Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }
}