type Usuarios = {
    
}
const Usuarios = () => {
    return (
        <>
        <div className="container">
            <h1>Usuarios</h1>
        </div>
        <div className="container">
            <div className="card">
                <div className="card-header">Busqueda</div>
                <div className="card-body">
                    <div className="row">
                        <div className="col-12">
                            <div className="mb-3">
                                <label>Busqueda de Usuarios</label>
                                <input type="text" className="from-control" placeholder="introduce el nombre o el correo"/>
                            </div>
                        </div>
                        <div className="col-12">
                            <button className="btn btn-primary">Buscar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div className="container mt-4">
            <div className="card">
                <div className="card-header">Usuarios existentes</div>
                <div className="card-body">
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>No.</th>
                                <th>Nombre</th>
                                <th>Correo</th>
                                <th>Password</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Nombre del usuario 1</td>
                                <td>Nombre del usuario 1</td>
                                <td>Contraseña del usuario 1</td>
                                <td>
                                    <button className="btn btn-primary">Editar</button>
                                    <button className="btn btn-danger">Eliminar</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        </>
    )
}

export default Usuarios;