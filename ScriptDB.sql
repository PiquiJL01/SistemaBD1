CREATE DATABASE grupo5bd

CREATE TABLE almacen (
    al_codigo          Serial,
    tienda_ti_codigo   INTEGER NOT NULL
);

ALTER TABLE almacen ADD CONSTRAINT almacen_pk PRIMARY KEY ( al_codigo );

CREATE TABLE asistencia (
    as_codigo            Serial,
    as_fecha             DATE NOT NULL,
    as_hora_entrada      time NOT NULL,
    as_hora_salida       time NOT NULL,
    as_dia               VARCHAR(32672),
    empleado_em_codigo   INTEGER NOT NULL,
    horario_ho_codigo    INTEGER NOT NULL
);

ALTER TABLE asistencia
    ADD CHECK ( as_dia IN (
        'Domingo',
        'Jueves',
        'Lunes',
        'Martes',
        'Miercoles',
        'Sabado',
        'Viernes'
    ) );

ALTER TABLE asistencia ADD CONSTRAINT asistencia_pk PRIMARY KEY ( as_codigo );

CREATE TABLE beneficio (
    be_codigo        Serial,
    be_nombre        VARCHAR(32672) NOT NULL,
    be_descripcion   VARCHAR(32672)
);

ALTER TABLE beneficio ADD CONSTRAINT beneficio_pk PRIMARY KEY ( be_codigo );

CREATE TABLE ca_pu (
    canje_mp_codigo   INTEGER NOT NULL,
    punto_pu_codigo   INTEGER NOT NULL,
    cantidad1         INTEGER,
    fecha2            DATE
);

ALTER TABLE ca_pu ADD CONSTRAINT ca_pu_pk PRIMARY KEY ( canje_mp_codigo,
                                                        punto_pu_codigo );

CREATE TABLE canje (
    mp_codigo   INTEGER NOT NULL
);

ALTER TABLE canje ADD CONSTRAINT canje_pk PRIMARY KEY ( mp_codigo );

CREATE TABLE cargo (
    ca_codigo        Serial,
    ca_nombre        VARCHAR(32672) NOT NULL,
    ca_descripcion   VARCHAR(32672)
);

ALTER TABLE cargo ADD CONSTRAINT cargo_pk PRIMARY KEY ( ca_codigo );

CREATE TABLE cheque (
    mp_codigo   INTEGER NOT NULL,
    ch_número   VARCHAR(32672) NOT NULL
);

ALTER TABLE cheque ADD CONSTRAINT cheque_pk PRIMARY KEY ( mp_codigo );

CREATE TABLE cl_pu (
    punto_pu_codigo   INTEGER NOT NULL,
    cliente_cl_rif    VARCHAR(32672) NOT NULL,
    cantidad          INTEGER
);

ALTER TABLE cl_pu ADD CONSTRAINT cl_pu_pk PRIMARY KEY ( punto_pu_codigo,
                                                        cliente_cl_rif );

CREATE TABLE clasificacion (
    cl_codigo        Serial,
    cl_nombre        VARCHAR(32672) NOT NULL,
    cl_descripcion   VARCHAR(32672)
);

ALTER TABLE clasificacion ADD CONSTRAINT clasificacion_pk PRIMARY KEY ( cl_codigo );

CREATE TABLE cliente (
    cl_rif                         VARCHAR(32672) NOT NULL,
    tienda_ti_codigo               INTEGER,
    correo_electronico_ce_codigo   INTEGER NOT NULL
);

ALTER TABLE cliente ADD CONSTRAINT cliente_pk PRIMARY KEY ( cl_rif );

CREATE TABLE correo_electronico (
    ce_codigo      Serial,
    ce_direccion   VARCHAR(32672) NOT NULL
);

ALTER TABLE correo_electronico ADD CONSTRAINT correo_electronico_pk PRIMARY KEY ( ce_codigo );

CREATE TABLE de_pe (
    departamento_de_codigo   INTEGER NOT NULL,
    pedido_pe_codigo         INTEGER NOT NULL,
    fechatiempo              TIMESTAMP
);

ALTER TABLE de_pe ADD CONSTRAINT de_pe_pk PRIMARY KEY ( departamento_de_codigo,
                                                        pedido_pe_codigo );

CREATE TABLE de_pr (
    descuento_de_codigo   INTEGER NOT NULL,
    producto_pr_codigo    INTEGER NOT NULL,
    fecha_inicio2         DATE,
    fecha_fin2            DATE
);

ALTER TABLE de_pr ADD CONSTRAINT de_pr_pk PRIMARY KEY ( descuento_de_codigo,
                                                        producto_pr_codigo );

CREATE TABLE departamento (
    de_codigo        Serial,
    de_nombre        VARCHAR(32672) NOT NULL,
    de_descripcion   VARCHAR(32672)
);

ALTER TABLE departamento ADD CONSTRAINT departamento_pk PRIMARY KEY ( de_codigo );

