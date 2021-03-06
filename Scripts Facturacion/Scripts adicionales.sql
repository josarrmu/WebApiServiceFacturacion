
--script1
SELECT distinct
		cli.ID_CLIENTE,
		NOMENCLATURA,
		IDENTIFICACION_CLIENTE,	
		NOMBRE_CLIENTE,
		EDAD,			
		DIRECCION_CLIENTE,		
		TELEFONO_CLIENTE,		
		EMAIL,	
		NOMBRE_CATEGORIA
		
		FROM Factura as fact inner join
		Cliente AS CLI ON CLI.ID_CLIENTE = FACT.ID_CLIENTE
		INNER JOIN Tipo_Identificacion AS TI ON CLI.ID_TIPO_IDENTIFICACION= TI.ID_TIPO_IDENTIFICACION
		INNER JOIN Categoria_Cliente AS CATCLI ON CLI.ID_CATEGORIA_CLIENTE= CATCLI.ID_CATEGORIA_CLIENTE
		

		WHERE CLI.EDAD <=35 AND FACT.FECHA_CREACION BETWEEN '20000201' AND '20000525'

--script 2
		SELECT   
	CLIENTE.IDENTIFICACION_CLIENTE,
	CLIENTE.NOMBRE_CLIENTE,

	DATEADD(DAY, DATEDIFF ( DAY , MIN(FACTURA.FECHA_CREACION) , MAX(FACTURA.FECHA_CREACION) ) /(COUNT(*)),MAX(FACTURA.FECHA_CREACION)) AS FECHA_PROBABLE_COMPRA
				FROM FACTURA 
				INNER JOIN CLIENTE ON FACTURA.ID_CLIENTE=CLIENTE.ID_CLIENTE
				WHERE FACTURA.ID_CLIENTE= ISNULL(@ID_CLIENTE, FACTURA.ID_CLIENTE)
	GROUP BY CLIENTE.IDENTIFICACION_CLIENTE, NOMBRE_CLIENTE


	--scrip3

	SELECT prod.ID_PRODUCTO, 
	PROD.CODIGO_PRODUCTO,
			PROD.NOMBRE_PRODUCTO,
			SUM(DETAIL.CANTIDAD_PRODUCTO* DETAIL.PRECIO_PRODUCTO) AS TOTAL


	FROM DETALLE_FACTURA AS DETAIL
	INNER JOIN FACTURA AS FACT ON DETAIL.ID_FACTURA= FACT.ID_FACTURA
	INNER JOIN Producto AS PROD ON DETAIL.ID_PRODUCTO= PROD.ID_PRODUCTO

	WHERE YEAR( FACT.FECHA_CREACION ) = 2000

	GROUP BY PROD.ID_PRODUCTO,PROD.CODIGO_PRODUCTO,PROD.NOMBRE_PRODUCTO
	


	SELECT 
	CODIGO_PRODUCTO,		
	NOMBRE_PRODUCTO	,	
	DESCRIPCION_PRODUCTO,
	CANTIDAD_STOCK,		
	NOMBRE_CATEGORIA,
	NOMBRE_PROVEEDOR,
	PRECIO
	
	FROM Producto AS PROD INNER JOIN Categoria_Producto AS CP ON PROD.ID_CATEGORIA= CP.ID_CATEGORIA_PRODUCTO
	INNER JOIN Proveedores  AS PROOV ON  PROD.ID_PROVEEDOR= PROOV.ID_PROVEEDOR 


	SELECT 
	CODIGO_PRODUCTO,		
	NOMBRE_PRODUCTO	,	
	DESCRIPCION_PRODUCTO,
	CANTIDAD_STOCK,		
	NOMBRE_CATEGORIA,
	NOMBRE_PROVEEDOR,
	PRECIO
	
	FROM Producto AS PROD INNER JOIN Categoria_Producto AS CP ON PROD.ID_CATEGORIA= CP.ID_CATEGORIA_PRODUCTO
	INNER JOIN Proveedores  AS PROOV ON  PROD.ID_PROVEEDOR= PROOV.ID_PROVEEDOR 
	where CANTIDAD_STOCK<=5


	