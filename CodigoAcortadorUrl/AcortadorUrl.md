```mermaid
classDiagram

class AcortadorURL 
{
        - instance: AcortadorURL
        - random: Random
        - AcortadorURL()
        + Instance: AcortadorURL
        + Acortar(url: string): string
        + GenerarCodigoAleatorio(longitud: int): string
}
abstract class Suscripcion 
{
        - Estado: string
        - _strategy: ISuscripcionStrategy
        + Suscripcion(strategy: ISuscripcionStrategy)
        + CantidadUrlsPermitidas(): int
        + AdquirirSuscripcion(suscripcion: Suscripcion): void
}

interface ISuscripcionStrategy 
{
        + CantidadUrlsPermitidas(): int
}

class SuscripcionFREE 
{
        - CostoMensual: decimal
        - CostoAnual: decimal
        - CantidadUrls: int
        + CantidadUrlsPermitidas(): int
}

class SuscripcionVIP 
{
        - CostoMensual: decimal
        - CostoAnual: decimal
        - CantidadUrls: int
        + CantidadUrlsPermitidas(): int
}

class SuscripcionPRO 
{
        - CostoMensual: decimal
        - CostoAnual: decimal
        + CantidadUrlsPermitidas(): int
}

class Usuario 
{
        - Nombre: string
        - CorreoElectronico: string
        - Password: string
        + Usuario(nombre: string, password: string)
}


class DetalleURL 
{
        - FechaCreacion: DateTime
        - OriginalURL: string
        - AcortadoURL: string
        - EstadoValidez: DateTime
        + DetalleURL(originalURL: string)
        + Update(): void
}

class UsuarioSuscripcion 
{
        - FechaInicio: DateTime
        - FechaFin: DateTime
        - Suscripcion: Suscripcion
        - Usuario: string
        - detalles: List<DetalleURL>
        + RenovarSuscripcion(): void
        + CancelarSuscripcion(): void
        + Attach(detalle: DetalleURL): void
        + Detach(detalle: DetalleURL): void
        + Notify(): void
}
Usuario --> Suscripcion
Suscripcion <|-- SuscripcionFREE 
Suscripcion <|-- SuscripcionPRO 
Suscripcion <|-- SuscripcionVIP 

SuscripcionFREE ..> ISuscripcionStrategy 
SuscripcionPRO  ..> ISuscripcionStrategy 
SuscripcionVIP  ..> ISuscripcionStrategy 


Suscripcion -> UsuarioSuscripcion
UsuarioSuscripcion -> DetalleURL
@enduml
```