CREATE TABLE descuento (
    de_codigo        Serial,
    de_porcentaje    REAL NOT NULL,
    de_descripcion   VARCHAR(32672)
);

ALTER TABLE descuento ADD CONSTRAINT descuento_pk PRIMARY KEY ( de_codigo );

CREATE TABLE efectivo (
    mp_codigo          INTEGER NOT NULL,
    moneda_mo_codigo   INTEGER NOT NULL,
    monto              REAL
);

ALTER TABLE efectivo ADD CONSTRAINT efectivo_pk PRIMARY KEY ( mp_codigo );

CREATE TABLE em_be (
    empleado_em_codigo    INTEGER NOT NULL,
    beneficio_be_codigo   INTEGER NOT NULL,
    fecha                 DATE,
    monto2                REAL
);

ALTER TABLE em_be ADD CONSTRAINT em_be_pk PRIMARY KEY ( empleado_em_codigo,
                                                        beneficio_be_codigo );

CREATE TABLE em_ca (
    empleado_em_codigo   INTEGER NOT NULL,
    cargo_ca_codigo      INTEGER NOT NULL,
    sueldo               REAL,
    fecha_inicio         DATE NOT NULL,
    fecha_fin            DATE
);

ALTER TABLE em_ca ADD CONSTRAINT em_ca_pk PRIMARY KEY ( empleado_em_codigo,
                                                        cargo_ca_codigo );

CREATE TABLE em_ho (
    empleado_em_codigo   INTEGER NOT NULL,
    horario_ho_codigo    INTEGER NOT NULL
);

ALTER TABLE em_ho ADD CONSTRAINT em_ho_pk PRIMARY KEY ( empleado_em_codigo,
                                                        horario_ho_codigo );

CREATE TABLE empleado (
    em_codigo                      Serial,
    em_rif                         VARCHAR(32672) NOT NULL,
    em_cedula                      VARCHAR(32672) NOT NULL,
    em_1er_nombre                  VARCHAR(32672) NOT NULL,
    em_2do_nombre                  VARCHAR(32672),
    em_1er_apellido                VARCHAR(32672) NOT NULL,
    em_2do_apellido                VARCHAR(32672),
    tienda_ti_codigo               INTEGER NOT NULL,
    departamento_de_codigo         INTEGER NOT NULL,
    empleado_em_codigo             INTEGER,
    lugar_lu_codigo                INTEGER NOT NULL,
    correo_electronico_ce_codigo   INTEGER NOT NULL
);

ALTER TABLE empleado ADD CONSTRAINT empleado_pk PRIMARY KEY ( em_codigo );

CREATE TABLE estatus (
    es_codigo        Serial,
    es_tipo          VARCHAR(32672) NOT NULL,
    es_descripcion   VARCHAR(32672)
);

ALTER TABLE estatus ADD CONSTRAINT estatus_pk PRIMARY KEY ( es_codigo );

CREATE TABLE horario (
    ho_codigo        Serial,
    ho_hora_inicio   time NOT NULL,
    ho_hora_salida   time NOT NULL,
    ho_turno         VARCHAR(32672) NOT NULL,
    ho_dia           VARCHAR(32672) NOT NULL
);

ALTER TABLE horario
    ADD CHECK ( ho_turno IN (
        'Diurno',
        'Matutino',
        'Nocturno',
        'Vespertino'
    ) );

ALTER TABLE horario
    ADD CHECK ( ho_dia IN (
        'Domingo',
        'Jueves',
        'Lunes',
        'Martes',
        'Miercoles',
        'Sabado',
        'Viernes'
    ) );

ALTER TABLE horario ADD CONSTRAINT horario_pk PRIMARY KEY ( ho_codigo );

CREATE TABLE imagen_producto (
    codigo               Serial,
    nombre               VARCHAR(32672),
    ubicacion            VARCHAR(32672) NOT NULL,
    descripcion          VARCHAR(32672),
    producto_pr_codigo   INTEGER NOT NULL
);

ALTER TABLE imagen_producto ADD CONSTRAINT imagen_producto_pk PRIMARY KEY ( codigo );

CREATE TABLE juridico (
    cl_rif                      VARCHAR(32672) NOT NULL,
    ju_denominacion_comercial   VARCHAR(32672) NOT NULL,
    ju_razon_social             VARCHAR(32672) NOT NULL,
    ju_capital                  REAL NOT NULL,
    ju_pagina_web               VARCHAR(32672) NOT NULL,
    lugar_lu_codigo             INTEGER NOT NULL,
    lugar_lu_codigo1            INTEGER NOT NULL
);

ALTER TABLE juridico ADD CONSTRAINT juridico_pk PRIMARY KEY ( cl_rif );

CREATE TABLE lugar (
    lu_codigo         Serial,
    lu_nombre         VARCHAR(32672) NOT NULL,
    lu_tipo           VARCHAR(32672) NOT NULL,
    lu_descripcion    VARCHAR(32672),
    lugar_lu_codigo   INTEGER
);

