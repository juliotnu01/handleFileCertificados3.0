using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace handleFileCertificados.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class HasCliente
    {
        public int id { get; set; }
        public string servicio_solicitado { get; set; }
        public string persona_de_contacto_nombre { get; set; }
        public string persona_de_contacto_celular { get; set; }
        public string persona_de_contacto_te_ext { get; set; }
        public string persona_de_contacto_email { get; set; }
        public string persona_de_contacto_puesto { get; set; }
        public string contacto_adicionales_compra { get; set; }
        public string contacto_adicionales_compra_correo { get; set; }
        public string contacto_adicionales_compra_telf { get; set; }
        public string contacto_adicionales_pagos { get; set; }
        public string contacto_adicionales_pagos_correo { get; set; }
        public string contacto_adicionales_pagos_telf { get; set; }
        public string contacto_adicionales_almacen { get; set; }
        public string contacto_adicionales_correo { get; set; }
        public string contacto_adicionales_telf { get; set; }
        //cliente  nombre: C:5
        public string datos_fisicos_requeremientos_facturacion_razon_social { get; set; }
        public string datos_fisicos_requeremientos_facturacion_rfc { get; set; }
        // cliente Direccion: C6  --- principio -- 
        public string datos_fisicos_requeremientos_facturacion_domiclio_fiscal_calle { get; set; }
        public string datos_fisicos_requeremientos_facturacion_domiclio_fiscal_numero { get; set; }
        // cliente colonia: C7  
        public string datos_fisicos_requeremientos_facturacion_domiclio_fiscal_colonia { get; set; }
        // cliente ciudad: C8  
        public string datos_fisicos_requeremientos_facturacion_domiclio_fiscal_ciudad { get; set; }
        // cliente estado: C9  
        public string datos_fisicos_requeremientos_facturacion_domiclio_fiscal_estado { get; set; }
        // cliente Direccion: C6  --- fin --  va concatenado todo en la direcicon

        // cliente CP: C10  
        public string datos_fisicos_requeremientos_facturacion_domiclio_fiscal_cp { get; set; }
        public string forma_de_pago { get; set; }
        public string moneda_factura { get; set; }
        public string correo_envio_factura { get; set; }
        public string cdfi { get; set; }
        public string metodo_de_pago { get; set; }
        public string termino_de_pago { get; set; }
        public string revision_de_factura_pagos_descripcion_revision_factura { get; set; }
        public string revision_de_factura_pagos_dias_revision_factura { get; set; }
        public string revision_de_factura_pagos_hora_revision_factura { get; set; }
        public string revision_de_factura_pagos_dias_confirmacion_pagos { get; set; }
        public string revision_de_factura_pagos_hora_confirmacion_pagos { get; set; }
        public string revision_de_factura_pagos_dias_pagos { get; set; }
        public string revision_de_factura_pagos_hora_pagos { get; set; }
        public string link_portal { get; set; }
        public string usuario_contraseña { get; set; }
        public string indiciones_alta_factura { get; set; }
        public string correo_soporte_tecnico_portal { get; set; }
        public string banco_ordenante { get; set; }
        public string cuenta_de_pago { get; set; }
        public string complemento_de_pago_se_envia_por_email { get; set; }
        public string informacion_adicional_complemento_de_pago { get; set; }
        public string lista_requerimiento_acceso_planta { get; set; }
        public string iva { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class HasCotizaicon
    {
        public int id { get; set; }
        public int cliente_id { get; set; }
        public int empleado_id { get; set; }
        public int moneda_id { get; set; }
        public int tiempo_de_entrega_id { get; set; }
        public int sucursal_cliente_id { get; set; }
        public string tipo_de_servicio { get; set; }
        public string nota_para_la_cotizacion { get; set; }
        public string estado_de_la_cotizacion { get; set; }
        //Cliente Contacto: C12
        public string contacto { get; set; }
        //Cliente Telf: G12
        public string contacto_telefono { get; set; }
        public string contacto_correo { get; set; }
        public string condicion { get; set; }
        public object nota_de_seguimiento { get; set; }
        public object ruta_print_document { get; set; }
        public int sub_total { get; set; }
        public int iva { get; set; }
        public int total { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public HasCliente has_cliente { get; set; }
    }

    public class HasRecibo
    {
        public int id { get; set; }
        public string estado { get; set; }
        public object ruta_pdf { get; set; }
        public int sub_total { get; set; }
        public int iva { get; set; }
        public int total { get; set; }
        public int cotizacion_id { get; set; }
        //Fechas: Fecha de recibo : V5  --- este dato tiene que ir seteado yyyy-mm-dd
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public HasCotizaicon has_cotizaicon { get; set; }
    }

    public class HasUnidad
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class HasClaveSat
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class HasEmpleado
    {
        public int id { get; set; }
        public string fecha_de_alta { get; set; }
        public string fecha_de_baja { get; set; }
        public int status { get; set; }
        public string nombre_completo { get; set; }
        public string rfc { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string codigo_postal { get; set; }
        public string telefono { get; set; }
        public string correo_factura { get; set; }
        public string departamento { get; set; }
        public string observaciones { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class HasMagnitud
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class HasAcreditacion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class HasIntrumento
    {
        public int id { get; set; }
        //instrumento: descripcion : L6
        public string nombre { get; set; }
        //instrumento: alcance : L11
        public string alcance { get; set; }
        public int acreditacion_id { get; set; }
        public int magnitude_id { get; set; }
        public int precio_venta { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public HasMagnitud has_magnitud { get; set; }
        public HasAcreditacion has_acreditacion { get; set; }
    }

    public class Root
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public string rutaexcel { get; set; }
        public string servicio { get; set; }
        public string unidad { get; set; }
        //instrumento: ID : L7
        public string identificacion { get; set; }
        //instrumento: marca : L9
        public string marca { get; set; }
        //instrumento: modelo : L10
        public string modelo { get; set; }
        //instrumento: serie : L8
        public string serie { get; set; }
        public int importe { get; set; }
        public int convertir_recibo { get; set; }
        //instrumento: NO. de informe : L5
        public string informe_id { get; set; }
        public string tipo { get; set; }
        public string vigencia { get; set; }
        public string ruta_doc_calibracion { get; set; }
        public string ruta_pdf_calibracion { get; set; }
        public int recibo_id { get; set; }
        public object calibracion_id { get; set; }
        public int instrumento_id { get; set; }
        public int cotizacion_id { get; set; }
        public object empleado_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int unidad_id { get; set; }
        public int clave_sat_id { get; set; }
        public HasRecibo has_recibo { get; set; }
        public HasUnidad has_unidad { get; set; }
        public HasClaveSat has_clave_sat { get; set; }
        public object has_calibracion { get; set; }
        public HasEmpleado has_empleado { get; set; }
        public HasIntrumento has_intrumento { get; set; }
    }



}
