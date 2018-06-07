# GDisaster

#LA RAMA DONDE DERIVARAN LAS DEMAS ES LA DE vBETA

#INFORMACION SOBRE LAS TABLAS:

-ORIGEN_DATOS: Informacion sobre donde se utiliza los datos, ejemplo--> ID: 1 - Denom: Interfaz .

-IDIOMAS: Idiomas que se van a utilizar par el videojuego.

-GDP_Descripciones: Descripciones y literales de la aplicacion ligado a la tabla de Idiomas
				   y a la tabla de ORIGEN_DATOS asi tenemos info de cada descripcion,
				   tiene doble PK tipo NONCLUSTERED esto permite tener la misma id de la descripcion
				   para idiomas diferentes.
				   Ejemplo : 
					   ESPAÑOL:
							ID: 1 
							Descripcion : 'Nueva Partida' 
							id_idioma: 'es.ES'(Español(Tab)) 
							id_Origen : 1(Interfaz(Tabla ORIGEN_DATOS))
					   CATALAN:
							ID: 1 
							Descripcion : 'Nova Partida' 
							id_idioma: 'ca.ES'(Español(Tab)) 
							id_Origen : 1(Interfaz(Tabla ORIGEN_DATOS)).
					   INGLES:
							ID: 1 
							Descripcion : 'New Game' 
							id_idioma: 'en.GB'(Español(Tab)) 
							id_Origen : 1(Interfaz(Tabla ORIGEN_DATOS)).
							

-GDP_Armas: Guarda la informacion sobre las armas que se pueden recoger o no.

-GDP_Monstruos: Guarda la informacion sobre los monstruos

-GDP_MonTipo: Guarda la informacion sobre el tipo de monstruos.
			 Ejemplo : ID: NO - ID_desc: 12 (En la tabla de Descripciones --> Normal)

-GDP_CalidadArma:Guarda la calidad del arma
			 Ejermplo : ID: L - ID_desc: 11 (En la tabla de Descripciones --> Legendario)

-GDP_Guardados: Guarda las coordenadas del jugador al hacer un guardado, con la fecha y la hora en la que se hizo.