ALTER TABLE lugar
    ADD CHECK ( lu_tipo IN (
        'Direccion',
        'Estado',
        'Municipio',
        'Pais',
        'Parroquia'
    ) );

ALTER TABLE lugar ADD CONSTRAINT lugar_pk PRIMARY KEY ( lu_codigo );

CREATE TABLE marca (
    ma_codigo        Serial,
    ma_nombre        VARCHAR(32672) NOT NULL,
    ma_propia        CHAR(254) NOT NULL,
    ma_descripcion   VARCHAR(32672)
);

ALTER TABLE marca ADD CONSTRAINT marca_pk PRIMARY KEY ( ma_codigo );

CREATE TABLE metodo_de_pago (
    mp_codigo        Serial,
    mp_nombre        VARCHAR(32672) NOT NULL,
    mp_descripción   VARCHAR(32672),
    mp_fecha         DATE NOT NULL
);

ALTER TABLE metodo_de_pago ADD CONSTRAINT método_de_pago_pk PRIMARY KEY ( mp_codigo );

CREATE TABLE mo_tc (
    tasa_de_cambio_tc_codigo   INTEGER NOT NULL,
    moneda_mo_codigo           INTEGER NOT NULL,
    fechaimplementacion        DATE
);

ALTER TABLE mo_tc ADD CONSTRAINT mo_tc_pk PRIMARY KEY ( tasa_de_cambio_tc_codigo,
                                                        moneda_mo_codigo );

CREATE TABLE moneda (
    mo_codigo        Serial,
    mo_nombre        VARCHAR(32672) NOT NULL,
    mo_descripcion   VARCHAR(32672)
);

ALTER TABLE moneda ADD CONSTRAINT moneda_pk PRIMARY KEY ( mo_codigo );

CREATE TABLE naturales (
    cl_rif            VARCHAR(32672) NOT NULL,
    na_cedula         VARCHAR(32672) NOT NULL,
    na_1er_nombre     VARCHAR(32672) NOT NULL,
    na_2do_nombre     VARCHAR(32672),
    na_1er_apellido   VARCHAR(32672) NOT NULL,
    na_2do_apellido   VARCHAR(32672),
    lugar_lu_codigo   INTEGER NOT NULL
);

ALTER TABLE naturales ADD CONSTRAINT natural_pk PRIMARY KEY ( cl_rif );

CREATE TABLE pasillo (
    pa_codigo            Serial,
    pa_numero            INTEGER NOT NULL,
    pa_nombre            VARCHAR(32672) NOT NULL,
    pa_descripcion       VARCHAR(32672),
    tienda_ti_codigo     INTEGER NOT NULL,
    empleado_em_codigo   INTEGER NOT NULL
);

ALTER TABLE pasillo ADD CONSTRAINT pasillo_pk PRIMARY KEY ( pa_codigo,
                                                            tienda_ti_codigo );

CREATE TABLE pe_es (
    pedido_pe_codigo    INTEGER NOT NULL,
    estatus_es_codigo   INTEGER NOT NULL,
    fecha               TIMESTAMP NOT NULL,
    empleado            INTEGER NOT NULL
);

ALTER TABLE pe_es ADD CONSTRAINT pe_es_pk PRIMARY KEY ( pedido_pe_codigo,
                                                        estatus_es_codigo );

CREATE TABLE pe_pr (
    producto_pr_codigo   INTEGER NOT NULL,
    pedido_pe_codigo     INTEGER NOT NULL,
    cantidad             INTEGER,
    descuento            INTEGER,
    monto                REAL
);

ALTER TABLE pe_pr ADD CONSTRAINT pe_pr_pk PRIMARY KEY ( producto_pr_codigo,
                                                        pedido_pe_codigo );

CREATE TABLE pe_ro (
    permiso_pe_codigo   INTEGER NOT NULL,
    rol_ro_codigo       INTEGER NOT NULL
);

ALTER TABLE pe_ro ADD CONSTRAINT pe_ro_pk PRIMARY KEY ( permiso_pe_codigo,
                                                        rol_ro_codigo );

CREATE TABLE pedido (
    pe_codigo                  Serial,
    pe_monto_total             REAL NOT NULL,
    pe_fecha                   DATE NOT NULL,
    pe_esta_aprovado           CHAR(254) NOT NULL,
    pe_es_en_linea             CHAR(254),
    método_de_pago_mp_codigo   INTEGER,
    cliente_cl_rif             VARCHAR(32672),
    proveedor_pr_rif           VARCHAR(32672)
);

ALTER TABLE pedido
    ADD CONSTRAINT generador CHECK ( ( ( cliente_cl_rif IS NOT NULL )
                                       AND ( proveedor_pr_rif IS NULL ) )
                                     OR ( ( proveedor_pr_rif IS NOT NULL )
                                          AND ( cliente_cl_rif IS NULL ) )
                                     OR ( ( cliente_cl_rif IS NULL )
                                          AND ( proveedor_pr_rif IS NULL ) ) );

