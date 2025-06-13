import { useState, useEffect } from "react";
import MisDatos from "./MisDatos";

type Equipo ={
    
    "Escuela": string,
    "Carrera": string,
    "Grupo": string,
    "DatosSemestre": string,
    "NombreProyecto": string,
    "Integrante1": string,
    "Integrante2": string,
    "Fecha": string

}


const Presentacion = () => {
    const [equipo, setEquipo] = useState <Equipo>();
    //Manejo de datos
    const cargarDatos = async () => {
       const resp = await fetch("/presentacion/presentacion");
       if(resp.ok) {
        const data = await resp.json();
        console.log(data);
        setEquipo(data);
       }
    }

    useEffect(() => {
        cargarDatos();
    }, []);

    const formatoFecha = (fecha?: string) => {
        if(fecha){
            const formato = new Intl.DateTimeFormat ("es-MX", {year: "numeric", month: "2-digit", day: "2-digit"});
            const dt = new Date(fecha);
            return formato.format(dt);
        }
    }


    //Vista
    return (
        <>
        <div className="display-4 text-center">{equipo?.Escuela}</div>
        <div className="h1 text-center mt-4">{equipo?.Carrera}</div>
        <div className="h1 text-center mt-4">{equipo?.DatosSemestre}</div>
        <div className="h1 text-center">{equipo?.Grupo}</div>
        <div className="h1 text-center mt-4">Integrantes</div>
        <div className="h3 text-center text-primary">{equipo?.Integrante1}</div>
         <div className="h3 text-center text-primary">{equipo?.Integrante2}</div>
         <div className="h1 text-center mt-4">Nombre del proyecto</div>
        <div className="h2 text-center">{equipo?.NombreProyecto}</div>
        <div className="h4 text-center mt-4">{formatoFecha(equipo?.Fecha)}</div>
        </>
        
    )
}
export default Presentacion;