ALTER TABLE pedido ADD CONSTRAINT pedido_pk PRIMARY KEY ( pe_codigo );

CREATE TABLE periodo_vacacional (
    pv_codigo            Serial,
    pv_fecha_inicio      DATE NOT NULL,
    pv_fecha_final       DATE NOT NULL,
    empleado_em_codigo   INTEGER NOT NULL
);

ALTER TABLE periodo_vacacional ADD CONSTRAINT periodo_vacacional_pk PRIMARY KEY ( pv_codigo );

CREATE TABLE permiso (
    pe_codigo           Serial,
    pe_nombre           VARCHAR(32672) NOT NULL,
    pe_esta_permitido   CHAR(254) NOT NULL,
    pe_descripción      VARCHAR(32672)
);

ALTER TABLE permiso ADD CONSTRAINT permiso_pk PRIMARY KEY ( pe_codigo );

CREATE TABLE persona_contacto (
    pc_codigo          Serial,
    pc_cedula          VARCHAR(32672) NOT NULL,
    pc_1er_nombre      VARCHAR(32672) NOT NULL,
    pc_2do_nombre      VARCHAR(32672),
    pc_1er_apellido    VARCHAR(32672) NOT NULL,
    pc_2do_apellido    VARCHAR(32672),
    juridico_cl_rif    VARCHAR(32672),
    proveedor_pr_rif   VARCHAR(32672)
);

ALTER TABLE persona_contacto
    ADD CONSTRAINT arc_3 CHECK ( ( ( juridico_cl_rif IS NOT NULL )
                                   AND ( proveedor_pr_rif IS NULL ) )
                                 OR ( ( proveedor_pr_rif IS NOT NULL )
                                      AND ( juridico_cl_rif IS NULL ) ) );

ALTER TABLE persona_contacto ADD CONSTRAINT persona_contacto_pk PRIMARY KEY ( pc_codigo );

CREATE TABLE pr_pr (
    producto_pr_codigo   INTEGER NOT NULL,
    proveedor_pr_rif     VARCHAR(32672) NOT NULL
);

ALTER TABLE pr_pr ADD CONSTRAINT pr_pr_pk PRIMARY KEY ( producto_pr_codigo,
                                                        proveedor_pr_rif );

CREATE TABLE pr_zo (
    producto_pr_codigo   INTEGER NOT NULL,
    zona_zo_codigo       INTEGER NOT NULL,
    cantidad             INTEGER
);

ALTER TABLE pr_zo ADD CONSTRAINT pr_zo_pk PRIMARY KEY ( producto_pr_codigo,
                                                        zona_zo_codigo );

CREATE TABLE producto (
    pr_codigo                 Serial,
    pr_nombre                 VARCHAR(32672) NOT NULL,
    pr_es_alimenticio         CHAR(254) NOT NULL,
    pr_precio                 REAL NOT NULL,
    pr_calidad                VARCHAR(32672) NOT NULL,
    pr_descripcion            VARCHAR(32672),
    marca_ma_codigo           INTEGER NOT NULL,
    clasificacion_cl_codigo   INTEGER NOT NULL
);

ALTER TABLE producto
    ADD CHECK ( pr_calidad IN (
        'Alta',
        'Baja',
        'Regular'
    ) );

ALTER TABLE producto ADD CONSTRAINT producto_pk PRIMARY KEY ( pr_codigo );

CREATE TABLE proveedor (
    pr_rif                         VARCHAR(32672) NOT NULL,
    pr_razon_social                VARCHAR(32672) NOT NULL,
    pr_denominacion_comercial      VARCHAR(32672) NOT NULL,
    pr_pag_web                     VARCHAR(32672),
    lugar_lu_codigo                INTEGER NOT NULL,
    lugar_lu_codigo2               INTEGER NOT NULL,
    correo_electronico_ce_codigo   INTEGER NOT NULL
);

ALTER TABLE proveedor ADD CONSTRAINT proveedor_pk PRIMARY KEY ( pr_rif );

CREATE TABLE punto (
    pu_codigo                 Serial,
    pu_valor_punto            REAL NOT NULL,
    pu_descripcion            VARCHAR(32672),
    pu_fecha_implementacion   DATE
);

ALTER TABLE punto ADD CONSTRAINT punto_pk PRIMARY KEY ( pu_codigo );

CREATE TABLE ro_em (
    empleado_em_codigo   INTEGER NOT NULL,
    rol_ro_codigo        INTEGER NOT NULL
);

ALTER TABLE ro_em ADD CONSTRAINT ro_em_pk PRIMARY KEY ( empleado_em_codigo,
                                                        rol_ro_codigo );

CREATE TABLE rol (
    ro_codigo        Serial,
    ro_nombre        VARCHAR(32672) NOT NULL,
    ro_descripcion   VARCHAR(32672)
);

ALTER TABLE rol ADD CONSTRAINT rol_pk PRIMARY KEY ( ro_codigo );

CREATE TABLE tarjeta (
    mp_codigo              INTEGER NOT NULL,
    ta_tipo                VARCHAR(32672) NOT NULL,
    ta_numero              INTEGER NOT NULL,
    ta_cvv                 INTEGER NOT NULL,
    ta_nombre_impreso      VARCHAR(32672) NOT NULL,
    ta_fecha_vencimiento   DATE NOT NULL
);

ALTER TABLE tarjeta
    ADD CHECK ( ta_tipo IN (
        'American Express',
        'Debito',
        'Diner´s Club',
        'Discovery',
        'Maestro',
        'MasterCard',
        'Visa'
    ) );

ALTER TABLE tarjeta ADD CONSTRAINT tarjeta_pk PRIMARY KEY ( mp_codigo );

CREATE TABLE tasa_de_cambio (
    tc_codigo             Serial,
    tc_factor_de_cambio   REAL NOT NULL
);

ALTER TABLE tasa_de_cambio ADD CONSTRAINT tasa_de_cambio_pk PRIMARY KEY ( tc_codigo );

CREATE TABLE telefono (
    te_codigo_pais               INTEGER NOT NULL,
    te_codigo_area               INTEGER NOT NULL,
    te_numero                    INTEGER NOT NULL,
    te_tipo                      VARCHAR(32672) NOT NULL,
    persona_contacto_pc_codigo   INTEGER,
    empleado_em_codigo           INTEGER,
    cliente_cl_rif               VARCHAR(32672),
    proveedor_pr_rif             VARCHAR(32672)
);

ALTER TABLE telefono
    ADD CHECK ( te_tipo IN (
        'Fijo',
        'Movil'
    ) );

ALTER TABLE telefono
    ADD CONSTRAINT arc_4 CHECK ( ( ( persona_contacto_pc_codigo IS NOT NULL )
                                   AND ( proveedor_pr_rif IS NULL )
                                   AND ( cliente_cl_rif IS NULL )
                                   AND ( empleado_em_codigo IS NULL ) )
                                 OR ( ( proveedor_pr_rif IS NOT NULL )
                                      AND ( persona_contacto_pc_codigo IS NULL )
                                      AND ( cliente_cl_rif IS NULL )
                                      AND ( empleado_em_codigo IS NULL ) )
                                 OR ( ( cliente_cl_rif IS NOT NULL )
                                      AND ( persona_contacto_pc_codigo IS NULL )
                                      AND ( proveedor_pr_rif IS NULL )
                                      AND ( empleado_em_codigo IS NULL ) )
                                 OR ( ( empleado_em_codigo IS NOT NULL )
                                      AND ( persona_contacto_pc_codigo IS NULL )
                                      AND ( proveedor_pr_rif IS NULL )
                                      AND ( cliente_cl_rif IS NULL ) ) );

ALTER TABLE telefono
    ADD CONSTRAINT arc_1 CHECK ( ( ( cliente_cl_rif IS NOT NULL )
                                   AND ( persona_contacto_pc_codigo IS NULL ) )
                                 OR ( ( persona_contacto_pc_codigo IS NOT NULL )
                                      AND ( cliente_cl_rif IS NULL ) ) );

ALTER TABLE telefono
    ADD CONSTRAINT telefono_pk PRIMARY KEY ( te_numero,
                                             te_codigo_area,
                                             te_codigo_pais );

CREATE TABLE ti_de (
    departamento_de_codigo   INTEGER NOT NULL,
    tienda_ti_codigo         INTEGER NOT NULL
);

ALTER TABLE ti_de ADD CONSTRAINT ti_de_pk PRIMARY KEY ( departamento_de_codigo,
                                                        tienda_ti_codigo );

CREATE TABLE tienda (
    ti_codigo         Serial,
    ti_nombre         VARCHAR(32672) NOT NULL,
    ti_descripcion    VARCHAR(32672),
    lugar_lu_codigo   INTEGER NOT NULL,
    cliente_cl_rif    VARCHAR(32672)
);

ALTER TABLE tienda ADD CONSTRAINT tienda_pk PRIMARY KEY ( ti_codigo );

CREATE TABLE zona (
    zo_codigo                  Serial,
    zo_nombre                  VARCHAR(32672) NOT NULL,
    pasillo_tienda_ti_codigo   INTEGER,
    pasillo_pa_codigo          INTEGER,
    almacen_al_codigo          INTEGER,
    tipo                       VARCHAR(32672)
);

ALTER TABLE zona
    ADD CHECK ( tipo IN (
        'Congelador',
        'General',
        'Refrigerador'
    ) );

ALTER TABLE zona
    ADD CHECK ( almacen_al_codigo IS NULL
                AND tipo IS NULL );

ALTER TABLE zona
    ADD CONSTRAINT arc_10 CHECK ( ( ( pasillo_pa_codigo IS NOT NULL )
                                    AND ( pasillo_tienda_ti_codigo IS NOT NULL )
                                    AND ( almacen_al_codigo IS NULL ) )
                                  OR ( ( almacen_al_codigo IS NOT NULL )
                                       AND ( pasillo_pa_codigo IS NULL )
                                       AND ( pasillo_tienda_ti_codigo IS NULL ) ) );

ALTER TABLE zona ADD CONSTRAINT zona_pk PRIMARY KEY ( zo_codigo );

ALTER TABLE ALMACEN
    ADD CONSTRAINT almacen_tienda_fk FOREIGN KEY ( tienda_ti_codigo )
        REFERENCES tienda ( ti_codigo )
;

ALTER TABLE ASISTENCIA
    ADD CONSTRAINT asistencia_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE ASISTENCIA
    ADD CONSTRAINT asistencia_horario_fk FOREIGN KEY ( horario_ho_codigo )
        REFERENCES horario ( ho_codigo )
;

ALTER TABLE CA_PU
    ADD CONSTRAINT ca_pu_canje_fk FOREIGN KEY ( canje_mp_codigo )
        REFERENCES canje ( mp_codigo )
;

ALTER TABLE CA_PU
    ADD CONSTRAINT ca_pu_punto_fk FOREIGN KEY ( punto_pu_codigo )
        REFERENCES punto ( pu_codigo )
;

ALTER TABLE CANJE
    ADD CONSTRAINT canje_método_de_pago_fk FOREIGN KEY ( mp_codigo )
        REFERENCES metodo_de_pago ( mp_codigo )
;

ALTER TABLE CHEQUE
    ADD CONSTRAINT cheque_método_de_pago_fk FOREIGN KEY ( mp_codigo )
        REFERENCES metodo_de_pago ( mp_codigo )
;

ALTER TABLE CL_PU
    ADD CONSTRAINT cl_pu_cliente_fk FOREIGN KEY ( cliente_cl_rif )
        REFERENCES cliente ( cl_rif )
 
;

ALTER TABLE CL_PU
    ADD CONSTRAINT cl_pu_punto_fk FOREIGN KEY ( punto_pu_codigo )
        REFERENCES punto ( pu_codigo )
;

ALTER TABLE CLIENTE
    ADD CONSTRAINT cliente_correo_electronico_fk FOREIGN KEY ( correo_electronico_ce_codigo )
        REFERENCES correo_electronico ( ce_codigo )
;

ALTER TABLE CLIENTE
    ADD CONSTRAINT cliente_tienda_fk FOREIGN KEY ( tienda_ti_codigo )
        REFERENCES tienda ( ti_codigo )
;

ALTER TABLE DE_PE
    ADD CONSTRAINT de_pe_departamento_fk FOREIGN KEY ( departamento_de_codigo )
        REFERENCES departamento ( de_codigo )
;

ALTER TABLE DE_PE
    ADD CONSTRAINT de_pe_pedido_fk FOREIGN KEY ( pedido_pe_codigo )
        REFERENCES pedido ( pe_codigo )
;

ALTER TABLE DE_PR
    ADD CONSTRAINT de_pr_descuento_fk FOREIGN KEY ( descuento_de_codigo )
        REFERENCES descuento ( de_codigo )
;

ALTER TABLE DE_PR
    ADD CONSTRAINT de_pr_producto_fk FOREIGN KEY ( producto_pr_codigo )
        REFERENCES producto ( pr_codigo )
;

ALTER TABLE EFECTIVO
    ADD CONSTRAINT efectivo_método_de_pago_fk FOREIGN KEY ( mp_codigo )
        REFERENCES metodo_de_pago ( mp_codigo )
;

ALTER TABLE EFECTIVO
    ADD CONSTRAINT efectivo_moneda_fk FOREIGN KEY ( moneda_mo_codigo )
        REFERENCES moneda ( mo_codigo )
;

ALTER TABLE EM_BE
    ADD CONSTRAINT em_be_beneficio_fk FOREIGN KEY ( beneficio_be_codigo )
        REFERENCES beneficio ( be_codigo )
;

ALTER TABLE EM_BE
    ADD CONSTRAINT em_be_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
 
;

ALTER TABLE EM_CA
    ADD CONSTRAINT em_ca_cargo_fk FOREIGN KEY ( cargo_ca_codigo )
        REFERENCES cargo ( ca_codigo )
;

ALTER TABLE EM_CA
    ADD CONSTRAINT em_ca_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE EM_HO
    ADD CONSTRAINT em_ho_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE EM_HO
    ADD CONSTRAINT em_ho_horario_fk FOREIGN KEY ( horario_ho_codigo )
        REFERENCES horario ( ho_codigo )
;

ALTER TABLE EMPLEADO
    ADD CONSTRAINT empleado_correo_electronico_fk FOREIGN KEY ( correo_electronico_ce_codigo )
        REFERENCES correo_electronico ( ce_codigo )
;

ALTER TABLE EMPLEADO
    ADD CONSTRAINT empleado_departamento_fk FOREIGN KEY ( departamento_de_codigo )
        REFERENCES departamento ( de_codigo )
;

ALTER TABLE EMPLEADO
    ADD CONSTRAINT empleado_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE EMPLEADO
    ADD CONSTRAINT empleado_lugar_fk FOREIGN KEY ( lugar_lu_codigo )
        REFERENCES lugar ( lu_codigo )
;

ALTER TABLE EMPLEADO
    ADD CONSTRAINT empleado_tienda_fk FOREIGN KEY ( tienda_ti_codigo )
        REFERENCES tienda ( ti_codigo )
;

ALTER TABLE IMAGEN_PRODUCTO
    ADD CONSTRAINT imagen_producto_producto_fk FOREIGN KEY ( producto_pr_codigo )
        REFERENCES producto ( pr_codigo )
;

ALTER TABLE JURIDICO
    ADD CONSTRAINT juridico_cliente_fk FOREIGN KEY ( cl_rif )
        REFERENCES cliente ( cl_rif )
;

ALTER TABLE JURIDICO
    ADD CONSTRAINT juridico_lugar_fk FOREIGN KEY ( lugar_lu_codigo )
        REFERENCES lugar ( lu_codigo )
;

ALTER TABLE JURIDICO
    ADD CONSTRAINT juridico_lugar_fkv2 FOREIGN KEY ( lugar_lu_codigo1 )
        REFERENCES lugar ( lu_codigo )
;

ALTER TABLE LUGAR
    ADD CONSTRAINT lugar_lugar_fk FOREIGN KEY ( lugar_lu_codigo )
        REFERENCES lugar ( lu_codigo )
;

ALTER TABLE MO_TC
    ADD CONSTRAINT mo_tc_moneda_fk FOREIGN KEY ( moneda_mo_codigo )
        REFERENCES moneda ( mo_codigo )
;

ALTER TABLE MO_TC
    ADD CONSTRAINT mo_tc_tasa_de_cambio_fk FOREIGN KEY ( tasa_de_cambio_tc_codigo )
        REFERENCES tasa_de_cambio ( tc_codigo )
;

ALTER TABLE NATURALES
    ADD CONSTRAINT natural_cliente_fk FOREIGN KEY ( cl_rif )
        REFERENCES cliente ( cl_rif )
;

ALTER TABLE NATURALES
    ADD CONSTRAINT naturales_lugar_fk FOREIGN KEY ( lugar_lu_codigo )
        REFERENCES lugar ( lu_codigo )
;

ALTER TABLE PASILLO
    ADD CONSTRAINT pasillo_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE PASILLO
    ADD CONSTRAINT pasillo_tienda_fk FOREIGN KEY ( tienda_ti_codigo )
        REFERENCES tienda ( ti_codigo )
;

ALTER TABLE PE_ES
    ADD CONSTRAINT pe_es_estatus_fk FOREIGN KEY ( estatus_es_codigo )
        REFERENCES estatus ( es_codigo )
;

ALTER TABLE PE_ES
    ADD CONSTRAINT pe_es_pedido_fk FOREIGN KEY ( pedido_pe_codigo )
        REFERENCES pedido ( pe_codigo 
;

ALTER TABLE PE_PR
    ADD CONSTRAINT pe_pr_pedido_fk FOREIGN KEY ( pedido_pe_codigo )
        REFERENCES pedido ( pe_codigo )
;

ALTER TABLE PE_PR
    ADD CONSTRAINT pe_pr_producto_fk FOREIGN KEY ( producto_pr_codigo )
        REFERENCES producto ( pr_codigo )
;

ALTER TABLE PE_RO
    ADD CONSTRAINT pe_ro_permiso_fk FOREIGN KEY ( permiso_pe_codigo )
        REFERENCES permiso ( pe_codigo )
;

ALTER TABLE PE_RO
    ADD CONSTRAINT pe_ro_rol_fk FOREIGN KEY ( rol_ro_codigo )
        REFERENCES rol ( ro_codigo )
;

ALTER TABLE PEDIDO
    ADD CONSTRAINT pedido_cliente_fk FOREIGN KEY ( cliente_cl_rif )
        REFERENCES cliente ( cl_rif )
;

ALTER TABLE PEDIDO
    ADD CONSTRAINT pedido_método_de_pago_fk FOREIGN KEY ( método_de_pago_mp_codigo )
        REFERENCES metodo_de_pago ( mp_codigo )
;

ALTER TABLE PEDIDO
    ADD CONSTRAINT pedido_proveedor_fk FOREIGN KEY ( proveedor_pr_rif )
        REFERENCES proveedor ( pr_rif )
;

ALTER TABLE PERIODO_VACACIONAL
    ADD CONSTRAINT periodo_vacacional_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE PERSONA_CONTACTO
    ADD CONSTRAINT persona_contacto_juridico_fk FOREIGN KEY ( juridico_cl_rif )
        REFERENCES juridico ( cl_rif )
;

ALTER TABLE PERSONA_CONTACTO
    ADD CONSTRAINT persona_contacto_proveedor_fk FOREIGN KEY ( proveedor_pr_rif )
        REFERENCES proveedor ( pr_rif )
;

ALTER TABLE PR_PR
    ADD CONSTRAINT pr_pr_producto_fk FOREIGN KEY ( producto_pr_codigo )
        REFERENCES producto ( pr_codigo )
;

ALTER TABLE PR_PR
    ADD CONSTRAINT pr_pr_proveedor_fk FOREIGN KEY ( proveedor_pr_rif )
        REFERENCES proveedor ( pr_rif )
;

ALTER TABLE PR_ZO
    ADD CONSTRAINT pr_zo_producto_fk FOREIGN KEY ( producto_pr_codigo )
        REFERENCES producto ( pr_codigo )
;

ALTER TABLE PR_ZO
    ADD CONSTRAINT pr_zo_zona_fk FOREIGN KEY ( zona_zo_codigo )
        REFERENCES zona ( zo_codigo )
;

ALTER TABLE PRODUCTO
    ADD CONSTRAINT producto_clasificacion_fk FOREIGN KEY ( clasificacion_cl_codigo )
        REFERENCES clasificacion ( cl_codigo )
;

ALTER TABLE PRODUCTO
    ADD CONSTRAINT producto_marca_fk FOREIGN KEY ( marca_ma_codigo )
        REFERENCES marca ( ma_codigo )
;

ALTER TABLE PROVEEDOR
    ADD CONSTRAINT proveedor_correo_electronico_fk FOREIGN KEY ( correo_electronico_ce_codigo )
        REFERENCES correo_electronico ( ce_codigo )
;

ALTER TABLE PROVEEDOR
    ADD CONSTRAINT proveedor_lugar_fk FOREIGN KEY ( lugar_lu_codigo )
        REFERENCES lugar ( lu_codigo )
 
;

ALTER TABLE PROVEEDOR
    ADD CONSTRAINT proveedor_lugar_fkv1 FOREIGN KEY ( lugar_lu_codigo2 )
        REFERENCES lugar ( lu_codigo )
;

ALTER TABLE RO_EM
    ADD CONSTRAINT ro_em_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE RO_EM
    ADD CONSTRAINT ro_em_rol_fk FOREIGN KEY ( rol_ro_codigo )
        REFERENCES rol ( ro_codigo )
;

ALTER TABLE TARJETA
    ADD CONSTRAINT tarjeta_método_de_pago_fk FOREIGN KEY ( mp_codigo )
        REFERENCES metodo_de_pago ( mp_codigo )
;

ALTER TABLE TELEFONO
    ADD CONSTRAINT telefono_cliente_fk FOREIGN KEY ( cliente_cl_rif )
        REFERENCES cliente ( cl_rif )
;

ALTER TABLE TELEFONO
    ADD CONSTRAINT telefono_empleado_fk FOREIGN KEY ( empleado_em_codigo )
        REFERENCES empleado ( em_codigo )
;

ALTER TABLE TELEFONO
    ADD CONSTRAINT telefono_persona_contacto_fk FOREIGN KEY ( persona_contacto_pc_codigo )
        REFERENCES persona_contacto ( pc_codigo )
;

ALTER TABLE TELEFONO
    ADD CONSTRAINT telefono_proveedor_fk FOREIGN KEY ( proveedor_pr_rif )
        REFERENCES proveedor ( pr_rif )
;

ALTER TABLE TI_DE
    ADD CONSTRAINT ti_de_departamento_fk FOREIGN KEY ( departamento_de_codigo )
        REFERENCES departamento ( de_codigo )
;

ALTER TABLE TI_DE
    ADD CONSTRAINT ti_de_tienda_fk FOREIGN KEY ( tienda_ti_codigo )
        REFERENCES tienda ( ti_codigo )
;

ALTER TABLE TIENDA
    ADD CONSTRAINT tienda_cliente_fk FOREIGN KEY ( cliente_cl_rif )
        REFERENCES cliente ( cl_rif )
;

ALTER TABLE TIENDA
    ADD CONSTRAINT tienda_lugar_fk FOREIGN KEY ( lugar_lu_codigo )
        REFERENCES lugar ( lu_codigo )
;

ALTER TABLE ZONA
    ADD CONSTRAINT zona_almacen_fk FOREIGN KEY ( almacen_al_codigo )
        REFERENCES almacen ( al_codigo )
;

ALTER TABLE ZONA
    ADD CONSTRAINT zona_pasillo_fk FOREIGN KEY ( pasillo_pa_codigo,
                                                 pasillo_tienda_ti_codigo )
        REFERENCES pasillo ( pa_codigo,
                             tienda_ti_codigo )
;

ALTER TABLE empleado ADD em_password VARCHAR(32672);

ALTER TABLE cliente ADD cl_password VARCHAR(32672);

ALTER TABLE tienda DROP CONSTRAINT tienda_cliente_fk;

ALTER TABLE tienda DROP COLUMN cliente_cl_rif;
